using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanA.Context;
using PlanA.DTO;
using PlanA.Models;
using PlanA.ViewModels;

namespace PlanA.Controllers;

public class WorkController : Controller {
    private readonly ILogger<WorkController> _logger;

    PlanADbContext _db;
    
    public WorkController(PlanADbContext context) {
        _db = context;
    }

    public async Task<IActionResult> AssetsView() {
        return View(await _db.Assets.Include(i => i.Item).ToListAsync());
    }

    public IActionResult CreateAsset() {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsset(Asset asset, Item item) {
        _db.Assets.Add(asset);
        await _db.SaveChangesAsync();
        return RedirectToAction("AssetsView");
    }
    
    public async Task<IActionResult> OrdersView() {
        var model = new OrderDto {
            Orders = await _db.Orders.ToListAsync(),
            Assets = await _db.Assets.ToListAsync()
        };
        return View(model);
    }

    public async Task<IActionResult> CreateOrder() {
        var items = await _db.Assets.Include(i => i.Item).ToListAsync();
        var viewModel = await GetCreateOrderViewModel(); /*new CreateOrderViewModel() {
            SelectedItems = items.Select(i => new SelectedItemViewModel {
                Id = i.Id,
                Name = i.Item.Name,
                Quantity = 1,
                IsSelected = false
            }).ToList()
    };*/
        return View(viewModel);
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
                    var item = await _db.Assets.FindAsync(selectedItem.Id);
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
                    var orderItem = new OrderItems() {
                        ItemId = selectedItem.Id,
                        Quantity = selectedItem.Quantity,
                        Order = order
                    };
                    item.Quantity -= selectedItem.Quantity;
                    order.OrderItems.Add(orderItem);
                }
                _db.Orders.Add(order);
                await _db.SaveChangesAsync();
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
        var items = await _db.Assets.ToListAsync();
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
        var order = await _db.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Item)
            .FirstOrDefaultAsync(o => o.Id == id);
        if (order == null) {
            return NotFound();
        }

        return View(order);
    }
    public async Task<IActionResult> OrdersList() {
        var orders = await _db.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Item)
            .ToListAsync();
        return View(orders);
    }
    
    public async Task<IActionResult> OperationsView() {
        return View(await _db.Operations.ToListAsync());
    }

    public IActionResult CreateOperation() {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateOperation(Operation oper) {
        _db.Operations.Add(oper);
        await _db.SaveChangesAsync();
        return RedirectToAction("OperationsView");
    }
    
    public async Task<IActionResult> ProcessesView() {
        return View(await _db.Processes.ToListAsync());
    }
    
    public async Task<IActionResult> LoadingView() {
        var orders = await _db.Orders
            .Where(o => o.IsActive == true)
            .ToListAsync();
        return View(orders);
    }
    
    public async Task<IActionResult> EmployeesView() {
        return View(await _db.Employees.Include(i => i.Person).ToListAsync());
    }

    public IActionResult CreateEmployee() {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateEmployee(Employee employee) {
        _db.Employees.Add(employee);
        await _db.SaveChangesAsync();
        return RedirectToAction("EmployeesView");
    }
    
    public async Task<IActionResult> EquipmentsView() {
        return View(await _db.Equipments.ToListAsync());
    }

    public IActionResult CreateEquipment() {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateEquipment(Equipment equipment) {
        _db.Equipments.Add(equipment);
        await _db.SaveChangesAsync();
        return RedirectToAction("EquipmentsView");
    }
}