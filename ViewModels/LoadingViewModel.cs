using PlanA.Models;

namespace PlanA.ViewModels;

public class LoadingViewModel {
	public string Name { get; set; }
	public List<SelectedOrdersViewModel> SelectedOrders { get; set; } = new ();
}

public class SelectedOrdersViewModel {
	public int Id { get; set; }
	public string Name { get; set; }
	public int Quantity { get; set; }
	public bool IsSelected { get; set; }
};