using System.Collections.Generic;
using System.Linq;

namespace backend.Database
{
    public class FuncionarioDatabase
    {
        Models.TestDriveContext ctx = new Models.TestDriveContext();



        public List<Models.TbFuncionario> ListarFuncionarios()
        {
            return ctx.TbFuncionario.ToList();
        }
    }
}