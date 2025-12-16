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
    public async Task<IActionResult> CreateAsset(Asset asset, Item item)
    {
        db.Assets.Add(asset);
        await db.SaveChangesAsync();
        return RedirectToAction("AssetsView");
    }
    public async Task<IActionResult> OrdersView() {
        return View(await db.Orders.Include(oi => oi.OrderItems).ThenInclude(i => i.Item).ToListAsync());
    }

    public IActionResult CreateOrder() {
        List<OrdersItem> ordersItems = db.Assets.Select(a => new OrdersItem ( a.Id, a.Item )).ToList();
        OrderViewModel orderViewModel = new () {
            Items = ordersItems,
            Orders = Orders
        };
        return View(orderViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrder(Order order)
    {
        db.Orders.Add(order);
        await db.SaveChangesAsync();
        return RedirectToAction("OrdersView");
    }
}