using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace RealEstateShop.Models
{
    public class Order
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("Дата на създаване")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("купувач")]
        [Required]
        public ApplicationUser? Buyer { get; set; }
        [DisplayName("ид на имот")]
        [Required]
        public int PropertyId { get; set; }
        [DisplayName("имот")]
        public Property? Property { get; set; }

    }
}
