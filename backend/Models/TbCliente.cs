using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_cliente")]
    public partial class TbCliente
    {
        public TbCliente()
        {
            TbAgendamento = new HashSet<TbAgendamento>();
        }

        [Key]
        [Column("id_cliente", TypeName = "int(11)")]
        public int IdCliente { get; set; }
        [Column("nm_cliente", TypeName = "varchar(255)")]
        public string NmCliente { get; set; }
        [Column("nm_cliente_sobrenome", TypeName = "varchar(255)")]
        public string NmClienteSobrenome { get; set; }
        [Column("ds_cpf", TypeName = "varchar(255)")]
        public string DsCpf { get; set; }
        [Column("ds_rg", TypeName = "varchar(255)")]
        public string DsRg { get; set; }
        [Column("ds_carteira_motorista", TypeName = "varchar(255)")]
        public string DsCarteiraMotorista { get; set; }
        [Column("dt_nascimento", TypeName = "datetime")]
        public DateTime? DtNascimento { get; set; }
        [Column("ds_sexo", TypeName = "varchar(50)")]
        public string DsSexo { get; set; }
        [Column("ds_email", TypeName = "varchar(255)")]
        public string DsEmail { get; set; }
        [Column("ds_celular", TypeName = "varchar(30)")]
        public string DsCelular { get; set; }
        [Column("ds_endereco", TypeName = "varchar(255)")]
        public string DsEndereco { get; set; }
        [Column("ds_cep", TypeName = "varchar(15)")]
        public string DsCep { get; set; }
        [Column("ds_numero_endereco", TypeName = "varchar(25)")]
        public string DsNumeroEndereco { get; set; }
        [Column("ds_estado", TypeName = "varchar(100)")]
        public string DsEstado { get; set; }
        [Column("ds_cidade", TypeName = "varchar(255)")]
        public string DsCidade { get; set; }
        [Column("id_login", TypeName = "int(11)")]
        public int? IdLogin { get; set; }

        [ForeignKey(nameof(IdLogin))]
        [InverseProperty(nameof(TbLogin.TbCliente))]
        public virtual TbLogin IdLoginNavigation { get; set; }
        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<TbAgendamento> TbAgendamento { get; set; }
    }
}
