using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_funcionario")]
    public partial class TbFuncionario
    {
        public TbFuncionario()
        {
            TbAgendamento = new HashSet<TbAgendamento>();
        }

        [Key]
        [Column("id_funcionario", TypeName = "int(11)")]
        public int IdFuncionario { get; set; }
        [Column("ds_carteira_trabalho", TypeName = "varchar(50)")]
        public string DsCarteiraTrabalho { get; set; }
        [Column("nm_funcionario", TypeName = "varchar(255)")]
        public string NmFuncionario { get; set; }
        [Column("ds_email", TypeName = "varchar(255)")]
        public string DsEmail { get; set; }
        [Column("dt_nascimento", TypeName = "date")]
        public DateTime? DtNascimento { get; set; }
        [Column("id_login", TypeName = "int(11)")]
        public int? IdLogin { get; set; }

        [ForeignKey(nameof(IdLogin))]
        [InverseProperty(nameof(TbLogin.TbFuncionario))]
        public virtual TbLogin IdLoginNavigation { get; set; }
        [InverseProperty("IdFuncionarioNavigation")]
        public virtual ICollection<TbAgendamento> TbAgendamento { get; set; }
    }
}
