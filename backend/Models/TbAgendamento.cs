using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_agendamento")]
    public partial class TbAgendamento
    {
        [Key]
        [Column("id_agendamento", TypeName = "int(11)")]
        public int IdAgendamento { get; set; }
        [Column("ds_carro", TypeName = "varchar(255)")]
        public string DsCarro { get; set; }
        [Column("dt_agendamento", TypeName = "date")]
        public DateTime? DtAgendamento { get; set; }
        [Column("hr_agendamento", TypeName = "time")]
        public TimeSpan? HrAgendamento { get; set; }
        [Column("ds_situacao", TypeName = "varchar(255)")]
        public string DsSituacao { get; set; }
        [Column("id_cliente", TypeName = "int(11)")]
        public int? IdCliente { get; set; }
        [Column("id_funcionario", TypeName = "int(11)")]
        public int? IdFuncionario { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(TbCliente.TbAgendamento))]
        public virtual TbCliente IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdFuncionario))]
        [InverseProperty(nameof(TbFuncionario.TbAgendamento))]
        public virtual TbFuncionario IdFuncionarioNavigation { get; set; }
    }
}
