using System.ComponentModel;

namespace JewelleryShop.Models
{
    public class Order
    {
        [DisplayName("Идентификатор")]
        public int Id { get; set; }
        [DisplayName("купувач")]
        public ApplicationUser Buyer { get; set; }
        [DisplayName("продукти")]
        public ICollection<OrderProduct> Products { get; set; }
        [DisplayName("дата на създаване")]
        public DateTime CreatedDate { get; set; }

        public string getProductsString()
        {
            string x = "";
            foreach (var p in Products)
            {
                x += p.Id;
                x += ",";
            }
            return x;
        }
    }
}
