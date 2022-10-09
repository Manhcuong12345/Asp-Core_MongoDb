using Project_Test.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Test.Repository
{
    public interface ICountryRepository
    {
        Task<List<Country>> GetAllAsync();
        Task<Country> GetByIdAsync(string id);
        Task<Country> CreateAsync(Country countries);
        Task UpdateAsync(string id, Country countries);
        Task DeleteAsync(string id);
    }
}
