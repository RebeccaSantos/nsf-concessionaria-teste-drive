using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace backend.Controllers
{
     [ApiController]
    [Route("[controller]")]
    public class TestDriveController:ControllerBase
    {
     Business.TestDriveBusiness business=new Business.TestDriveBusiness();
        Utils.TestDriveConversor conversor=new Utils.TestDriveConversor();
       
        [HttpPost("Login")]
        public  ActionResult<Models.Response.TestDriveResponse.Login> VerificarLogin(Models.Request.TestDriveRequest.Login req)
        {
            try
            {
                        
                    Models.TbLogin tb=business.VerificarLogin(req);
                    Models.TbCliente cliente=business.verificarCliente(tb);
                    Models.TbFuncionario funcionario=business.verificarFucionario(tb);
                    return conversor.ParaResponseLogin( cliente,funcionario,business.VerificarPerfil(tb));
            }
            catch (System.Exception e)
            {
                
                return new NotFoundObjectResult(new Models.Response.erro(404,e.Message));
            }
        }
        [HttpGet("Cliente/Consultar/{id}")]
          public ActionResult<List<Models.Response.TestDriveResponse.ClienteAgendamento>> ClienteAgendamentos(int id)
          {
               try
               {
                    List<Models.TbAgendamento> tb=business.AgendamentosCliente(id);
                    List<Models.Response.TestDriveResponse.ClienteAgendamento> resp=tb.Select(x=>conversor.ParaResponseagenda(x)).ToList();
                    return resp;
               }
               catch (System.Exception e)
               {
                   
                    return new NotFoundObjectResult(new Models.Response.erro(404,e.Message)); 
                
               }  
              
          }
         // [HttpPost("cliente/{id}")]
          //public Models.Response.TestDriveResponse.ClienteAgendar agendar(Models.Request.TestDriveRequest.Agendar ag,int id)
          //{
               //Models.TbAgendamento tb=conversor.ParaTabelaAgenda(ag,id);
               //business.ValidarAgendamento(tb);
               //return conversor.ParaResponseagendar(tb);
                 
          //}
         /* [HttpPut("feedback/{id}")]
          public Models.Response.TestDriveResponse.ResponseFeedback RealizarFeedback(Models.Request.TestDriveRequest.RequestFeedback req,int id)
          {
               Models.TbAgendamento tb=business.ValidarFeedback(req,id);
               return conversor.ParaResponseFeedback(tb);
          }*/

    }
                
}
               
            
         
          
                

             
        