using Microsoft.Extensions.Options;
using Models.API.ProcessAPI;
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

        public Task<ProcessDTO> AddProcess(ProcessDTO process)
        {
            throw new NotImplementedException();
        }

        public Task<int> deleteProcess(string id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Process>> getAllProcess()
        {
            throw new NotImplementedException();
        }

        public Task<Process> getSingleProcess(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Process> updateProcess(ProcessDTO process, string id)
        {
            throw new NotImplementedException();
        }

    }
}