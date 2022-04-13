using ShoeShop.Models;

namespace ShoeShop.Views.Home
{
    public class Offers
    {
        public List<Shoe>? shoes { get; set; }

        public Offers(List<Shoe> shoes)
        {
            this.shoes = shoes;
        }
        public List<Shoe> getShoes()
        {
            if (shoes == null)
            {
                return new List<Shoe>();
            }
            return shoes;
        }
    }
}
