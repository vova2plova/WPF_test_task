using DAL.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workers.Services.WorkerService
{
    internal class WorkerService : BaseDataService<IWorkerService>, IWorkerService
    {
        public async Task<ApiResponse<List<string>>> GetPositions()
        {
            return await InstanceInterface.GetPositions();
        }

        public async Task<ApiResponse<List<Worker>>> GetWorkers()
        {
            return await InstanceInterface.GetWorkers();
        }
    }
}
