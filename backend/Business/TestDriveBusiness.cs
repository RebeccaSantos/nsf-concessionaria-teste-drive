using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;


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

                if(ag.DtAgendamento==new DateTime()||ag.DtAgendamento<=DateTime.Now)
                throw new ArgumentException("Essa Data ja passou");

                if(ag.DtAgendamento.Value.DayOfWeek==DayOfWeek.Saturday||
                ag.DtAgendamento.Value.DayOfWeek==DayOfWeek.Sunday)
                        throw new  ArgumentException("Não atendemos aos finais de semana");



                return database.Agendamento(ag);
        }
                
             
       public Models.TbAgendamento ValidarFeedback(Models.Request.TestDriveRequest.RequestFeedback req ,int id)
        {
            if(req.Feedback<0)
                throw new ArgumentException("Feedback invalido");
                
                return database.Feedback(req,id);

        }
        public Models.TbCarro Verificarcarro(string carro)
        {
            if(string.IsNullOrEmpty(carro))
                throw new ArgumentException("carro é obrigatorio");
                
              return database.VerificarCarro(carro);
        }

        public List<Models.TbCarro> ListarCarros()
        {
            List<Models.TbCarro> carros=database.ListarCarros();

                if(carros.Count==0)
                  throw new ArgumentException("ainda não há registros");

                  return carros;
        }
        public List<Models.TbFuncionario> ListarFuncionarios()
        {
            List<Models.TbFuncionario> funcionarios=database.ListarFuncionarios();

               if(funcionarios.Count==0)
                  throw new ArgumentException("ainda não há registros");

                  return  funcionarios;
        }  
    }
}
                
