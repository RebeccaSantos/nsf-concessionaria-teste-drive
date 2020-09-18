using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace backend.Business
{
    public class TestDriveBusiness
    {
        Database.TestDriveDatabase database=new Database.TestDriveDatabase();
        public Models.TbLogin VerificarLogin(Models.Request.TestDriveRequest.Login req )
        {
            Models.TbLogin tabela=database.verificarLogin(req);
            
            if(tabela==null)
                  throw new ArgumentException("username ou senha incorretos");

                  return tabela;

        }
        public string VerificarPerfil (Models.TbLogin tabela)
        {
            return database.VerificarPerfil(tabela);
        }
    
        public Models.TbCliente verificarCliente(Models.TbLogin tb)
        {
                return database.verificarCliente(tb);
          
        }
      public Models.TbFuncionario verificarFucionario(Models.TbLogin tb)
        {
                return database.verificarFuncionario(tb);
          
        }
        public List<Models.TbAgendamento> AgendamentosCliente(int id)
        {
                if(id<=0)
                   throw new ArgumentException("id invalido");

            return database.Agendamentos(id);
        }
        public Models.TbAgendamento ValidarAgendamento(Models.TbAgendamento ag)
        {
                if(ag.IdCliente<=0)
                    throw new ArgumentException("id invalido");

                if(ag.IdFuncionario<=0)
                    throw new ArgumentException("id invalido");

                if(ag.DtAgendamento==new DateTime())
                throw new ArgumentException("Essa Data ja passou");

                if(string.IsNullOrEmpty(ag.DsCarro))
                     throw new ArgumentException("Descrição do carro invalida");
             
             return database.Agendamento(ag);
        }
    }
}