using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace backend.Database
{
    public class FuncionarioDatabase
    {
        Models.testDriveContext ctx = new Models.testDriveContext();
       public List<Models.TbAgendamento> Listar()
        {
            return ctx.TbAgendamento.Include(x => x.IdClienteNavigation)
                                            .Include(x => x.IdFuncionarioNavigation)
                                            .Include(x => x.IdCarroNavigation)
                                            .Where(x => x.IdFuncionario == null).ToList();
        }

        public List<Models.TbAgendamento> ListarAgendamentos(int id)
        {
            return ctx.TbAgendamento.Include(x => x.IdClienteNavigation)
                                            .Include(x => x.IdFuncionarioNavigation)
                                            .Include(x => x.IdCarroNavigation).Where(x => x.IdFuncionario == id &&
                                            x.DtAgendamento.Value.Day == DateTime.Now.Day &&
                                            x.DtAgendamento.Value.Month == DateTime.Now.Month &&
                                            x.DtAgendamento.Value.Year == DateTime.Now.Year).ToList();
        }
        public Models.TbAgendamento AlterarIdfuncionario(int id ,Models.TbAgendamento tabela)
         {
              tabela.IdFuncionario = id;
              ctx.SaveChanges();
              return tabela;
         }
        public Models.TbAgendamento AprovarAgendamento(Models.TbAgendamento agendamento)
        {
           agendamento.DsSituacao = "Aprovado";
            
           ctx.SaveChanges();
           return agendamento;
        }
        public Models.TbAgendamento VerificarDisponibilidade(int idAgendamento,int idFuncionario)
        {
            Models.TbAgendamento tabela = ctx.TbAgendamento.FirstOrDefault(x => x.IdAgendamento == idAgendamento);
             Models.TbAgendamento tb = ctx.TbAgendamento.FirstOrDefault(x =>x.IdAgendamento!=tabela.IdAgendamento&&
                                                                    x.DtAgendamento.Value.Day == tabela.DtAgendamento.Value.Day&&
                                                                    x.IdFuncionario == idFuncionario);
             if((tb!=null && tb.DsSituacao.Contains("Aprovado")) 
               && (tabela.DtAgendamento.Value.Hour == tb.DtAgendamento.Value.Hour ||
               (tabela.DtAgendamento.Value.Hour > tb.DtAgendamento.Value.Hour &&
                tabela.DtAgendamento.Value.Hour < tb.DtAgendamento.Value.AddHours(+1).Hour)))
                throw new ArgumentException("Horario indisponivel");
              
            else
               {
                 AlterarIdfuncionario(idFuncionario,tabela);
                  return AprovarAgendamento(tabela);
               }
        }
        public Models.TbAgendamento AlterarSituacao(int idAgendamento,string Situacao)
        {
            Models.TbAgendamento tabela = ctx.TbAgendamento.FirstOrDefault(x => x.IdAgendamento == idAgendamento);
            tabela.DsSituacao = Situacao;
            ctx.SaveChanges();
            return tabela;
        }
        

    }
}