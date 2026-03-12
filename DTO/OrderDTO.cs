using PlanA.Models;

namespace PlanA.DTO;

public class OrderDTO {
	public List<Order> Orders { get; set; }
	public List<Asset> Assets { get; set; }
}