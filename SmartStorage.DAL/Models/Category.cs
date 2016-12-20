using System;
using System.ComponentModel.DataAnnotations;

namespace SmartStorage.DAL.Models
{
  public class Category
  {
    [Key]
    public int CategoryId { get; set; }

    [Required]
    [StringLength(256)]
    public string Name { get; set; }

    public DateTime? Updated { get; set; }

    [StringLength(256)]
    public string ByUser { get; set; }

    public bool IsDeleted { get; set; }
  }
}