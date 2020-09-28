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
    public class Cliente:ControllerBase
    {
        Business.AgendamentoBusiness business = new Business.AgendamentoBusiness();
        Utils.TestDriveConversor conversor = new Utils.TestDriveConversor();

        [HttpGet("Consultar/{id}")]
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

        [HttpPost("{id}")]
        public ActionResult<Models.Response.TestDriveResponse.ClienteAgendar> agendar(Models.Request.TestDriveRequest.Agendar ag,int id)
          {
               try
               {
                    Models.TbCarro car=business.Verificarcarro(ag.Carro);
                    if(car==null)
                       return  NotFound();

                    Models.TbAgendamento tb=conversor.ParaTabelaAgenda(ag,id,car);
                    business.ValidarAgendamento(tb);
                    return conversor.ParaResponseagendar(tb);
               }
               catch (System.Exception e)
               {
                   
                   return  BadRequest(new Models.Response.erro(400,e.Message));
               }
           }
          [HttpPut("feedback/{id}")]
          public ActionResult<Models.Response.TestDriveResponse.ResponseFeedback> RealizarFeedback(Models.Request.TestDriveRequest.RequestFeedback req,int id)
          {
              try
              {
                   Models.TbAgendamento tb=business.ValidarFeedback(req,id);
                    return conversor.ParaResponseFeedback(tb);
                  
              }
              catch (System.Exception e)
              {
                  
                  return BadRequest(new Models.Response.erro(400,e.Message));
              }
          }   
    }
}