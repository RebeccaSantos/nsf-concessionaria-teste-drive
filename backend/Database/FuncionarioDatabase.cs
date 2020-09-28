using System.Collections.Generic;
using System.Linq;
using System;

namespace backend.Database
{
    public class FuncionarioDatabase
    {
        Models.testDriveContext ctx = new Models.testDriveContext();
       public List<Models.TbFuncionario> ListarFuncionarios()
        {
            return ctx.TbFuncionario.ToList();
        }

        public List<Models.TbAgendamento> ListarAgendamentos()
        {
            return ctx.TbAgendamento.Where(x => x.DtAgendamento.Value.Day == DateTime.Now.Day &&
                                            x.DtAgendamento.Value.Month == DateTime.Now.Month &&
                                            x.DtAgendamento.Value.Year == DateTime.Now.Year).ToList();
        }
        public Models.TbAgendamento AprovarAgendamento(Models.TbAgendamento agendamento)
        {
           agendamento.DsSituacao = "Aprovado";
           return agendamento;
        }
        public Models.TbAgendamento VerificarDisponibilidade(int idAgendamento)
        {
            Models.TbAgendamento tabela = ctx.TbAgendamento.FirstOrDefault(x => x.IdAgendamento == idAgendamento);
            Models.TbAgendamento tb = ctx.TbAgendamento.FirstOrDefault(x => x.IdFuncionario == tabela.IdFuncionario && 
                                                                    x.DtAgendamento.Value.Day == tabela.DtAgendamento.Value.Day);

             if(tb!=null||tabela.DtAgendamento.Value.Hour == tb.DtAgendamento.Value.Hour)
                throw new ArgumentException("Horario indisponivel");
            else
              return AprovarAgendamento(tabela);
        }
    }
}