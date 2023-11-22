

using Agenda_Tup_Back.Entities;
using Agenda_Tup_Back.Models.Enum;
using Microsoft.EntityFrameworkCore;

namespace Agenda_Tup_Back.Data
{
    public class EcommerceApiContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public EcommerceApiContext(DbContextOptions<EcommerceApiContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            User Ana = new User()
            {
                Id = 3,
                Name = "Ana",
                Password = "456def",
                Email = "anaMolina@gmail.com",
                Rol = Rol.SuperAdmin,
            };

            Pedido Familia = new Pedido()
            {
                Id = 1,
                Date = "Familia",
                State = "Reunión familiar",
                UserId = Dana.Id,
                //Producto = new List<Producto>(),
            };

            Pedido Amigos = new Pedido()
            {
                Id = 2,
                Date = "Amigos",
                State = "Clases de Matemática a las 17:30hs",
                UserId= Erica.Id,
                //Producto = new List<Producto>(),
            };

            Producto Computadoras = new Producto()
            {
                Id = 1,
                Name = "Computadora",
                Price = 1515,
                Description = "gagagagab",
                Category = "Computadora",
                Brand = "HP",
                ImageUrl = "https://i.pinimg.com/564x/5a/62/1e/5a621e11a8cc9fd152d6805cd5f67724.jpg",
            };

            Producto Auriculares = new Producto()
            {
                Id = 2,
                Name = "Auriculares",
                Price = 1545,
                Description = "gagagagab",
                Category = "Auriculares",
                Brand = "HP",
                ImageUrl = "https://i.pinimg.com/564x/f2/99/42/f29942dc13ba97a29d27ff47f83ec36e.jpg",
            };

            
            // Agregar entidades al modelo (sin relaciones)
            modelBuilder.Entity<User>().HasData(Erica, Dana, Ana);
            modelBuilder.Entity<Pedido>().HasData(Familia, Amigos);
            modelBuilder.Entity<Producto>().HasData(Computadoras, Auriculares);

            modelBuilder.Entity<User>().HasMany(u => u.Pedido).WithOne(p => p.User);
            modelBuilder.Entity<Pedido>().HasMany(p => p.Producto).WithOne(pr => pr.Pedido).IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }


    }
}