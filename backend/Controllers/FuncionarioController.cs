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

        [HttpGet("agendamentos")]
          public ActionResult<List<Models.Response.TestDriveResponse.Aprovar>> ListarAgendamentosSemFuncionario()
          {
             try
             {
                 List<Models.TbAgendamento> funcionario=business.Listar();
                 return funcionario.Select(x=>conversor.ParaResponseConsultar(x)).ToList();
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

          [HttpPut("aprovar/{IdAgendamento}/{IdFuncionario}")]
          public ActionResult<Models.Response.TestDriveResponse.Aprovar> AprovarAgendamento(int IdAgendamento, int IdFuncionario)
          {
              try
              {
                return conversor.ParaResponseAprovar(business.AprovarAgendamento(IdAgendamento,IdFuncionario));
              }
              catch (System.Exception e)
              {
                return BadRequest(new Models.Response.erro(400,e.Message));
              }
          } 
          [HttpPut("alterar/{idagendamento}")]
         public ActionResult<Models.Response.TestDriveResponse.Aprovar> CancelarAgendamento(int idagendamento,Models.Request.TestDriveRequest.InformarSituacao situacao)
         {
              try
              {
                  return conversor.ParaResponseAprovar(business.AlterarSituacao(idagendamento,situacao.Situacao));
              }
              catch (System.Exception e)
              {
                  
                  return new NotFoundObjectResult(new Models.Response.erro(404,e.Message));
              }
         }
 
    }
}