using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkerController : ControllerBase
    {
        private readonly IDataBase _db;

        public WorkerController(IDataBase db)
        {
            _db = db;
        }

        /// <summary>
        /// Http запрос для возрата списка сотрудников.
        /// </summary>
        /// <returns>Результат Task содержит ActionResult, Контент ActionResult содержит в себе список всех сотрудников.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpGet("GetAllWorkers")]
        public async Task<ActionResult<List<Worker>>> GetAllWorkersAsync()
        {
            if (_db.Workers == null)
            {
                throw new ArgumentNullException(nameof(_db.Workers));
            }

            var workers = await _db.Workers.OrderByDescending(x => x.Salary).ToListAsync();
            return Ok(workers);
        }

        /// <summary>
        /// Http запрос для возврата списка имеющихся должностей.
        /// </summary>
        /// <returns>Результат Task содержит ActionResult, Контент ActionResult содержит в себе список уникальных должностей.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpGet("GetPositions")]
        public async Task<ActionResult<List<string>>> GetUniquePositionsAsync()
        {
            if (_db.Workers == null)
            {
                throw new ArgumentNullException(nameof(_db.Workers));
            }

            var workers = await _db.Workers.GroupBy(x => x.Position).Select(x => x.Key).ToListAsync();
            return Ok(workers);
        }

    }
}
