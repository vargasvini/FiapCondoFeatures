using ImboToken.Data.Repository.Interface;
using ImobToken.Data;
using ImobToken.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImboToken.Data.Repository.Implementation
{
    public class ImovelRepository : IImovelRepository
    {
        private readonly MainContext _db;

        public ImovelRepository(MainContext db)
        {
            _db = db;
        }

        public IList<Imovel> GetAll()
        {
            return _db.Imovel.Include(t => t.TipoImovel).ToList();
        }

        public Imovel GetById(int idImovel)
        {
            return _db.Imovel.Where(i => i.Id == idImovel).Include(t => t.TipoImovel).FirstOrDefault();
        }

        public async Task Insert(Imovel imovel)
        {
            await _db.AddAsync<Imovel>(imovel);
            await _db.SaveChangesAsync();
        }
    }
}
