
using System;
using System.Collections.Generic;
using GroceryStore.Data;
using GroceryStore.Models;
using Microsoft.AspNetCore.Mvc;
namespace GroceryStore.Controllers;
public class StoreController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    public StoreController(ApplicationDbContext dbContext) {
        _dbContext = dbContext;
    }
    public IActionResult Index()
    {
        IEnumerable<Store> objStoreItems = _dbContext.Stores;
        return View(objStoreItems);
    }
    //GET: Store
    public IActionResult Create()
    {
        return View();
    }
    //POST: Store/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Store obj){
       if (ModelState.IsValid) {
            _dbContext.Stores.Add(obj);
            _dbContext.SaveChanges();
            TempData["success"] = "Store created successfully";
            return RedirectToAction("Index");
    
    }
    return View(obj);
    
}
    //GET: Store
    public IActionResult Edit(int? id)
    {
        if(id == null || id == 0) {
            return NotFound();
        }
        var storeFromDb = _dbContext.Stores.Find(id);
        if(storeFromDb == null) {
            return NotFound();
        }
        return View(storeFromDb);
    }
    //POST: Store/Edit
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Store obj){
        if (ModelState.IsValid) {
            _dbContext.Stores.Update(obj);
            _dbContext.SaveChanges();
            TempData["success"] = "Store updated successfully";
            return RedirectToAction("Index");

        }
        return View(obj);
    }

    public IActionResult Delete(int? id) {
        if (id == null || id == 0) {
            return NotFound();
    }
    var storeFromDb = _dbContext.Stores.Find(id);
    if (storeFromDb == null) {
        return NotFound();
    }
    return View(storeFromDb);
        }
    
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id) {
            var obj = _dbContext.Stores.Find(id);
            if (obj== null) {
                return NotFound();
    
        }
        _dbContext.Stores.Remove(obj);
        _dbContext.SaveChanges();
        TempData["success"] = "Store successfully deleted";
        return RedirectToAction("Index");
    }
    
    
    
    }

