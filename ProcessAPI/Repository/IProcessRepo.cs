using Models.API.ProcessAPI;

namespace ProcessAPI.Repository
{
    public interface IProcessRepo
    {
        Task<IEnumerable<Process>> getAllProcess();
        Task<Process> getSingleProcess(Guid id);
        Task<ProcessDTO> AddProcess(ProcessDTO process);
        Task<Process> updateProcess(ProcessDTO process, string id);
        Task<int> deleteProcess(string id);
    }
}