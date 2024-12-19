using System.Web;
using System.Web.Mvc;

namespace _1516_ExamenFinal_Grupo7
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
