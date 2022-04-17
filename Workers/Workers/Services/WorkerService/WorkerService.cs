using DAL.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workers.Services.WorkerService
{
    internal class WorkerService : BaseDataService<IWorkerService>, IWorkerService
    {
        /// <summary>
        /// Запрос на сервер для получения списка должностей.
        /// </summary>
        /// <returns>Результат Task содержит ActionResult, Контент ActionResult содержит в себе список уникальных должностей.</returns>
        public async Task<ApiResponse<List<string>>> GetUniquePositionsAsync()
        {
            return await InstanceInterface.GetUniquePositionsAsync();
        }
        /// <summary>
        /// Запрос на сервер для получения списка сотрудников.
        /// </summary>
        /// <returns>Результат Task содержит ActionResult, Контент ActionResult содержит в себе список всех сотрудников.</returns>
        public async Task<ApiResponse<List<Worker>>> GetAllWorkersAsync()
        {
            return await InstanceInterface.GetAllWorkersAsync();
        }

    }
}
