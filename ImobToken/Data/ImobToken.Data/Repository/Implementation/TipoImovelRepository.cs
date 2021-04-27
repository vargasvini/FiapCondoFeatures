using ImobToken.Data.Repository.Interface;
using ImobToken.Domain;
using ImobToken.Domain.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImobToken.Data.Repository.Implementation
{
    public class TipoImovelRepository : ITipoImovelRepository
    {
        private readonly MainContext _db;

        public TipoImovelRepository(MainContext db)
        {
            _db = db;
        }

        public async Task DeleteById(int idTipoImovel)
        {
            var tipoImovel = _db.TipoImovel.Where(t => t.Id == idTipoImovel).FirstOrDefault();
            if(tipoImovel != null)
            {
                _db.Remove(tipoImovel);
                await _db.SaveChangesAsync();
            }
        }

        public IList<TipoImovel> GetAll()
        {
            return _db.TipoImovel.ToList();
        }

        public TipoImovel GetById(int idTipoImovel)
        {
            return _db.TipoImovel.Where(t => t.Id == idTipoImovel).FirstOrDefault();
        }

        public async Task Insert(TipoImovel tipoImovel)
        {
            await _db.AddAsync<TipoImovel>(tipoImovel);
            await _db.SaveChangesAsync();
        }

        public async Task UpdateById(int idTipoImovel, TipoImovelDTO tipoImovelDTO)
        {
            var tipoImovelResult = _db.TipoImovel.Where(t => t.Id == idTipoImovel).FirstOrDefault();

            if (tipoImovelResult != null)
            {
                tipoImovelResult.Nome = tipoImovelDTO.Nome;
                _db.Update(tipoImovelResult);
                await _db.SaveChangesAsync();
            }
        }
    }
}
