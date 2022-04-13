using CarPartsShop.Models;

namespace CarPartsShop.Views.Home
{
    public class PartsViewModel
    {
        public List<Part>? parts { get; set; }

        public PartsViewModel (List<Part> parts)
        {
            this.parts = parts;
        }
        public List<Part> getParts()
        {
            if (parts == null)
            {
                return new List<Part>();
            }
            return parts;
        }
    }
}
