using PlanA.Models;

namespace PlanA.ViewModels;

public class OrderViewModel {
	
	public List<Order> TableOrders { get; set; } = new ();
	public List<Asset> ListAssets { get; set; } = new ();
	public string Name { get; set; }
	public List<SelectedItemViewModel> SelectedItems { get; set; } = new ();
}

public class SelectedItemViewModel {
	public int Id { get; set; }
	public string Name { get; set; }
	public int Quantity { get; set; }
	public bool IsSelected { get; set; }
};