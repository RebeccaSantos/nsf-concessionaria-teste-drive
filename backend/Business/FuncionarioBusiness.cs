using System.Collections.Generic;
using System.Linq;
using System;

namespace backend.Business
{
    public class FuncionarioBusiness
    {
        Database.FuncionarioDatabase database = new Database.FuncionarioDatabase();
        public List<Models.TbFuncionario> ListarFuncionarios()
        {
            List<Models.TbFuncionario> funcionarios=database.ListarFuncionarios();

               if(funcionarios.Count==0)
                  throw new ArgumentException("ainda não há registros");

                  return  funcionarios;
        }
    }
}