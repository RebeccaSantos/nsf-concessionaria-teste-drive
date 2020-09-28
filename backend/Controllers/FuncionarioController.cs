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

        [HttpGet("funcionarios")]
          public ActionResult<List<Models.Response.TestDriveResponse.Funcionario>> ListarFuncionarios()
          {
             try
             {
                 List<Models.TbFuncionario> funcionario=business.ListarFuncionarios();
                 return funcionario.Select(x=>conversor.ParaResponseFuncionario(x)).ToList();
             }
             catch (System.Exception e)
             {
                 
                 return new  NotFoundObjectResult(new Models.Response.erro(404,e.Message));
             }
          }
          [HttpGet]
          public ActionResult<List<Models.Response.TestDriveResponse.ClienteAgendamento>> ListarAgendamentos()
          {
              List<Models.TbAgendamento> agendamentos = business.ListarAgendamentos();
              List<Models.Response.TestDriveResponse.ClienteAgendamento> resp = agendamentos
                                    .Select(x => conversor.ParaResponseagenda(x)).ToList();
                return resp; 
          }
    }
}