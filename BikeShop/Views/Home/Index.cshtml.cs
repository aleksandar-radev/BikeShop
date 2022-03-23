using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BikeShop.Views.Home
{
    public class IndexModel : PageModel
    {
        public string IndexName { get; set; }
        public IndexModel(string name)
        {
            IndexName = "asdfasdf";
        }

        public void OnGet()
        {

        }
    }
}