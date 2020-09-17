using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace backend.Models
{
    [Table("tb_login")]
    public partial class TbLogin
    {
        public TbLogin()
        {
            TbCliente = new HashSet<TbCliente>();
            TbFuncionario = new HashSet<TbFuncionario>();
        }

        [Key]
        [Column("id_login", TypeName = "int(11)")]
        public int IdLogin { get; set; }
        [Required]
        [Column("ds_username", TypeName = "varchar(255)")]
        public string DsUsername { get; set; }
        [Required]
        [Column("ds_senha", TypeName = "varchar(255)")]
        public string DsSenha { get; set; }
        [Required]
        [Column("ds_perfil", TypeName = "varchar(255)")]
        public string DsPerfil { get; set; }

        [InverseProperty("IdLoginNavigation")]
        public virtual ICollection<TbCliente> TbCliente { get; set; }
        [InverseProperty("IdLoginNavigation")]
        public virtual ICollection<TbFuncionario> TbFuncionario { get; set; }
    }
}
