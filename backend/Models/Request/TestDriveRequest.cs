using System; 
namespace backend.Models.Request
{
    public class TestDriveRequest
    {
        public class Login
        {
            public string UserName { get; set; }
            public string Senha { get; set; }
        }
        public class Agendar
        {
            public string Carro { get; set; }
            public DateTime  Agendamento{ get; set; }
    
        }
        public class RequestFeedback
        {
            public decimal Feedback { get; set; }
        }
        public class id
        {
            public int IdFuncionario{get;set;}
        }
        public class InformarSituacao
        {
            public string Situacao { get; set; }
        }
   }
}