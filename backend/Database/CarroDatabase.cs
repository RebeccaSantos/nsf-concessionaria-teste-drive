using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore; 

namespace backend.Database
{
    public class CarroDatabase
    {
        Models.testDriveContext ctx = new Models.testDriveContext();


        public List<Models.TbCarro> ListarCarros()
        {
           return ctx.TbCarro.ToList();
        }
    }
}