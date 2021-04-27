using ImobToken.Data.Repository.Interface;
using ImobToken.Data;
using ImobToken.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImobToken.Domain.DTO;

namespace ImobToken.Data.Repository.Implementation
{
    public class ImovelRepository : IImovelRepository
    {
        private readonly MainContext _db;

        public ImovelRepository(MainContext db)
        {
            _db = db;
        }

        public async Task DeleteById(int idImovel)
        {
            var imovel = _db.TipoImovel.Where(i => i.Id == idImovel).FirstOrDefault();
            if (imovel != null)
            {
                _db.Remove(imovel);
                await _db.SaveChangesAsync();
            }
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


        public async Task UpdateById(int idImovel, ImovelDTO imovelDTO)
        {
            var imovelResult = _db.Imovel.Where(t => t.Id == idImovel).FirstOrDefault();

            if (imovelResult != null)
            {
                imovelResult.Nome = imovelDTO.Nome;
                imovelResult.Valor = imovelDTO.Valor;
                imovelResult.MetrosQuadrados = imovelDTO.MetrosQuadrados;
                imovelResult.FaixaRenda = imovelDTO.FaixaRenda;
                imovelResult.TipoImovelId = imovelDTO.TipoImovelId;

                _db.Update(imovelResult);
                await _db.SaveChangesAsync();
            }
        }
    }
}
