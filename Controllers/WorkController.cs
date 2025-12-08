using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanA.Context;
using PlanA.Models;

namespace PlanA.Controllers;

public class WorkController : Controller {
    private readonly ILogger<WorkController> _logger;

    PlanADbContext db;
    /*public WorkController(PlanADbContext context, ILogger<WorkController> logger, PlanADbContext db) {
        db = context;
        _logger = logger;
        this.db = db;
    }
    public WorkController(ILogger<WorkController> logger, PlanADbContext db) {
        _logger = logger;
        this.db = db;
    }*/
    
    public WorkController(PlanADbContext context) {
        db = context;
    }

    public async Task<IActionResult> Assets() {
        return View(await db.Assets.Include(i => i.Item).ToListAsync());
    }

    public IActionResult CreateAsset() {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateAsset(Asset asset, Item item)
    {
        db.Assets.Add(asset);
        await db.SaveChangesAsync();
        return RedirectToAction("Assets");
    }
    public async Task<IActionResult> Orders() {
        return View(await db.Orders.Include(oi => oi.OrderItems).ThenInclude(i => i.Item).ToListAsync());
    }

    public IActionResult CreateOrder() {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrder(Order order, Order_items items)
    {
        db.Orders.Add(order);
        await db.SaveChangesAsync();
        return RedirectToAction("Orders");
    }
}