using System.Collections.Generic;
using System.Linq;
using System;

namespace backend.Business
{
    public class FuncionarioBusiness
    {
        Validar.ValidardorTestDrive validador = new Validar.ValidardorTestDrive();
        Database.FuncionarioDatabase database = new Database.FuncionarioDatabase();
        public List<Models.TbAgendamento> ListarAgendamentos()
        {
            List<Models.TbAgendamento> agendamento=database.ListarAgendamentos();

               if(agendamento.Count==0)
                  throw new ArgumentException("ainda não há registros");

                  return  agendamento;
        }

       public List<Models.TbAgendamento> ListarAgendamentos(int id)
       {
           return database.ListarAgendamentos(id);
       } 

       public Models.TbAgendamento AprovarAgendamento(int idagendamento)
       {
           validador.Validacao(idagendamento);
           return database.VerificarDisponibilidade(idagendamento);
       }
    }
}