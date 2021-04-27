using ImobToken.Domain;
using ImobToken.Domain.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImobToken.Data.Repository.Interface
{
    public interface IImovelRepository
    {
        IList<Imovel> GetAll();
        Imovel GetById(int idImovel);
        Task Insert(Imovel imovel);
        Task DeleteById(int idImovel);
        Task UpdateById(int idImovel, ImovelDTO imovelDTO);
    }
}
