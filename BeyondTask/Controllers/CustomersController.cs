using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeyondTask.Models.Entities;
using BeyondTask.Models.Entities.Models;
using BeyondTask.Models.Contracts;

namespace BeyondTask.Controllers
{
    public class CustomersController : Controller
    {
        List<Gender> genderItems = new List<Gender>()
            {
                new Gender{ Id=1, GenderName = "Male"},
                new Gender{ Id=2, GenderName = "Female"}
            };


        private readonly RepositoryContext _context;

        public CustomersController(RepositoryContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index(string option, string search)
        {
            //if a user choose the radio button option as Subject  
            if (option == "Name")
            {
                //Index action method will return a view with a student records based on what a user specify the value in textbox  
                return View(_context.Customer.Include(c => c.Gender).Where(x => x.Name.StartsWith(search) || search == null).ToList());
            }
            else if (option == "Mail")
            {
                return View(_context.Customer.Include(c => c.Gender).Where(x => x.Email == search || search == null).ToList());
            }
            else if(option == "PhoneNumber")
            {
                return View(_context.Customer.Include(c => c.Gender).Where(x => x.PhoneNumber == search || search == null).ToList());
            }
            var repositoryContext = _context.Customer.Include(c => c.Gender);


            return View(await repositoryContext.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .Include(c => c.Gender)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["GenderId"] = new SelectList(genderItems, "Id", "GenderName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DateOfBirth,GenderId,Address,PhoneNumber,Email,Notes")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenderId"] = new SelectList(genderItems, "Id", "GenderName", customer.GenderId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.SingleOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["GenderId"] = new SelectList(genderItems, "Id", "GenderName", customer.GenderId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,DateOfBirth,GenderId,Address,PhoneNumber,Email,Notes")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["GenderId"] = new SelectList(genderItems, "Id", "GenderName", customer.GenderId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .Include(c => c.Gender)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.SingleOrDefaultAsync(m => m.Id == id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
