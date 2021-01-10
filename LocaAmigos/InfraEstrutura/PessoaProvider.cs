using LocaAmigos.InfraEstrutura;
using LocaAmigos.Models;
using System.Collections.Generic;
using System.Linq;

namespace LocaAmigos.DataAccess
{
    public class PessoaProvider : IPessoaProvider
    {
        private readonly PostgreSqlContext _context;

        public PessoaProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddPessoaRecord(Pessoa Pessoa)
        {
            _context.pessoa.Add(Pessoa);
            _context.SaveChanges();
        }

        public void UpdatePassoaRecord(Pessoa pessoa)
        {
            _context.pessoa.Update(pessoa);
            _context.SaveChanges();
        }

        public void DeletePessoaRecord(int id)
        {
            var entity = _context.pessoa.FirstOrDefault(t => t.id == id);
            _context.pessoa.Remove(entity);
            _context.SaveChanges();
        }

        public Pessoa GetPessoaSingleRecord(int id)
        {
            return _context.pessoa.FirstOrDefault(t => t.id == id);
        }

        public List<Pessoa> GetPessoaRecords()
        {
            return _context.pessoa.ToList();
        }
    }
}