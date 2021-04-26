using System;
using System.Threading.Tasks;

namespace CondoFeatures.Data.Repository.Interface
{
    public interface IPingRepository
    {
        Task<string> Pong();
    }
}
