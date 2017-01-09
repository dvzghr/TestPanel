using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Test.Services.Interface;

namespace Test.Services
{
    public class PeopleService : IPeopleService
    {
        public async Task<List<string>> GetAll()
        {
            await Task.Delay(5000);
            return new List<string> { "Dirty Harry", "Rambo", "Rocky", "Mad Max" };
        }
    }
}
