using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace backend.Models
{
    public partial class TestDriveContext : DbContext
    {
        public TestDriveContext()
        {
        }

        public TestDriveContext(DbContextOptions<TestDriveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAgendamento> TbAgendamento { get; set; }
        public virtual DbSet<TbCarro> TbCarro { get; set; }
        public virtual DbSet<TbCliente> TbCliente { get; set; }
        public virtual DbSet<TbFuncionario> TbFuncionario { get; set; }
        public virtual DbSet<TbLogin> TbLogin { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user id=root;password=1234;database=TestDrive", x => x.ServerVersion("5.7.30-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAgendamento>(entity =>
            {
                entity.HasKey(e => e.IdAgendamento)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdCarro)
                    .HasName("id_carro");

                entity.HasIndex(e => e.IdCliente)
                    .HasName("id_cliente");

                entity.HasIndex(e => e.IdFuncionario)
                    .HasName("id_funcionario");

                entity.Property(e => e.DsSituacao)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdCarroNavigation)
                    .WithMany(p => p.TbAgendamento)
                    .HasForeignKey(d => d.IdCarro)
                    .HasConstraintName("tb_agendamento_ibfk_3");

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.TbAgendamento)
                    .HasForeignKey(d => d.IdCliente)
                    .HasConstraintName("tb_agendamento_ibfk_1");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.TbAgendamento)
                    .HasForeignKey(d => d.IdFuncionario)
                    .HasConstraintName("tb_agendamento_ibfk_2");
            });

            modelBuilder.Entity<TbCarro>(entity =>
            {
                entity.HasKey(e => e.IdCarro)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsMarca)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DsModelo)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DsPlaca)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            modelBuilder.Entity<TbCliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdLogin)
                    .HasName("id_login");

                entity.Property(e => e.DsCarteiraMotorista)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DsCelular)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DsCep)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DsCidade)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DsCpf)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DsEmail)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DsEndereco)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DsEstado)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DsNumeroEndereco)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DsRg)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DsSexo)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NmCliente)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NmClienteSobrenome)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.TbCliente)
                    .HasForeignKey(d => d.IdLogin)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_cliente_ibfk_1");
            });

            modelBuilder.Entity<TbFuncionario>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario)
                    .HasName("PRIMARY");

                entity.HasIndex(e => e.IdLogin)
                    .HasName("id_login");

                entity.Property(e => e.DsCarteiraTrabalho)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DsEmail)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.NmFuncionario)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.HasOne(d => d.IdLoginNavigation)
                    .WithMany(p => p.TbFuncionario)
                    .HasForeignKey(d => d.IdLogin)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("tb_funcionario_ibfk_1");
            });

            modelBuilder.Entity<TbLogin>(entity =>
            {
                entity.HasKey(e => e.IdLogin)
                    .HasName("PRIMARY");

                entity.Property(e => e.DsPerfil)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DsSenha)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");

                entity.Property(e => e.DsUsername)
                    .HasCharSet("latin1")
                    .HasCollation("latin1_swedish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
