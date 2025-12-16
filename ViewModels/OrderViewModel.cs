using PlanA.Models;

namespace PlanA.ViewModels;

public class OrderViewModel {
	public IEnumerable<Order> Orders { get; set; } = new List<Order>();
	public IEnumerable<Item> Items { get; set; } = new List<Item>();
}