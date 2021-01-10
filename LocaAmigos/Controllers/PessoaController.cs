using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LocaAmigos.InfraEstrutura;
using LocaAmigos.Models;
using Microsoft.AspNetCore.Mvc;

namespace LocaAmigos.Controllers
{
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaProvider _dataPessoaProvider;
        public PessoaController(IPessoaProvider dataAccessProvider)
        {
            _dataPessoaProvider = dataAccessProvider;
        }

        [HttpGet]
        public IEnumerable<Pessoa> Get()
        {
            return _dataPessoaProvider.GetPessoaRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody]Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _dataPessoaProvider.AddPessoaRecord(pessoa);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Pessoa Details(int id)
        {
            return _dataPessoaProvider.GetPessoaSingleRecord(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody]Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                _dataPessoaProvider.UpdatePassoaRecord(pessoa);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = _dataPessoaProvider.GetPessoaSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _dataPessoaProvider.DeletePessoaRecord(id);
            return Ok();
        }
    }    
}