using System.Collections.Generic;
using System.Linq;
using System;

namespace backend.Database
{
    public class FuncionarioDatabase
    {
        Models.TestDriveContext ctx = new Models.TestDriveContext();
       public List<Models.TbFuncionario> ListarFuncionarios()
        {
            return ctx.TbFuncionario.ToList();
        }

        public List<Models.TbAgendamento> ListarAgendamentos()
        {
            return ctx.TbAgendamento.Where(x => x.DtAgendamento == DateTime.Now).ToList();
        }
    }
}