using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.ViewModels
{
    public class CategoryViewModel
    {
        public List<Category> Categories { get; set; }
        public Category Category { get; set; }
    }
}