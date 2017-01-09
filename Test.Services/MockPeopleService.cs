using System.Collections.Generic;
using System.Threading.Tasks;
using Test.Services.Interface;

namespace Test.Services
{
    public class MockPeopleService : IPeopleService
    {
        public async Task<List<string>> GetAll()
        {
            return new List<string> { "Peter", "Mary", "John", "Heidi" };
        }
    }
}
