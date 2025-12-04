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

    public async Task<IActionResult> Index() {
        return View(await db.Assets.Include(i => i.Item).ToListAsync());
    }

    public IActionResult Create() {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Asset asset, Item item)
    {
        db.Assets.Add(asset);
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    
}