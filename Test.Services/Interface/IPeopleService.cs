using System.Collections.Generic;
using System.Threading.Tasks;

namespace Test.Services.Interface
{
    public interface IPeopleService
    {
        Task<List<string>> GetAll();
    }
}
