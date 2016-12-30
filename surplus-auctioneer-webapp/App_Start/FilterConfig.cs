using System.Web;
using System.Web.Mvc;

namespace surplus_auctioneer_webapp
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
