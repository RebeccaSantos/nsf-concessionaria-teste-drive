using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace backend.Database
{
    public class FuncionarioDatabase
    {
        Models.testDriveContext ctx = new Models.testDriveContext();
       public List<Models.TbAgendamento> ListarAgendamentos()
        {
            return ctx.TbAgendamento.ToList();
        }

        public List<Models.TbAgendamento> ListarAgendamentos(int id)
        {
            return ctx.TbAgendamento.Include(x => x.IdClienteNavigation)
                                            .Include(x => x.IdFuncionarioNavigation)
                                            .Include(x => x.IdCarroNavigation).Where(x => x.IdFuncionario == id &&
                                            x.DsSituacao == "Aprovado" &&
                                            x.DtAgendamento.Value.Day == DateTime.Now.Day &&
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
            Models.TbAgendamento tb = ctx.TbAgendamento.FirstOrDefault(x =>x.IdAgendamento!=tabela.IdAgendamento&&
                                                                     x.IdFuncionario == tabela.IdFuncionario && 
                                                                    x.DtAgendamento.Value.Day == tabela.DtAgendamento.Value.Day);
             if((tb!=null && tb.DsSituacao.Contains("Aguardando")) 
               && (tabela.DtAgendamento.Value.Hour == tb.DtAgendamento.Value.Hour ||
               (tabela.DtAgendamento.Value.Hour > tb.DtAgendamento.Value.Hour &&
                tabela.DtAgendamento.Value.Hour < tb.DtAgendamento.Value.AddHours(+1).Hour)))
                throw new ArgumentException("Horario indisponivel");
              
            else
              return AprovarAgendamento(tabela);
        }
    }
}