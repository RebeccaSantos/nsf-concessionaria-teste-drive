using System.Collections.Generic;
using System.Linq;
using System;

namespace backend.Business
{
    public class FuncionarioBusiness
    {
        Validar.ValidardorTestDrive validador = new Validar.ValidardorTestDrive();
        Database.FuncionarioDatabase database = new Database.FuncionarioDatabase();
        public List<Models.TbFuncionario> ListarFuncionarios()
        {
            List<Models.TbFuncionario> funcionarios=database.ListarFuncionarios();

               if(funcionarios.Count==0)
                  throw new ArgumentException("ainda não há registros");

                  return  funcionarios;
        }

       public List<Models.TbAgendamento> ListarAgendamentos()
       {
           return database.ListarAgendamentos();
       } 

       public Models.TbAgendamento AprovarAgendamento(int idagendamento)
       {
           validador.Validacao(idagendamento);
           return database.VerificarDisponibilidade(idagendamento);
       }
    }
}