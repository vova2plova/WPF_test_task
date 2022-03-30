using DAL.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workers.Services.WorkerService
{
    internal interface IWorkerService
    {
        [Get("/Worker/GetAllWorkers")]
        Task<ApiResponse<List<Worker>>> GetWorkers();

        [Get("/Worker/GetPositions")]
        Task<ApiResponse<List<string>>> GetPositions();
    }
}
