﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Agenda_Tup_Back.Entities
{
    public class Pedido
    {
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Date { get; set; }
        public string State { get; set; }
        public ICollection<Producto> Producto { get; set; } = new List<Producto>();
        //public ICollection<User> User { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
