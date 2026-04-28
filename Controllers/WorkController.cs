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
    
    [HttpGet]
    public async Task<IActionResult> GetTableData()
    {
        var Orders = await _db.Orders.ToListAsync();
        return Json(Orders);
    }

    [HttpGet]
    public async Task<IActionResult> GetAvailableProducts()
    {
        var Products = await _db.Assets.Include(i => i.Item).ToListAsync();
        return Json(Products);
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