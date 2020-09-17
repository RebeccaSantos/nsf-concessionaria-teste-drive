using System;
using System.Collections.Generic;
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
        [HttpGet("Login")]
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
    }
}