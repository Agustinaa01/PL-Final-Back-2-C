

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

            User Agus = new User()
            {
                Id = 3,
                Name = "Agus",
                Password = "user123",
                Email = "agus@back.com",
                Rol = Rol.SuperAdmin,
            };
            User Bren = new User()
            {
                Id = 4,
                Name = "Bren",
                Password = "user123",
                Email = "bren@back.com",
                Rol = Rol.SuperAdmin,
            };
            User Lucho = new User()
            {
                Id = 5,
                Name = "Lucho",
                Password = "user123",
                Email = "lucho@back.com",
                Rol = Rol.SuperAdmin,
            };
            Pedido PedidoUser1 = new Pedido()
            {
                Id = 1,
                Date = new DateTime(2023, 11, 10),
                State = "Shipping",
                UserId = Dana.Id,
                //Producto = new List<Producto>(),
            };

            Pedido PedidoUser2= new Pedido()
            {
                Id = 2,
                Date = new DateTime(2023, 11, 22),
                State = "Delivered",
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
            modelBuilder.Entity<User>().HasData(Erica, Dana, Agus, Bren, Lucho);
            modelBuilder.Entity<Pedido>().HasData(PedidoUser1, PedidoUser2);
            modelBuilder.Entity<Producto>().HasData(Computadoras, Auriculares);

            modelBuilder.Entity<User>().HasMany(u => u.Pedido).WithOne(p => p.User);
            modelBuilder.Entity<Pedido>().HasMany(p => p.Producto).WithOne(pr => pr.Pedido).IsRequired(false);

            base.OnModelCreating(modelBuilder);
        }


    }
}