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
    public class FuncionarioController:ControllerBase
    {
         Business.FuncionarioBusiness business = new Business.FuncionarioBusiness();
         Utils.TestDriveConversor conversor = new Utils.TestDriveConversor();

        [HttpGet("agendamentos/{idfuncionario}")]
          public ActionResult<List<Models.Response.TestDriveResponse.Aprovar>> ListarFuncionarios(int idfuncionario)
          {
             try
             {
                 List<Models.TbAgendamento> funcionario=business.Listar(idfuncionario);
                 return funcionario.Select(x=>conversor.ParaResponseAprovar(x)).ToList();
             }
             catch (System.Exception e)
             {
                 
                 return new  NotFoundObjectResult(new Models.Response.erro(404,e.Message));
             }
          }

          [HttpGet("{idfuncionario}")]
          public ActionResult<List<Models.Response.TestDriveResponse.ClienteAgendamento>> ListarAgendamentosDia(int idfuncionario)
          {
              try
              {
                List<Models.TbAgendamento> agendamentos = business.ListarAgendamentos(idfuncionario);
                List<Models.Response.TestDriveResponse.ClienteAgendamento> resp = agendamentos
                                    .Select(x => conversor.ParaResponseagenda(x)).ToList();
                return resp; 
              }
              catch (System.Exception e)
              {
                return new NotFoundObjectResult(new Models.Response.erro(404,e.Message));
              }
          }

          [HttpPut("{idagendamento}")]
          public ActionResult<Models.Response.TestDriveResponse.Aprovar> AprovarAgendamento(int idagendamento,Models.Request.TestDriveRequest.id id)
          {
              try
              {
                  return conversor.ParaResponseAprovar(business.AprovarAgendamento(idagendamento,id.IdFuncionario));
              }
              catch (System.Exception e)
              {
                  return BadRequest(new Models.Response.erro(400,e.Message));
              }
          } 
          [HttpPut("Cancelar/{id}")]
         public ActionResult<Models.Response.TestDriveResponse.Aprovar> CancelarAgendamento(int id)
         {
              try
              {
                  return conversor.ParaResponseAprovar(business.CancelarAgendamento(id));
              }
              catch (System.Exception e)
              {
                  
                  return new NotFoundObjectResult(new Models.Response.erro(404,e.Message));
              }
         }
         [HttpPut("Comparecimento/{idagenda}")]
         public ActionResult<Models.Response.TestDriveResponse.Aprovar> ConfirmarComparecimento(int idagenda)
         {
              try
              {
                  return conversor.ParaResponseAprovar(business.ConfirmarComprecimento(idagenda));
              }
              catch (System.Exception e)
              {
                  
                  return new NotFoundObjectResult(new Models.Response.erro(404,e.Message));
              }
         }
        [HttpPut("Falta/{idagendar}")]
         public ActionResult<Models.Response.TestDriveResponse.Aprovar> ConfirmarFalta(int idagendar)
         {
              try
              {
                  return conversor.ParaResponseAprovar(business.ConfirmarFalta(idagendar));
              }
              catch (System.Exception e)
              {
                  
                  return new NotFoundObjectResult(new Models.Response.erro(404,e.Message));
              }
         }
    }
}