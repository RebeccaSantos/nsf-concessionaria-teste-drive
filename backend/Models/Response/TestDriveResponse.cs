using System;

namespace backend.Models.Response
{
    public class TestDriveResponse
    {
        public class Login
        {
            public int IdLogin { get; set; }
            public string UserName { get; set; }
            
            public string Descricao { get; set; }
            public string Nome { get; set; }
            public string ClienteFuncionario { get; set; }
            public int IdCliente { get; set; }
            public int IdFuncionario { get; set; }
        }
        public class ClienteAgendamento
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Cpf { get; set; }
            public string Funcionario { get; set; }
            public string Carro { get; set; }
            public DateTime?  Dia { get; set; }
            public string Situacao{ get; set; }

        }
        
        public class ClienteAgendar
        {
            public int?  Id { get; set; }
            public int? Funcionario { get; set; }
            public string Carro { get; set; }
            public DateTime?  Dia { get; set; }
            public string Situacao{ get; set; }

        }
        public class ResponseFeedback
        {
            public decimal? Feedback { get; set; }
        }
    }
}