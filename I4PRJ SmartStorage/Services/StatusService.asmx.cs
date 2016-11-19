using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Services;
using I4PRJ_SmartStorage.Models;
using I4PRJ_SmartStorage.Models.Domain;
using Microsoft.Ajax.Utilities;

namespace I4PRJ_SmartStorage
{
    /// <summary>
    /// Summary description for StatusService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class StatusService : System.Web.Services.WebService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [WebMethod]
        public void GetProducts()
        {
            List<Product> products = db.Products.Include(p => p.Category).ToList();

            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Write(js.Serialize(products));
        }
    }
}