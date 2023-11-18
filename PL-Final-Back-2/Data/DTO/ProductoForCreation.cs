using System.ComponentModel.DataAnnotations;
using Agenda_Tup_Back.Entities;

namespace Agenda_Tup_Back.DTO
{
    public class ProductoForCreation
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }

        public string ImageUrl { get; set; }
    }
}
