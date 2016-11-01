using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace I4PRJ_SmartStorage.Helpers
{
    public static class CacheExtensions
    {
        public static bool IsModified(this Controller controller, DateTime updatedAt)
        {
            var headerValue = controller.Request.Headers["If-Modified-Since"];
            if (headerValue != null)
            {
                var modifiedSince = DateTime.Parse(headerValue).ToLocalTime();
                if (modifiedSince >= updatedAt)
                {
                    return false;
                }
            }

            return true;
        }

        public static ActionResult NotModified(this Controller controller)
        {
            return new HttpStatusCodeResult(304, "Page has not been modified");
        }
    }
}