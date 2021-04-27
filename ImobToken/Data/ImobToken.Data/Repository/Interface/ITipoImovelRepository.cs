using ImobToken.Domain;
using ImobToken.Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImobToken.Data.Repository.Interface
{
    public interface ITipoImovelRepository
    {
        IList<TipoImovel> GetAll();
        TipoImovel GetById(int idTipoImovel);
        Task Insert(TipoImovel tipoImovel);
        Task DeleteById(int idTipoImovel);
        Task UpdateById(int idTipoImovel, TipoImovelDTO tipoImovelDTO);
    }
}
