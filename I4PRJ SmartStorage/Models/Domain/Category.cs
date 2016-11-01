using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace I4PRJ_SmartStorage.Models.Domain
{
    public class Category
    {
        [Key]
        [DisplayName("#")]
        public int CategoryId { get; set; }

        [Required]
        [DisplayName("Category")]
        public string Name { get; set; }

        [DisplayName("Updated")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:G}")]
        [Editable(false)]
        public DateTime Updated { get; set; }

        [DisplayName("By")]
        [Editable(false)]
        public string ByUser { get; set; }

        //[Timestamp]
        //[HiddenInput(DisplayValue = false)]
        //public byte[] Version { get; set; }
    }
}