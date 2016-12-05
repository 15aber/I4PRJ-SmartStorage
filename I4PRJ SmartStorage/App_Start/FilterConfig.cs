using System;
using System.Configuration;
using System.Web.Mvc;

namespace I4PRJ_SmartStorage
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new RequireHttpsAttribute());
            if(Convert.ToBoolean(ConfigurationManager.AppSettings["AuthorizeAttribute"]))
                filters.Add(new AuthorizeAttribute());
        }
    }
}