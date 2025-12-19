using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanA.Context;
using PlanA.Models;
using PlanA.ViewModels;

namespace PlanA.Controllers;

public class WorkController : Controller {
    private readonly ILogger<WorkController> _logger;

    PlanADbContext db;
    
    public WorkController(PlanADbContext context) {
        db = context;
    }

    public async Task<IActionResult> AssetsView() {
        return View(await db.Assets.Include(i => i.Item).ToListAsync());
    }

    public IActionResult CreateAsset() {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsset(Asset asset, Item item) {
        db.Assets.Add(asset);
        await db.SaveChangesAsync();
        return RedirectToAction("AssetsView");
    }
    public async Task<IActionResult> OrdersView() {
        return View(await db.Orders.Include(oi => oi.OrderItems).ThenInclude(i => i.Item).ToListAsync());
    }

    public async Task<IActionResult> CreateOrder() {
        var items = await db.Assets.Include(i => i.Item).ToListAsync();
        var view_model = new CreateOrderViewModel() {
            SelectedItems = items.Select(i => new SelectedItemViewModel {
                Id = i.Id,
                Name = i.Item.Name,
                Quantity = 1,
                IsSelected = false
            }).ToList()
        };
        return View(view_model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateOrder(CreateOrderViewModel viewModel)
    {
        if (ModelState.IsValid) {
            try {
                var order = new Order {
                    Name = viewModel.Name
                };
                foreach (var selectedItem in viewModel.SelectedItems) {
                    if (selectedItem.IsSelected && selectedItem.Quantity > 0) {
                        var item = await db.Assets.FindAsync(selectedItem.Id);
                        if (item == null || item.Quantity < selectedItem.Quantity) {
                            ModelState.AddModelError("SelectedItems", $"Item {selectedItem.Name} is not available.");
                            return View(viewModel);
                        }

                        var orderItem = new Order_items {
                            ItemId = selectedItem.Id,
                            Quantity = selectedItem.Quantity,
                            Order = order
                        };
                        item.Quantity -= selectedItem.Quantity;
                        order.OrderItems.Add(orderItem);
                    }
                }

                if (!order.OrderItems.Any()) {
                    ModelState.AddModelError("SelectedItems", "Please select at least one item.");
                    return View(viewModel);
                }

                db.Orders.Add(order);
                await db.SaveChangesAsync();
                return RedirectToAction("OrdersView");
            }
            catch (Exception ex) {
                ModelState.AddModelError("", $"Ошибка при сохранении заказа: {ex.Message}");
            }
        }
        return View(viewModel);
    }
}