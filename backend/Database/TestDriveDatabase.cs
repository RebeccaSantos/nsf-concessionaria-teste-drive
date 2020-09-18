using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace backend.Database
{
    public class TestDriveDatabase
    { 
        Models.testdriveContext ctx=new Models.testdriveContext();
        public Models.TbLogin verificarLogin(Models.Request.TestDriveRequest.Login req)
        {
               Models.TbLogin tabela=ctx.TbLogin.FirstOrDefault(x=>x.DsUsername==req.UserName&&
                                                                x.DsSenha==req.Senha);
                return tabela;
        }
        public string VerificarPerfil(Models.TbLogin tb)
        {
            Models.TbCliente tabela=ctx.TbCliente.FirstOrDefault(x=>x.IdLogin==tb.IdLogin);
            if(tabela==null)
                 return "Funcionário";
                 
            else 
             return "Cliente";     
                      
        }
        
        public Models.TbCliente verificarCliente(Models.TbLogin tb)
        {
               Models.TbCliente tabela=ctx.TbCliente.FirstOrDefault(x=>x.IdLogin==tb.IdLogin);
                return tabela;
        }
            public Models.TbFuncionario verificarFuncionario(Models.TbLogin tb)
        {
               Models.TbFuncionario tabela=ctx.TbFuncionario.FirstOrDefault(x=>x.IdLogin==tb.IdLogin);
                return tabela;
        }
        public List<Models.TbAgendamento> Agendamentos (int id)
        {
            List<Models.TbAgendamento> agendamento=ctx.TbAgendamento.Include(x=>x.IdClienteNavigation).Include(x=>x.IdFuncionarioNavigation).Where(x=>x.IdCliente==id).ToList();
            return agendamento;
        }
        public Models.TbAgendamento Agendamento(Models.TbAgendamento ag)
        {
            ctx.Add(ag);
            ctx.SaveChanges();
            return ag;
        }
    }
}