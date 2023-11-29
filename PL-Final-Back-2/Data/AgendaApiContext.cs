using Agenda_Tup_Back.Entities;
using Agenda_Tup_Back.Models.Enum;
using Microsoft.EntityFrameworkCore;

public class AgendaApiContext : DbContext
{
    public DbSet<User> User { get; set; }
    public DbSet<Producto> Producto { get; set; }
    public DbSet<Pedido> Pedido { get; set; }
    public DbSet<PedidoProducto> PedidoProductos { get; set; }

    public AgendaApiContext(DbContextOptions<AgendaApiContext> options) : base(options)
    {
        this.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
        new User { Id = 1, Name = "Erica", Password = "123abc", Email = "ericaGomez@gmail.com", Rol = Rol.Admin },
        new User { Id = 2, Name = "Dana", Password = "456def", Email = "danaMolina@gmail.com" },
        new User { Id = 3, Name = "Agus", Password = "user123", Email = "agus@back.com", Rol = Rol.SuperAdmin },
        new User { Id = 4, Name = "Bren", Password = "user123", Email = "bren@back.com", Rol = Rol.SuperAdmin },
        new User { Id = 5, Name = "Lucho", Password = "user123", Email = "lucho@back.com", Rol = Rol.SuperAdmin }
    );

        modelBuilder.Entity<Pedido>().HasData(
            new Pedido { Id = 1, Date = new DateTime(2023, 11, 10), State = "Shipping", UserId = 3 },
            new Pedido { Id = 2, Date = new DateTime(2023, 11, 22), State = "Delivered", UserId = 3 }
        );

        modelBuilder.Entity<Producto>().HasData(
            new Producto { Id = 1, Name = "Computadora", Price = 1515, Description = "gagagagab", Category = "Computadora", Brand = "HP", ImageUrl = "https://i.pinimg.com/564x/5a/62/1e/5a621e11a8cc9fd152d6805cd5f67724.jpg" },
            new Producto { Id = 2, Name = "Auriculares", Price = 1545, Description = "gagagagab", Category = "Auriculares", Brand = "HP", ImageUrl = "https://i.pinimg.com/564x/f2/99/42/f29942dc13ba97a29d27ff47f83ec36e.jpg" }
        );

        modelBuilder.Entity<PedidoProducto>().HasData(
            new PedidoProducto { PedidoId = 1, ProductoId = 1 },
            new PedidoProducto { PedidoId = 1, ProductoId = 2 },
            new PedidoProducto { PedidoId = 2, ProductoId = 1 },
            new PedidoProducto { PedidoId = 2, ProductoId = 2 }
        );
        modelBuilder.Entity<PedidoProducto>()
    .HasKey(pp => new { pp.PedidoId, pp.ProductoId });
        modelBuilder.Entity<PedidoProducto>()
            .HasOne(pp => pp.Pedido)
            .WithMany(p => p.PedidoProductos)
            .HasForeignKey(pp => pp.PedidoId)
            .OnDelete(DeleteBehavior.Restrict);
        modelBuilder.Entity<PedidoProducto>()
            .HasOne(pp => pp.Producto)
            .WithMany(p => p.PedidoProductos)
            .HasForeignKey(pp => pp.ProductoId);
        base.OnModelCreating(modelBuilder);
    }
}
