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
        /// Http ������ ��� ������� ������ �����������.
        /// </summary>
        /// <returns>��������� Task �������� ActionResult, ������� ActionResult �������� � ���� ������ ���� �����������.</returns>
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
        /// Http ������ ��� �������� ������ ��������� ����������.
        /// </summary>
        /// <returns>��������� Task �������� ActionResult, ������� ActionResult �������� � ���� ������ ���������� ����������.</returns>
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