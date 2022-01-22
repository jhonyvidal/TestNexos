
namespace Datos
{
    using Microsoft.EntityFrameworkCore;
    using System;

    class RHcontext
    {
        public GestionHumanaContext CrearContext()
        {
            var options = new DbContextOptionsBuilder<GestionHumanaContext>()
            .UseSqlServer(@"data source=192.168.93.193,1433\\SQLEXPRESS;initial catalog=PruebaSD;user id=sa;password=JXPr3ns42021;persist security info=True;")
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


            modelBuilder.ApplyConfiguration(new usuarioMap());


        }
        //FIN MAPEO

        internal static object createDbContext()
        {
            throw new NotImplementedException();
        }
        
        //INICIO ENTIDADES
        public virtual DbSet<Usuario> Usuario { get; set; }

        //FIN ENTIDADES
    }
}
