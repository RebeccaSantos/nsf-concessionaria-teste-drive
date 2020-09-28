using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;


namespace backend.Business
{
    public class LoginBusiness
    {
        Database.LoginDatabase database=new Database.LoginDatabase();
        Validar.ValidardorTestDrive validar=new Validar.ValidardorTestDrive();
        public Models.TbLogin VerificarLogin(Models.Request.TestDriveRequest.Login req )
        {
            Models.TbLogin tabela=database.verificarLogin(req);
            validar.VerificarLogin(tabela);
            return tabela;
        }
        public string VerificarPerfil (Models.TbLogin tabela)
        {
            return database.VerificarPerfil(tabela);
        }

       public Models.TbFuncionario verificarFucionario(Models.TbLogin tb)
        {
                return database.verificarFuncionario(tb);
        }

        public Models.TbCliente verificarCliente(Models.TbLogin tb)
        {
            return database.verificarCliente(tb);
        }

  
    }
}
                
