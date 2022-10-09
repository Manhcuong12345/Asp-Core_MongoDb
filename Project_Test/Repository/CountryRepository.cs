using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Project_Test.Models;

namespace Project_Test.Repository
{
    public class CountryRepository: ICountryRepository
    {
        private readonly IMongoCollection<Country> _collection;
        private readonly DbConfiguration _settings;
        public CountryRepository(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<Country>("address");
        }

        public Task<List<Country>> GetAllAsync()
        {
            return _collection.Find(c => true).ToListAsync();
        }
        public Task<Country> GetByIdAsync(string id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Country> CreateAsync(Country countries)
        {
            await _collection.InsertOneAsync(countries).ConfigureAwait(false);
            return countries;
        }
        public Task UpdateAsync(string id, Country countries)
        {
            return _collection.ReplaceOneAsync(c => c.Id == id, countries);
        }
        public Task DeleteAsync(string id)
        {
            return _collection.DeleteOneAsync(c => c.Id == id);
        }
    }
}
