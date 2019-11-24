using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestAPP1.Data;
using TestAPP1.Models;

namespace TestAPP1.Controllers
{
    public class BmisController : Controller
    {
        private readonly TestDbContext _context;

        public BmisController(TestDbContext context)
        {
            _context = context;
        }

        // GET: Bmis
        public async Task<IActionResult> Index()
        {
            return View(await _context.bmis.ToListAsync());
        }

        // GET: Bmis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bmi = await _context.bmis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bmi == null)
            {
                return NotFound();
            }

            return View(bmi);
        }

        // GET: Bmis/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bmis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,age,weight")] Bmi bmi)
        {

            
            if (ModelState.IsValid)
            {
                
                Bmi bmi1 = bmi;
                bmi.bmi = bmi1.age *bmi1.weight/1000;



                _context.Add(bmi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bmi);
        }

        // GET: Bmis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bmi = await _context.bmis.FindAsync(id);
            if (bmi == null)
            {
                return NotFound();
            }
            return View(bmi);
        }

        // POST: Bmis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,age,weight,bmi")] Bmi bmi)
        {
            if (id != bmi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bmi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BmiExists(bmi.Id))
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
            return View(bmi);
        }

        // GET: Bmis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bmi = await _context.bmis
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bmi == null)
            {
                return NotFound();
            }

            return View(bmi);
        }

        // POST: Bmis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bmi = await _context.bmis.FindAsync(id);
            _context.bmis.Remove(bmi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BmiExists(int id)
        {
            return _context.bmis.Any(e => e.Id == id);
        }
    }
}
