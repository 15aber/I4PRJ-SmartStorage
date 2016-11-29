using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace I4PRJ_SmartStorage.Dtos
{
    public class NewStatusDto
    {
        public List<double> Quantities { get; set; }
        public int InventoryId { get; set; }
        public List<double> Differences { get; set; }
        public List<int> ProductIds { get; set; }
        public bool IsStarted { get; set; }
    }
}