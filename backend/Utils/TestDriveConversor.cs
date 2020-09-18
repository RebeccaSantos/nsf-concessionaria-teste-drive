using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


namespace backend.Utils
{
    public class TestDriveConversor
    {
        public Models.Response.TestDriveResponse.Login ParaResponseLogin(Models.TbCliente tb,Models.TbFuncionario tb2,string descricao)
        {
            Models.Response.TestDriveResponse.Login usuario=new Models.Response.TestDriveResponse.Login();


            if(descricao=="Cliente"&&tb!=null)
            {
                usuario.IdLogin=tb.IdLoginNavigation.IdLogin;
                usuario.UserName=tb.IdLoginNavigation.DsUsername;
                usuario.Descricao="não é funcionario";
                usuario.IdCliente=tb.IdCliente;
                usuario.Nome=tb.NmCliente;
                usuario.ClienteFuncionario=descricao;
                usuario.IdFuncionario=0;
            }
            else if(descricao=="Funcionário"&&tb2!=null)
            {
                usuario.IdCliente=0;
                usuario.UserName=tb2.IdLoginNavigation.DsUsername;
                usuario.Descricao=tb2.IdLoginNavigation.DsPerfil;
                usuario.IdLogin=tb2.IdLoginNavigation.IdLogin;
                usuario.Nome=tb2.NmFuncionario;
                usuario.ClienteFuncionario=descricao;
                usuario.IdFuncionario=tb2.IdFuncionario;
            }
   

           return usuario;
            
        }
        public Models.Response.TestDriveResponse.ClienteAgendamento ParaResponseagenda(Models.TbAgendamento ag)
        {
            Models.Response.TestDriveResponse.ClienteAgendamento agendamento=new Models.Response.TestDriveResponse.ClienteAgendamento();
            agendamento.Id=ag.IdAgendamento;
            agendamento.Nome=ag.IdClienteNavigation.NmCliente;
            agendamento.Cpf=ag.IdClienteNavigation.DsCpf;
            agendamento.Funcionario=ag.IdFuncionarioNavigation.NmFuncionario;
            agendamento.Carro=ag.DsCarro;
            agendamento.Dia=ag.DtAgendamento;
            agendamento.Situacao=ag.DsSituacao;

            return agendamento;
        }
    } 
}