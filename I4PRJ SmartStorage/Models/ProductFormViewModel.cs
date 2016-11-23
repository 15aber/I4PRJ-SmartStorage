﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace I4PRJ_SmartStorage.Models
{
    public class ProductFormViewModel
    {
        //public IEnumerable<Categories> Categories { get; set; }
        public Product Product { get; set; }

        public string Title
        {
            get
            {
                if (Product != null && Product.Id != 0)
                    return "Edit Product";
                return "New Product";
            }
        }
    }
}