﻿using System;
using CCSODiscordBot.Services.DataTables;
using MongoDB.Driver;

namespace CCSODiscordBot.Services.Database.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly IMongoCollection<DataTables.User> _userCollection;

        public UserRepository(IMongoDatabase mongoDatabase)
        {
            _userCollection = mongoDatabase.GetCollection<DataTables.User>("user");
        }

        // CRUD Operations:
        #region Create
        public async Task CreateNewGuildAsync(DataTables.User newGuild)
        {
            await _userCollection.InsertOneAsync(newGuild);
        }
        #endregion Create
        #region Read
        public async Task<List<DataTables.User>> GetAllAsync()
        {
            return await _userCollection.Find(_ => true).ToListAsync();
        }
        public async Task<DataTables.User> GetByBsonIdAsync(string id)
        {
            return await _userCollection.Find(_ => _.Id == id).FirstOrDefaultAsync();
        }
        public async Task<DataTables.User> GetByDiscordIdAsync(ulong id)
        {
            return await _userCollection.Find(_ => _.DiscordID == id).FirstOrDefaultAsync();
        }
        public async Task<List<DataTables.User>> GetByLinqAsync(FilterDefinition<DataTables.User> filter, FindOptions? options = null)
        {
            return await _userCollection.Find(filter, options).ToListAsync();
        }
        #endregion Read
        #region Update
        public async Task UpdategGuildAsync(DataTables.User userToUpdate)
        {
            await _userCollection.ReplaceOneAsync(x => x.Id == userToUpdate.Id, userToUpdate);
        }
        #endregion Update
        #region Delete
        public async Task DeleteGuildAsync(string id)
        {
            await _userCollection.DeleteOneAsync(x => x.Id == id);
        }
        #endregion Delete
    }
}

