using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LocaAmigos.Data;
using LocaAmigos.Models;
using LocaAmigos.Models.DVO;
using Microsoft.AspNetCore.Authorization;

namespace LocaAmigos.Controllers
{
    [Authorize]
    public class MovimentacoesController : Controller
    {
        private readonly BdContext _context;

        public MovimentacoesController(BdContext context)
        {
            _context = context;
        }

        // GET: Movimentacoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.movimentacoes.ToListAsync());
        }

        // GET: Movimentacoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacoes = await _context.movimentacoes
                .FirstOrDefaultAsync(m => m.id == id);
            if (movimentacoes == null)
            {
                return NotFound();
            }

            return View(movimentacoes);
        }

        // GET: Movimentacoes/Create
        public IActionResult Create()
        {
            var Movimentacoes = new MovimentacoesVO();
            ViewBag.ListaJogos = _context.jogos.Where(w => w.ativo).ToList().Select(c => new SelectListItem()
            { Text = c.nome, Value = c.id.ToString() }).ToList();
            ViewBag.ListaPessoas = _context.pessoa.ToList().Select(c => new SelectListItem()
            { Text = c.nomecompleto, Value = c.id.ToString() }).ToList();
            return View();
        }

        // POST: Movimentacoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("inicio,fim,PessoaId,JogosId,update,remove")] MovimentacoesVO movimentacoesVO)
        {
            if (ModelState.IsValid)
            {
                var movimentacoes = new Movimentacoes();
                movimentacoes.created = DateTime.Now;
                movimentacoes.update = DateTime.Now;
                movimentacoes.remove = new DateTime(01, 01, 01);
                movimentacoes.ativo = true;
                movimentacoes.Usuario = _context.usuario.Where(w => w.id == 2).FirstOrDefault();
                movimentacoes.Pessoa = _context.pessoa.Where(w => w.id == Convert.ToInt32(movimentacoesVO.PessoaId)).FirstOrDefault();
                movimentacoes.Jogos = _context.jogos.Where(w => w.id == Convert.ToInt32(movimentacoesVO.JogosId)).FirstOrDefault();
                _context.Add(movimentacoes);
                _context.SaveChanges();
                var jogos = _context.jogos.Where(w => w.id == Convert.ToInt32(movimentacoesVO.JogosId)).ToList().FirstOrDefault();
                jogos.ativo = false;
                _context.jogos.Update(jogos);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(movimentacoesVO);
        }

        // GET: Movimentacoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacoes = await _context.movimentacoes.FindAsync(id);
            if (movimentacoes == null)
            {
                return NotFound();
            }
            return View(movimentacoes);
        }

        // POST: Movimentacoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("inicio,fim,ativo,id,created,update,remove")] Movimentacoes movimentacoes)
        {
            if (id != movimentacoes.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimentacoes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimentacoesExists(movimentacoes.id))
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
            return View(movimentacoes);
        }

        // GET: Movimentacoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movimentacoes = await _context.movimentacoes
                .FirstOrDefaultAsync(m => m.id == id);
            if (movimentacoes == null)
            {
                return NotFound();
            }

            return View(movimentacoes);
        }

        // POST: Movimentacoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movimentacoes = await _context.movimentacoes.FindAsync(id);
            _context.movimentacoes.Remove(movimentacoes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimentacoesExists(int id)
        {
            return _context.movimentacoes.Any(e => e.id == id);
        }
    }
}
