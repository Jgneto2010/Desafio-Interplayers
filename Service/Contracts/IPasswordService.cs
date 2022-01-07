using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IPasswordService
    {
        Task<List<string>> RegisterPassword(string input);
    }
}
