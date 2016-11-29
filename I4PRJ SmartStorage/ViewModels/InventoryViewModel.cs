using System;
using System.Collections.Generic;
using System.Linq;
using I4PRJ_SmartStorage.Models.Domain;

namespace I4PRJ_SmartStorage.ViewModels
{
    public class InventoryViewModel
    {
        public List<Inventory> Inventories { get; set; }
        public Inventory Inventory { get; set; }
    }
}