using MongoDB.Driver;
using sp_medical_group.Domains;
using sp_medical_group.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sp_medical_group.Repositories
{
    public class LocalizacaoRepository : ILocalizacao
    {
        private readonly IMongoCollection<Localizacao> _localizacoes;

        public LocalizacaoRepository()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("Sp_Medical7");
            _localizacoes = database.GetCollection<Localizacao>("mapas");
        }


        public void Cadastrar(Localizacao novaLocalizacao)
        {
            _localizacoes.InsertOne(novaLocalizacao);
        }

        public List<Localizacao> ListarTodos()
        {
            return _localizacoes.Find(localizacao => true).ToList();
        }
    }
}
