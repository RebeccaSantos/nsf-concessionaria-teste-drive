using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_carro")]
    public partial class TbCarro
    {
        public TbCarro()
        {
            TbAgendamento = new HashSet<TbAgendamento>();
        }

        [Key]
        [Column("id_carro", TypeName = "int(11)")]
        public int IdCarro { get; set; }
        [Column("ds_marca", TypeName = "varchar(255)")]
        public string DsMarca { get; set; }
        [Column("ds_modelo", TypeName = "varchar(255)")]
        public string DsModelo { get; set; }
        [Column("nr_ano_fab", TypeName = "int(11)")]
        public int? NrAnoFab { get; set; }
        [Column("nr_ano_model", TypeName = "int(11)")]
        public int? NrAnoModel { get; set; }
        [Column("ds_placa", TypeName = "varchar(255)")]
        public string DsPlaca { get; set; }

        [InverseProperty("IdCarroNavigation")]
        public virtual ICollection<TbAgendamento> TbAgendamento { get; set; }
    }
}
