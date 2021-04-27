
using ImobToken.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ImboToken.Data.Repository.Interface
{
    public interface IImovelRepository
    {
        IList<Imovel> GetAll();
        Imovel GetById(int idImovel);
        Task Insert(Imovel imovel);
    }
}
