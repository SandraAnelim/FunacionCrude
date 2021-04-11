using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FunacionCrude.Models.DAL;
using FunacionCrude.Models.Entities;

namespace FunacionCrude.Controllers
{
    public class PadrinosController : Controller
    {
        private readonly DbContextFundacion _context;

        public PadrinosController(DbContextFundacion context)
        {
            _context = context;
        }

        // GET: Padrinos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Padrinos.ToListAsync());
        }/*Vista princital, metodo asincronico y tareas*/

        // GET: Padrinos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padrino = await _context.Padrinos
                .FirstOrDefaultAsync(m => m.PadrinoId == id);
            if (padrino == null)
            {
                return NotFound();
            }

            return View(padrino);
        }

        // GET: Padrinos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Padrinos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PadrinoId,Nombre,Correo,Contraseña,Edad,Profesion,UsuarioId,Descripcion")] Padrino padrino)
        {
            var padrinoaTemp = await _context.Padrinos.FirstOrDefaultAsync(p => p.Correo == padrino.Correo);

            if (ModelState.IsValid)
            {
                if(padrinoaTemp == null)
                {
                    _context.Add(padrino);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            
                ViewData["error"] = "El correo se encuentra registrado";
            
            return View(padrino);
        }

        // GET: Padrinos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padrino = await _context.Padrinos.FindAsync(id);
            if (padrino == null)
            {
                return NotFound();
            }
            return View(padrino);
        }

        // POST: Padrinos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PadrinoId,Nombre,Correo,Contraseña,Edad,Profesion,UsuarioId,Descripcion")] Padrino padrino)
        {
            if (id != padrino.PadrinoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(padrino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PadrinoExists(padrino.PadrinoId))
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
            return View(padrino);
        }

        // GET: Padrinos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padrino = await _context.Padrinos
                .FirstOrDefaultAsync(m => m.PadrinoId == id);
            if (padrino == null)
            {
                return NotFound();
            }

            return View(padrino);
        }

        // POST: Padrinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var padrino = await _context.Padrinos.FindAsync(id);
            _context.Padrinos.Remove(padrino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PadrinoExists(int id)
        {
            return _context.Padrinos.Any(e => e.PadrinoId == id);
        }
    }
}
