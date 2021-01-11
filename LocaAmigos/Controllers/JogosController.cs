using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocaAmigos.Data;
using LocaAmigos.Models;
using Microsoft.AspNetCore.Authorization;

namespace LocaAmigos.Controllers
{
    [Authorize]
    public class JogosController : Controller
    {
        private readonly BdContext _context;

        public JogosController(BdContext context)
        {
            _context = context;
        }

        // GET: Jogos
        public async Task<IActionResult> Index()
        {
            return View(await _context.jogos.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> _GetListaGamesLiberados(string nome)
        {
            nome = (nome == null ? "" : nome);
            return View(await _context.jogos
                .Where(w => w.ativo && w.nome.Contains(nome))
                .ToListAsync());
        }

        public IActionResult Reservar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = _context.jogos
                .FirstOrDefault(m => m.id == id);
            if (jogos == null)
            {
                return NotFound();
            }

            return View(jogos);
        }


        // GET: Jogos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = await _context.jogos
                .FirstOrDefaultAsync(m => m.id == id);
            if (jogos == null)
            {
                return NotFound();
            }

            return View(jogos);
        }

        // GET: Jogos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nome,tipojogo,ativo,id,created,update,remove")] Jogos jogos)
        {
            if (ModelState.IsValid)
            {
                jogos.created = DateTime.Now;
                jogos.update = new DateTime(1, 1, 1);
                jogos.remove = new DateTime(1, 1, 1);
                _context.Add(jogos);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jogos);
        }

        // GET: Jogos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = await _context.jogos.FindAsync(id);
            if (jogos == null)
            {
                return NotFound();
            }
            return View(jogos);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("nome,tipojogo,ativo,id,created,update,remove")] Jogos jogos)
        {
            if (id != jogos.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jogos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JogosExists(jogos.id))
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
            return View(jogos);
        }

        // GET: Jogos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jogos = await _context.jogos
                .FirstOrDefaultAsync(m => m.id == id);
            if (jogos == null)
            {
                return NotFound();
            }

            return View(jogos);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jogos = await _context.jogos.FindAsync(id);
            _context.jogos.Remove(jogos);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JogosExists(int id)
        {
            return _context.jogos.Any(e => e.id == id);
        }
    }
}
