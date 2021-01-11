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
    public class PessoasController : Controller
    {
        private readonly BdContext _context;

        public PessoasController(BdContext context)
        {
            _context = context;
        }
        #region CRUD
        // GET: Pessoas
        public async Task<IActionResult> Index()
        {
            return View(await _context.pessoa.ToListAsync());
        }

        // GET: Pessoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.pessoa
                .FirstOrDefaultAsync(m => m.id == id);
            if (pessoa == null)
            {
                return NotFound();
            }
            var usuario = _context.usuario.FirstOrDefault(s => s.Pessoa.id == id);
            var pessoaVO = new PessoaVO()
            {
                id = pessoa.id,
                Nome = pessoa.nome,
                NomeCompleto = pessoa.nomecompleto,
                DataNascimento = pessoa.datanascimento,
                created = pessoa.created,
                Email = usuario.email,
                Ativo = usuario.ativo
            };

            return View(pessoaVO);
        }

        // GET: Pessoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,NomeCompleto,DataNascimento,Email,Senha,id,created,update,remove")] PessoaVO pessoaVO)
        {
            if (ModelState.IsValid)
            {
                var pessoa = new Pessoa() 
                { 
                    created = DateTime.Now,
                    update = new DateTime(1, 1, 1),
                    remove = new DateTime(1, 1, 1),
                    nome = pessoaVO.Nome,
                    nomecompleto = pessoaVO.NomeCompleto,
                    datanascimento = pessoaVO.DataNascimento
                };
                _context.Add(pessoa);
                var usuario = new Usuario()
                {
                    created = DateTime.Now,
                    update = new DateTime(1, 1, 1),
                    remove = new DateTime(1, 1, 1),
                    email = pessoaVO.Email,
                    senha = pessoaVO.Senha,
                    ativo = true,
                    Pessoa = pessoa
                };
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pessoaVO);
        }

        // GET: Pessoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.pessoa.FindAsync(id);
            if (pessoa == null)
            {
                return NotFound();
            }
            var usuario = _context.usuario.FirstOrDefault(s => s.Pessoa.id == id);
            var pessoaVO = new PessoaVO()
            {
                id = pessoa.id,
                Nome = pessoa.nome,
                NomeCompleto = pessoa.nomecompleto,
                DataNascimento = pessoa.datanascimento,
                created = pessoa.created,
                Email = (usuario != null ? usuario.email : "" ),
                Ativo = (usuario != null ? usuario.ativo : true)
            };
            return View(pessoaVO);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,NomeCompleto,DataNascimento,Email,Senha,id,created,update,remove")] PessoaVO pessoaVO)
        {
            if (id != pessoaVO.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    var pessoa = _context.pessoa.FirstOrDefault(s => s.id == pessoaVO.id);
                    pessoa.update = DateTime.Now;
                    pessoa.nome = pessoaVO.Nome;
                    pessoa.nomecompleto = pessoaVO.NomeCompleto;
                    pessoa.datanascimento = pessoaVO.DataNascimento;
                    _context.Update(pessoa);
                    var usuario = _context.usuario.FirstOrDefault(s => s.Pessoa.id == pessoaVO.id);
                    usuario.email = pessoaVO.Email;
                    usuario.senha = pessoaVO.Senha;
                    usuario.ativo = pessoaVO.Ativo;
                    usuario.update = DateTime.Now;
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PessoaExists(pessoaVO.id))
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
            return View(pessoaVO);
        }

        // GET: Pessoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pessoa = await _context.pessoa
                .FirstOrDefaultAsync(m => m.id == id);
            if (pessoa == null)
            {
                return NotFound();
            }

            var usuario = _context.usuario.FirstOrDefault(s => s.Pessoa.id == id);
            var pessoaVO = new PessoaVO()
            {
                id = pessoa.id,
                Nome = pessoa.nome,
                NomeCompleto = pessoa.nomecompleto,
                DataNascimento = pessoa.datanascimento,
                created = pessoa.created,
                Email = (usuario != null ? usuario.email : ""),
                Ativo = (usuario != null ? usuario.ativo : true)
            };
            return View(pessoaVO);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pessoa = await _context.pessoa.FindAsync(id);
            var usuario = _context.usuario.FirstOrDefault(s => s.Pessoa.id == pessoa.id);
            _context.usuario.Remove(usuario);
            _context.pessoa.Remove(pessoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PessoaExists(int id)
        {
            return _context.pessoa.Any(e => e.id == id);
        }
        #endregion
        [HttpGet]
        public async Task<IActionResult> _GetListaPessoas(string nome="")
        {
            return PartialView(_context.pessoa.Where(w=>w.nomecompleto.Contains((nome==null?"":nome))).ToList());
        }
    }
}
