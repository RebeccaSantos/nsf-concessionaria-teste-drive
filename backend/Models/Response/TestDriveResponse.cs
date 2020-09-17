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
        public class FuncionarioLogin
        {
            public int IdLogin { get; set; }
            public string UserName { get; set; }
            public string Descricao { get; set; }
            public string Nome { get; set; }
            public string ClienteFuncionario { get; set; }
            public int IdFuncionario { get; set; }
        }
    }
}