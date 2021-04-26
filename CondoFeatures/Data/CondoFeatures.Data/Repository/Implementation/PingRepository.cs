using CondoFeatures.Data.Repository.Interface;
using System.Threading.Tasks;

namespace CondoFeatures.Data.Repository.Implementation
{
    public class PingRepository : IPingRepository
    {
        private const string KEY_PONG = "PONG";

        public async Task<string> Pong()
        {
            return await Task.FromResult(KEY_PONG);
        }
    }
}
