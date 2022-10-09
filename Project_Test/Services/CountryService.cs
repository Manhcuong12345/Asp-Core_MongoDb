using Project_Test.Models;
using Project_Test.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Test.Services
{
    public class CountryService: ICountryService
    {
        private readonly ICountryRepository _countriesRepository;

        public CountryService(ICountryRepository countriesRepository)
        {
            _countriesRepository = countriesRepository;
        }

        public Task<List<Country>> GetAllAsync()
        {
            return _countriesRepository.GetAllAsync();
        }

        public Task<Country> GetByIdAsync(string id)
        {
            return _countriesRepository.GetByIdAsync(id);
        }

        public Task<Country> CreateAsync(Country countries)
        {
            return _countriesRepository.CreateAsync(countries);
        }

        public Task UpdateAsync(string id, Country countries)
        {
            return _countriesRepository.UpdateAsync(id, countries);
        }

        public Task DeleteAsync(string id)
        {
            return _countriesRepository.DeleteAsync(id);
        }
    }
}
