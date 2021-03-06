﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_agendamento")]
    public partial class TbAgendamento
    {
        [Key]
        [Column("id_agendamento")]
        public int IdAgendamento { get; set; }
        [Column("dt_agendamento", TypeName = "datetime")]
        public DateTime? DtAgendamento { get; set; }
        [Column("ds_situacao", TypeName = "varchar(255)")]
        public string DsSituacao { get; set; }
        [Column("vl_feedback", TypeName = "decimal(5,2)")]
        public decimal? VlFeedback { get; set; }
        [Column("bt_feedback_dado")]
        public bool? BtFeedbackDado { get; set; }
        [Column("id_cliente")]
        public int? IdCliente { get; set; }
        [Column("id_funcionario")]
        public int? IdFuncionario { get; set; }
        [Column("id_carro")]
        public int? IdCarro { get; set; }

        [ForeignKey(nameof(IdCarro))]
        [InverseProperty(nameof(TbCarro.TbAgendamento))]
        public virtual TbCarro IdCarroNavigation { get; set; }
        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(TbCliente.TbAgendamento))]
        public virtual TbCliente IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdFuncionario))]
        [InverseProperty(nameof(TbFuncionario.TbAgendamento))]
        public virtual TbFuncionario IdFuncionarioNavigation { get; set; }
    }
}
