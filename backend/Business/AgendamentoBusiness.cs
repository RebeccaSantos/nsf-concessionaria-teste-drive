using System;
using System.Collections;
using System.Collections.Generic;

namespace backend.Business
{
    public class AgendamentoBusiness
    {
        Database.AgendamentoDatabase database = new Database.AgendamentoDatabase();
        Validar.ValidardorTestDrive validar = new Validar.ValidardorTestDrive();
        public List<Models.TbAgendamento> AgendamentosCliente(int id)
        {
            validar.Validacao(id);
            return database.ListarAgendamentos(id);
        }

        public Models.TbAgendamento ValidarAgendamento(Models.TbAgendamento ag)
        {
            validar.ValidarAgendamento(ag);
            return database.SalvarAgendamento(ag);
        }

        public Models.TbAgendamento ValidarFeedback(Models.Request.TestDriveRequest.RequestFeedback req ,int id)
        {
            
                validar.ValidarFeedBack(req.Feedback,id);    
                return database.Feedback(req,id);
        }
        public Models.TbCarro Verificarcarro(string carro)
        {
            validar.VerificarCarro(carro);
            return database.VerificarCarro(carro);
        }
        
    }
}