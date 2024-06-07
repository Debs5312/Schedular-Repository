using Microsoft.Extensions.Options;
using Models.API.ProcessAPI;
using MongoDB.Bson;
using MongoDB.Driver;
using ProcessAPI.DBConnections;

namespace ProcessAPI.Repository
{
    public class ProcessRepo : IProcessRepo
    {
        private readonly IMongoCollection<Process> _playlistCollection;


        public ProcessRepo(IOptions<MongoDBSetting> mongoDBSettings)
        {

            MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
            _playlistCollection = database.GetCollection<Process>(mongoDBSettings.Value.CollectionName);
        }

        public async Task AddProcess(Process process)
        {
            try
            {
                await _playlistCollection.InsertOneAsync(process);
                return;
            }
            catch (System.Exception)
            {
                throw;
            }

        }

        public async Task<bool> deleteProcess(string id)
        {
            var deletedRowCount = await _playlistCollection.DeleteOneAsync(item => item.Id == id);
            if(deletedRowCount.IsAcknowledged) return deletedRowCount.DeletedCount == 1;
            return false;
        }

        public async Task<List<Process>> getAllProcess()
        {
            return await _playlistCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Process> getSingleProcess(string id)
        {
            FilterDefinition<Process> filter = Builders<Process>.Filter.Eq("Id", id);
            return await _playlistCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<long> updateProcess(Process process, string id)
        {
            // var updatedProcess = await _playlistCollection.FindOneAndUpdateAsync(
            //     Builders<Process>.Filter.Where(rec => rec.Id == id),
            //     Builders<Process>.Update.Set(rec => rec, process),
            //     options: new FindOneAndUpdateOptions<Process>
            //     {
            //         // Do this to get the record AFTER the updates are applied
            //         ReturnDocument = ReturnDocument.After 
            //     }
            // ).ConfigureAwait(false);

            // return updatedProcess;

            // var result = await _playlistCollection.UpdateOneAsync(
            //     Builders<Process>.Filter.Eq("Id", id),
            //     Builders<Process>.Update.Set(rec => rec, process)
            // );

            // if(result.IsAcknowledged) return result.ModifiedCount;
            // else return 0;

            var modifiedResult = await _playlistCollection.ReplaceOneAsync(x => x.Id == id, process);

            if(modifiedResult.IsAcknowledged) return modifiedResult.ModifiedCount;
            else return 0;

        }

    }
}