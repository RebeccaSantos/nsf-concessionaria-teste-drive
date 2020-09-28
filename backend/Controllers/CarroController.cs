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
    public class CarroController:ControllerBase
    {
        Business.CarroBusiness business = new Business.CarroBusiness();
        Utils.TestDriveConversor conversor = new Utils.TestDriveConversor();

          [HttpGet("Consultar/Carro")]
          public  ActionResult<List<Models.Response.TestDriveResponse.Carro>> ListarCarros()
          {
            try
            {
               List<Models.TbCarro> carro=business.ListarCarros();
               return carro.Select(x=>conversor.ParaResponseCarro(x)).ToList();
            }
            catch (System.Exception e)
            {
                
                return new NotFoundObjectResult(new Models.Response.erro(404,e.Message));
            }
          }
    }
}