using System;
using System.ComponentModel.DataAnnotations;
using SmartStorage.DAL.Interfaces.Models;

namespace SmartStorage.DAL.Models
{
  public class Wholesaler : IWholesaler
  {
    [Key]
    public int WholesalerId { get; set; }

    [Required]
    [StringLength(256)]
    public string Name { get; set; }

    public DateTime? Updated { get; set; }

    [StringLength(256)]
    public string ByUser { get; set; }

    public bool IsDeleted { get; set; }
  }
}