using RealEstateShop.Models;

namespace RealEstateShop.Views.Home
{
    public class Properties
    {
        public List<Property>? parts { get; set; }

        public Properties(List<Property> parts)
        {
            this.parts = parts;
        }
        public List<Property> getProperties()
        {
            if (parts == null)
            {
                return new List<Property>();
            }
            return parts;
        }
    }
}
