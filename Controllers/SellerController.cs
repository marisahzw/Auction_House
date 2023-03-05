using Auction_House.Data.Static;
using Auction_House.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Auction_House.Controllers
{
    [Authorize(Roles = Data.Static.UserRoles.Admin)]
    public class SellerController : Controller
    {
        private readonly AppDbContext _context;

        public SellerController(AppDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var sellers = await _context.Sellers.ToListAsync();
            return View(sellers);
        }

        //Get: Seller/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureURL,Bio")] Seller seller)
        {
            if (!ModelState.IsValid)
            {
                return View(seller);
            }

            _context.Sellers.Add(seller);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Get: Seller/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var seller = await _context.Sellers.FindAsync(id);

            if (seller == null)
            {
                return View("NotFound");
            }

            return View(seller);
        }

        //Get: Seller/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var seller = await _context.Sellers.FindAsync(id);

            if (seller == null)
            {
                return View("NotFound");
            }

            return View(seller);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePictureURL,Bio")] Seller seller)
        {
            if (id != seller.Id)
            {
                return View("NotFound");
            }

            if (!ModelState.IsValid)
            {
                return View(seller);
            }

            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SellerExists(seller.Id))
                {
                    return View("NotFound");
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        //Get: Seller/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var seller = await _context.Sellers.FindAsync(id);

            if (seller == null)
            {
                return View("NotFound");
            }

            return View(seller);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seller = await _context.Sellers.FindAsync(id);

            if (seller == null)
            {
                return View("NotFound");
            }

            _context.Sellers.Remove(seller);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellerExists(int id)
        {
            return _context.Sellers.Any(e => e.Id == id);
        }

        public async Task<IActionResult> Index(string searchString)
        {
            ViewBag.CurrentFilter = searchString;

            var sellers = from s in _context.Sellers
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                sellers = sellers.Where(s => s.FullName.Contains(searchString));
            }

            return View(await sellers.ToListAsync());
        }

    }
}
