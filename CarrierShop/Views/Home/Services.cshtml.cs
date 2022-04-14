using CarrierShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarrierShop.Views.Home
{
    public class ServicesModel : PageModel
    {
        public List<Service> services;

        public ServicesModel(List<Service> services)
        {
            this.services = services;
        }
        public List<Service> getServices()
        {
            return services;
        }
        public Service Find(int n)
        {
            return this.services.SingleOrDefault(x => x.Id == n);
        }
    }
}
    