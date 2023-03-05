using Auction_House.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auction_House.Controllers
{
    public class ItemController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ItemController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;

        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var items = _context.Items.ToList();

            return View(items);
        }


        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                _context.SaveChanges();

                return RedirectToAction("Details", new { id = item.Id });
            }

            return View(item);
        }


        [Authorize]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Update(item);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(item);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Details(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);

            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Item item)
        {
            _context.Remove(item);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public IActionResult Search(string searchString)
        {
            var items = from i in _context.Items
                        select i;

            if (!string.IsNullOrEmpty(searchString))
            {
                items = items.Where(s => s.Name.Contains(searchString) || s.Description.Contains(searchString) || s.ItemCondition.Equals(searchString) || s.ItemCategory.Equals(searchString));
            }



            return View(items.ToList());
        }

        [AllowAnonymous]
        public IActionResult SearchResults(string searchString, List<Item> items)
        {
            ViewData["Title"] = "Search Results";
            ViewData["SearchString"] = searchString;

            return View(items);
        }



    }
}
