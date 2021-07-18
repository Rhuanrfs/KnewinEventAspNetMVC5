using System.Web;
using System.Web.Mvc;

namespace KnewinEventAspNetMvc5.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
