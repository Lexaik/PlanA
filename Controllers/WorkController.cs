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
        var Orders = await _db.orders.ToListAsync();
        return Json(Orders);
    }

    [HttpGet]
    public async Task<IActionResult> GetAvailableProducts()
    {
        var Products = await _db.assets.Include(i => i.Item).ToListAsync();
        return Json(Products);
    }

    public async Task<IActionResult> AssetsView() {
        return View(await _db.assets.Include(i => i.Item).ToListAsync());
    }

    public IActionResult CreateAsset() {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsset(Asset asset, Item item) {
        _db.assets.Add(asset);
        await _db.SaveChangesAsync();
        return RedirectToAction("AssetsView");
    }
    
    public async Task<IActionResult> OrdersView() {
        return View(await _db.orders.ToListAsync());
    }

    
    
    
    public async Task<IActionResult> OperationsView() {
        return View(await _db.operations.ToListAsync());
    }

    public IActionResult CreateOperation() {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateOperation(Operation oper) {
        _db.operations.Add(oper);
        await _db.SaveChangesAsync();
        return RedirectToAction("OperationsView");
    }
    public IActionResult EditOperation(Guid id) {
        var operation = _db.operations.Find(id);
        if (operation == null)
            return NotFound();
        return View(operation);
    }
    
    public async Task<IActionResult> ProcessesView() {
        return View(await _db.processes.ToListAsync());
    }
    
    public async Task<IActionResult> LoadingView() {
        var orders = await _db.orders
            .Where(o => o.IsActive == true)
            .ToListAsync();
        return View(orders);
    }
    
    public async Task<IActionResult> EmployeesView() {
        return View(await _db.employees.Include(i => i.Person).ToListAsync());
    }

    public IActionResult CreateEmployee() {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateEmployee(Employee employee) {
        _db.employees.Add(employee);
        await _db.SaveChangesAsync();
        return RedirectToAction("EmployeesView");
    }
    
    public async Task<IActionResult> EquipmentsView() {
        return View(await _db.equipments.ToListAsync());
    }

    public IActionResult CreateEquipment() {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateEquipment(Equipment equipment) {
        _db.equipments.Add(equipment);
        await _db.SaveChangesAsync();
        return RedirectToAction("EquipmentsView");
    }
}