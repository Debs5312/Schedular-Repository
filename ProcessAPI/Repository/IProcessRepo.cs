using Models.API.ProcessAPI;

namespace ProcessAPI.Repository
{
    public interface IProcessRepo
    {
        Task<List<Process>> getAllProcess();
        Task<Process> getSingleProcess(string id);
        Task AddProcess(Process process);
        Task<long> updateProcess(Process process, string id);
        Task<int> deleteProcess(string id);
    }
}