using System.ComponentModel.DataAnnotations;

namespace BikeShop.Models
{
    public class BikeCategories
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;

    }
}
