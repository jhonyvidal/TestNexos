
namespace Datos
{
    using Microsoft.EntityFrameworkCore;
    using System;

    class RHcontext
    {
        public GestionHumanaContext CrearContext()
        {
            var options = new DbContextOptionsBuilder<GestionHumanaContext>()
            .UseSqlServer(@"data source=192.168.93.193,1433\\SQLEXPRESS;initial catalog=TestNexos;user id=sa;password=JXPr3ns42021;persist security info=True;")
            .Options;
            return  new GestionHumanaContext(options);
        }

    }
    public partial class GestionHumanaContext : DbContext
    {
        //public GestionHumanaContext(DbContextOptions<GestionHumanaContext> options) : base(options)
        //    {
        //    }
        public GestionHumanaContext(DbContextOptions options) : base(options)
        {
        }
        //INICIO MAPEO
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.ApplyConfiguration(new autorMap());
            modelBuilder.ApplyConfiguration(new editorialMap());
            modelBuilder.ApplyConfiguration(new libroMap());


        }
        //FIN MAPEO

        internal static object createDbContext()
        {
            throw new NotImplementedException();
        }
        
        //INICIO ENTIDADES

        public virtual DbSet<Autor> Autor { get; set; }
        public virtual DbSet<Editorial> Editorial { get; set; }
        public virtual DbSet<Libro> Libro { get; set; }

        //FIN ENTIDADES
    }
}
