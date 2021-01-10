using LocaAmigos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocaAmigos.InfraEstrutura
{
    public interface IPessoaProvider
    {
        void AddPessoaRecord(Pessoa pessoa);
        void UpdatePassoaRecord(Pessoa pessoa);
        void DeletePessoaRecord(int id);
        Pessoa GetPessoaSingleRecord(int id);
        List<Pessoa> GetPessoaRecords();
    }
}
