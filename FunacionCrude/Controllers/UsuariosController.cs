using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FunacionCrude.Models.DAL;
using FunacionCrude.Models.Entities;
using FunacionCrude.Models.Abstract;

namespace FunacionCrude.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioBusiness _usuarioBusiness;


        public UsuariosController(IUsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }

        // GET: Usuarios

        public async Task<IActionResult> Index()
        {
            return View(await _usuarioBusiness.ObtenerListaDeUsuarios());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _usuarioBusiness.ObtenerUsuarioPorId(id.Value);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }
       

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,Correo,Rol,Estado")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioTemp = await _usuarioBusiness.ObtenerUsuarioPorCorreo(usuario.Correo);

                if (usuarioTemp == null)
                {
                    await _usuarioBusiness.GuardarUsuario(usuario);
                    return RedirectToAction(nameof(Index));
                }
            }


            if (usuario.UsuarioId == 0)
               

            ViewData["errorDoc"] = "Se encuentra registrado un usuario con este correo";

            

            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
           
                if (id == null)
                {
                    return NotFound();
                }

                var usuario = await _usuarioBusiness.ObtenerUsuarioPorId(id.Value);
                if (usuario == null)
                {
                    return NotFound();
                }
                return View(usuario);
           
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,Correo,Rol,Estado")] Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return NotFound();
            }
            var usuarioTemp = await _usuarioBusiness.ObtenerUsuarioPorCorreo(usuario.Correo);
            if (usuarioTemp == null || (usuarioTemp.UsuarioId == usuario.UsuarioId))
            {
                if (ModelState.IsValid)
                {
                    await _usuarioBusiness.EditarUsuario(usuario);
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var usuario = await _usuarioBusiness.ObtenerUsuarioPorId(id.Value);
            await _usuarioBusiness.EliminarUsuario(usuario);
            if (usuario == null)
            {
                return NotFound();
            }


            return RedirectToAction(nameof(Index));
        }

        
    }
}
