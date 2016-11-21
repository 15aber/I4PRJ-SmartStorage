using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace I4PRJ_SmartStorage.Dtos
{
    public class CategoryDto
    {
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}")]
        [Editable(false)]
        public DateTime Updated { get; set; }

        [Editable(false)]
        public string ByUser { get; set; }

        public bool IsDeleted { get; set; }
    }
}