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
        var orders = await db.Orders.Include(oi => oi.OrderItems).ThenInclude(i => i.Item).ToListAsync();
        
        
        return View(orders);
    }

    public async Task<IActionResult> CreateOrder() {
        var items = await db.Assets.Include(i => i.Item).ToListAsync();
        var view_model = await GetCreateOrderViewModel(); /*new CreateOrderViewModel() {
            SelectedItems = items.Select(i => new SelectedItemViewModel {
                Id = i.Id,
                Name = i.Item.Name,
                Quantity = 1,
                IsSelected = false
            }).ToList()
    };*/
        return View(view_model);
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    /*public async Task<IActionResult> CreateOrder(CreateOrderViewModel viewModel)
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
    }*/
    public async Task<IActionResult> CreateOrder(OrderViewModel viewModel) {
        if (ModelState.IsValid) {
            try {
                var selectedItems = viewModel.SelectedItems
                    .Where(si => si.IsSelected && si.Quantity > 0)
                    .ToList();
                if (!selectedItems.Any()) {
                    ModelState.AddModelError("", "Выберите хотя бы один товар с количеством больше 0");
                    viewModel = await GetCreateOrderViewModel(viewModel);
                    return View(viewModel);
                }
                var order = new Order {
                    Name = viewModel.Name,
                    
                };
                foreach (var selectedItem in selectedItems) {
                    var item = await db.Assets.FindAsync(selectedItem.Id);
                    if (item == null) {
                        ModelState.AddModelError("", $"Товар с ID {selectedItem.Id} не найден");
                        viewModel = await GetCreateOrderViewModel(viewModel);
                        return View(viewModel);
                    }
                    if (item.Quantity < selectedItem.Quantity) {
                        ModelState.AddModelError("", 
                            $"Недостаточно товара '{item.Item.Name}' на складе. Доступно: {item.Quantity}");
                        viewModel = await GetCreateOrderViewModel(viewModel);
                        return View(viewModel);
                    }
                    var orderItem = new Order_items() {
                        ItemId = selectedItem.Id,
                        Quantity = selectedItem.Quantity,
                        Order = order
                    };
                    item.Quantity -= selectedItem.Quantity;
                    order.OrderItems.Add(orderItem);
                }
                db.Orders.Add(order);
                await db.SaveChangesAsync();
                return RedirectToAction("OrderDetails", new { id = order.Id });
            }
            catch (Exception ex) {
                ModelState.AddModelError("", $"Ошибка при сохранении заказа: {ex.Message}");
                viewModel = await GetCreateOrderViewModel(viewModel);
                return View(viewModel);
            }
        }
        viewModel = await GetCreateOrderViewModel(viewModel);
        return View(viewModel);
    }
    private async Task<OrderViewModel> GetCreateOrderViewModel(OrderViewModel existingViewModel = null) {
        var items = await db.Assets.ToListAsync();
        var viewModel = existingViewModel ?? new OrderViewModel();
        if (viewModel.SelectedItems == null || !viewModel.SelectedItems.Any()) {
            viewModel.SelectedItems = items.Select(i => new SelectedItemViewModel {
                Id = i.Id,
                Name = i.Item.Name,
                Quantity = 0,
                IsSelected = false
            }).ToList();
        }
        else {
            foreach (var selectedItem in viewModel.SelectedItems) {
                var item = items.FirstOrDefault(i => i.Id == selectedItem.Id);
                if (item != null) {
                    selectedItem.Name = item.Item.Name;
                }
            }
        }
        
        return viewModel;
    }
    public async Task<IActionResult> OrderDetails(int id) {
        var order = await db.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Item)
            .FirstOrDefaultAsync(o => o.Id == id);
        if (order == null) {
            return NotFound();
        }

        return View(order);
    }
    public async Task<IActionResult> OrdersList() {
        var orders = await db.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Item)
            .ToListAsync();
        return View(orders);
    }
    
    public async Task<IActionResult> OperationsView() {
        return View(await db.Operations.ToListAsync());
    }

    public IActionResult CreateOperation() {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateOperation(Operation oper) {
        db.Operations.Add(oper);
        await db.SaveChangesAsync();
        return RedirectToAction("OperationsView");
    }
    
    public async Task<IActionResult> ProcessesView() {
        return View(await db.Processes.ToListAsync());
    }
    
    public async Task<IActionResult> LoadingView() {
        var orders = await db.Orders
            .Where(o => o.IsActive == true)
            .ToListAsync();
        return View(orders);
    }
    
    public async Task<IActionResult> EmployeesView() {
        return View(await db.Employees.Include(i => i.Person).ToListAsync());
    }

    public IActionResult CreateEmployee() {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateEmployee(Employee employee) {
        db.Employees.Add(employee);
        await db.SaveChangesAsync();
        return RedirectToAction("EmployeesView");
    }
    
    public async Task<IActionResult> EquipmentsView() {
        return View(await db.Equipments.ToListAsync());
    }

    public IActionResult CreateEquipment() {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateEquipment(Equipment equipment) {
        db.Equipments.Add(equipment);
        await db.SaveChangesAsync();
        return RedirectToAction("EquipmentsView");
    }
}