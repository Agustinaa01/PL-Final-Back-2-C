

using Agenda_Tup_Back.Entities;
using Agenda_Tup_Back.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace Agenda_Tup_Back.Data
{
    public class AgendaApiContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public AgendaApiContext(DbContextOptions<AgendaApiContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Crear instancias de Productos con Ids únicos
            Producto Computadoras = new Producto()
            {
                Id = 1,
                Name = "Computadora",
                Price = 1515,
                Description = "gagagagab",
                Category = "Computadora",
                Brand = "HP",
                ImageUrl = "url_de_la_imagen",
            };

            Producto Auriculares = new Producto()
            {
                Id = 2,
                Name = "Auriculares",
                Price = 1545,
                Description = "gagagagab",
                Category = "Auriculares",
                Brand = "HP",
                ImageUrl = "url_de_la_imagen",
            };

            // Crear instancias de Usuarios
            User Erica = new User()
            {
                Id = 1,
                Name = "Erica",
                Password = "123abc",
                Email = "ericaGomez@gmail.com",
                Rol = Rol.Admin,
            };

            User Dana = new User()
            {
                Id = 2,
                Name = "Dana",
                Password = "456def",
                Email = "danaMolina@gmail.com",
            };

            // Crear instancias de Pedidos
            Pedido Familia = new Pedido()
            {
                Id = 1,
                Date = "Familia",
                State = "Reunión familiar",
                UserId = 2,
            };

            Pedido Amigos = new Pedido()
            {
                Id = 2,
                Date = "Amigos",
                State = "Clases de Matemática a las 17:30hs",
                UserId = 1,
            };

            // Agregar entidades al modelo (sin relaciones)
            modelBuilder.Entity<Producto>().HasData(Computadoras, Auriculares);
            modelBuilder.Entity<User>().HasData(Dana, Erica);
            modelBuilder.Entity<Pedido>().HasData(Familia, Amigos);

            // Configurar las relaciones después de agregar las entidades
            modelBuilder.Entity<Pedido>()
                .HasOne(p => p.User)
                .WithMany(u => u.Pedido)
                .HasForeignKey(p => p.UserId);

            base.OnModelCreating(modelBuilder);
        }

    }
}