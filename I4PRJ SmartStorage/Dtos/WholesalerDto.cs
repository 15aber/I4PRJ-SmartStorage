using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace I4PRJ_SmartStorage.Dtos
{
    public class WholesalerDto
    {
        public int WholesalerId { get; set; }

        public string Name { get; set; }

        public DateTime Updated { get; set; }

        public string ByUser { get; set; }

        public bool IsDeleted { get; set; }
    }
}