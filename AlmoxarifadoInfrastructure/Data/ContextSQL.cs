using AlmoxarifadoDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace AlmoxarifadoInfrastructure.Data
{
    public  class ContextSQL : DbContext 
    {

        public ContextSQL(DbContextOptions<ContextSQL> options) : base(options)
        {   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da chave primária para a entidade Grupo
            modelBuilder.Entity<Grupo>().HasKey(g => g.ID_GRU);
            modelBuilder.Entity<NOTA_FISCAL>().HasKey(nf => nf.ID_NOTA);
            modelBuilder.Entity<ITENS_NOTA>().HasKey(i => i.ITEM_NUM);
            modelBuilder.Entity<ITENS_REQ>().HasKey(i => i.NUM_ITEM);
            modelBuilder.Entity<REQUISICAO>().HasKey(i => i.ID_REQ);


        }


        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<NOTA_FISCAL> NOTA_FISCAL { get; set; }
        public DbSet<ITENS_NOTA> ITENS_NOTA { get; set; }
        public DbSet<ITENS_REQ> ITENS_REQ { get; set; }
        public DbSet<REQUISICAO> REQUISICAO { get; set; }
    }
}
