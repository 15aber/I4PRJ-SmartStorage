using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace I4PRJ_SmartStorage.Dtos
{
    public class SupplierDto
    {
        public int SupplierId { get; set; }
        public string Name { get; set; }
        public DateTime Updated { get; set; }
        public string ByUser { get; set; }
        public bool IsDeleted { get; set; }
    }
}