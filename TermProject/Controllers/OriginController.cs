﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TermProject.Models;

namespace TermProject.Controllers
{
    public class OriginController : Controller
    {
        private readonly DogContext _context;

        public OriginController(DogContext context)
        {
            _context = context;
        }

        // GET: Origin
        public async Task<IActionResult> Index()
        {
            return View(await _context.Origins.ToListAsync());
        }

        // GET: Origin/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var origin = await _context.Origins
                .FirstOrDefaultAsync(m => m.OriginId == id);
            if (origin == null)
            {
                return NotFound();
            }

            return View(origin);
        }

        // GET: Origin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Origin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OriginId,Planet")] Origin origin)
        {
            if (ModelState.IsValid)
            {
                _context.Add(origin);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(origin);
        }

        // GET: Origin/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var origin = await _context.Origins.FindAsync(id);
            if (origin == null)
            {
                return NotFound();
            }
            return View(origin);
        }

        // POST: Origin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("OriginId,Planet")] Origin origin)
        {
            if (id != origin.OriginId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(origin);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OriginExists(origin.OriginId))
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
            return View(origin);
        }

        // GET: Origin/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var origin = await _context.Origins
                .FirstOrDefaultAsync(m => m.OriginId == id);
            if (origin == null)
            {
                return NotFound();
            }

            return View(origin);
        }

        // POST: Origin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var origin = await _context.Origins.FindAsync(id);
            _context.Origins.Remove(origin);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OriginExists(string id)
        {
            return _context.Origins.Any(e => e.OriginId == id);
        }
    }
}
