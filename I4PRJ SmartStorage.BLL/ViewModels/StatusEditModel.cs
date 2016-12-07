using System.Collections.Generic;

namespace SmartStorage.BLL.ViewModels
{
  public class StatusEditModel
  {
    public List<double> ExpQuantities { get; set; }
    public List<double> CurQuantities { get; set; }
    public int InventoryId { get; set; }
    public List<double> Differences { get; set; }
    public List<int> ProductIds { get; set; }
    public bool IsStarted { get; set; }
  }
}
