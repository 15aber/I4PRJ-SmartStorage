using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.ViewModels
{
    public class TransactionViewModel
    {
        public List<Inventory> FromInventory { get; set; }

        public List<Inventory> ToInventory { get; set; }

        public List<Product> Product { get; set; }

        public Transaction Transaction { get; set; }
    }
}