using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore; 

namespace backend.Database
{
    public class CarroDatabase
    {
        Models.TestDriveContext ctx = new Models.TestDriveContext();


        public List<Models.TbCarro> ListarCarros()
        {
           return ctx.TbCarro.ToList();
        }
    }
}