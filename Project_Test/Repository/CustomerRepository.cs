﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Project_Test.Models;

namespace Project_Test.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> _collection;
        private readonly DbConfiguration _settings;
        public CustomerRepository(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _collection = database.GetCollection<Customer>("customer");
        }

        public Task<List<Customer>> GetAllAsync()
        {
            return _collection.Find(c => true).ToListAsync();
        }
        public Task<Customer> GetByIdAsync(string id)
        {
            return _collection.Find(c => c.Id == id).FirstOrDefaultAsync();
        }
        public async Task<Customer> CreateAsync(Customer customer)
        { 
            await _collection.InsertOneAsync(customer).ConfigureAwait(false);
            return customer;
        }
        public async Task UpdateAsync(string id, Customer customer)
        {
          await _collection.ReplaceOneAsync(c => c.Id == id,customer);
          
        }
        public Task DeleteAsync(string id)
        {
            return _collection.DeleteOneAsync(c => c.Id == id);
        }
    }
}
