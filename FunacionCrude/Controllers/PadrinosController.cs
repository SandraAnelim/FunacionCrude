using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FunacionCrude.Models.DAL;
using FunacionCrude.Models.Entities;
using FunacionCrude.ViewModels;
using FunacionCrude.Models.Business;
using FunacionCrude.Models.Abstract;

namespace FunacionCrude.Controllers
{
    public class PadrinosController : Controller
    {
        
        private readonly IPadrinoBusiness _padrinoBusiness;

         public PadrinosController(IPadrinoBusiness padrinoBusiness)
        {
            _padrinoBusiness = padrinoBusiness;
        }

        // GET: Padrinos


        public async Task<IActionResult> Index()
        {
           return View(await _padrinoBusiness.ObtenerListaPadrinos());
        }
       
        // GET: Padrinos/Details/5
         public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padrino = await _padrinoBusiness.ObtenerPadrinoPorId(id.Value);
            if (padrino == null)
            {
                return NotFound();
            }

            return View(padrino);
        }

        // GET: Padrinos/Create
        public IActionResult Create()
        {
            /*ViewData["listaUsuarios"] = new SelectList(_padrinoBusiness.ObtenerListaUsuarios(), "UsuarioId", "Rol");*/
            return View();
        }


        // POST: Padrinos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PadrinoId,Nombre,Correo,Edad,Profesion,Descripcion")] Padrino padrino)
        {
            if (ModelState.IsValid)
            {
                var padrinoTemp =  await _padrinoBusiness.ObtenerPadrinoPorCorreo(padrino.Correo);

                if (padrinoTemp == null)
                {
                    await _padrinoBusiness.GuardarPadrino(padrino);
                    return RedirectToAction(nameof(Index));
                }
            }


           
            ViewData["errorDoc"] = "Se encuentra registrado un empleado con este documento";

            

            return View(padrino);
            
        }
        

        // GET: Padrinos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var padrino = await _padrinoBusiness.ObtenerPadrinoPorId(id.Value);
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
        public async Task<IActionResult> Edit(int id, [Bind("PadrinoId,Nombre,Correo,Edad,Profesion,Descripcion")] Padrino padrino)
        {
            if (id != padrino.PadrinoId)
            {
                return NotFound();
            }
            var padrinoTemp = await _padrinoBusiness.ObtenerPadrinoPorCorreo(padrino.Correo);
            if (padrinoTemp == null || (padrinoTemp.PadrinoId==padrino.PadrinoId))
            {
                if (ModelState.IsValid)
                {
                    await _padrinoBusiness.EditarPadrino(padrino);
                    return RedirectToAction(nameof(Index));
                }
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

            var padrino = await _padrinoBusiness.ObtenerPadrinoPorId(id.Value);
            await _padrinoBusiness.EliminarPadrino(padrino);
            if (padrino == null)
            {
                return NotFound();
            }
                     

            return RedirectToAction(nameof(Index));

            
        }

       
    }
}
