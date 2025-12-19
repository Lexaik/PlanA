using PlanA.Models;

namespace PlanA.ViewModels;

public class CreateOrderViewModel {
	public string Name { get; set; }
	public List<SelectedItemViewModel> SelectedItems { get; set; } = new ();
}

public class SelectedItemViewModel {
	public int Id { get; set; }
	public string Name { get; set; }
	public int Quantity { get; set; }
	public bool IsSelected { get; set; }
};