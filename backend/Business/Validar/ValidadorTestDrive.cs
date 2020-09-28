using System;
using System.Collections;
namespace backend.Validar
{
    public class ValidardorTestDrive
    {
        public void Validacao(int? id)
        {
        
            ValidarId(id);
        }
        public void VerificarLogin(Models.TbLogin tabela)
        {
            if(tabela==null)
                throw new ArgumentException("username ou senha incorretos");
                
                ValidarTexto(tabela.DsUsername);
                ValidarTexto(tabela.DsSenha);
                
        }
        public void VerificarCarro(string carro)
        {
            ValidarTexto(carro);
        }
        public void ValidarAgendamento(Models.TbAgendamento tb)
        {
            ValidarId(tb.IdCliente);
            ValidarId(tb.IdFuncionario);
            Data(tb.DtAgendamento);
        }
        public void ValidarFeedBack(decimal feedback,int id)
        {
            ValidarId(id);
            ValidarNota(feedback);
        }
        private void ValidarNota(decimal feedback)
        {
            if(feedback<0||feedback>10)
                throw new ArgumentException("Feedback deve ser entre 0 e 10");
        }

        private void Data(DateTime? data)
        {
                if(data==new DateTime()||data<=DateTime.Now)
                throw new ArgumentException("Essa Data ja passou");

                if(data.Value.DayOfWeek==DayOfWeek.Saturday||
                data.Value.DayOfWeek==DayOfWeek.Sunday)
                        throw new  ArgumentException("Não atendemos aos finais de semana");
                 if(data.Value.Hour<8||data.Value.Hour>16)
                    throw new ArgumentException("Não atendemos nesse horario");       
        }

        private void ValidarTexto(string texto)
        {
              if(string.IsNullOrEmpty(texto))
                throw new ArgumentException("campo obrigatorio");
                
        }
        private void ValidarId(int? id)
        {
            if(id<=0)
            throw new ArgumentException("id invalido");
        }

    }
}