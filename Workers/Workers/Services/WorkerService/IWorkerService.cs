using DAL.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Workers.Services.WorkerService
{
    internal interface IWorkerService
    {
        /// <summary>
        /// Запрос на сервер для получения списка сотрудников.
        /// </summary>
        /// <returns>Результат Task содержит ActionResult, Контент ActionResult содержит в себе список всех сотрудников.</returns>
        [Get("/Worker/GetAllWorkers")]
        Task<ApiResponse<List<Worker>>> GetAllWorkersAsync();
        /// <summary>
        /// Запрос на сервер для получения списка должностей.
        /// </summary>
        /// <returns>Результат Task содержит ActionResult, Контент ActionResult содержит в себе список уникальных должностей.</returns>
        [Get("/Worker/GetPositions")]
        Task<ApiResponse<List<string>>> GetUniquePositionsAsync();
    }
}
