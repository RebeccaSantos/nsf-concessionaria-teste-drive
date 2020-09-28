using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace backend.Database
{
    public class AgendamentoDatabase
    {
        Models.TestDriveContext ctx = new Models.TestDriveContext();
       public List<Models.TbAgendamento> ListarAgendamentos (int id)
        {
            List<Models.TbAgendamento> agendamento = ctx.TbAgendamento.Include(x => x.IdClienteNavigation)
                                                                     .Include(x => x.IdFuncionarioNavigation)
                                                                     .Include(x => x.IdCarroNavigation)
                                                                     .Where(x => x.IdClienteNavigation.IdLoginNavigation.IdLogin == id).ToList();
            return agendamento;
        }
        public Models.TbAgendamento SalvarAgendamento(Models.TbAgendamento ag)
        {
            ctx.TbAgendamento.Add(ag);
            ctx.SaveChanges();
            return ag;
        }

        public Models.TbAgendamento Feedback(Models.Request.TestDriveRequest.RequestFeedback req,int id)
        {
                Models.TbAgendamento fed=ctx.TbAgendamento.FirstOrDefault(x=>x.IdAgendamento==id);
                fed.VlFeedback=req.Feedback;
                ctx.SaveChanges();
                return fed;
        }
        public Models.TbCarro VerificarCarro(string carro)
        {
            Models.TbCarro car = ctx.TbCarro.FirstOrDefault(x => x.DsModelo == carro);
            return car;
        }
    }
}