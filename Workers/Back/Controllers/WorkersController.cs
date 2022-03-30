using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Back.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkerController : ControllerBase
    {
        private readonly DataBase _db;

        public WorkerController(DataBase db)
        {
            _db = db;
        }

        [HttpGet("GetAllWorkers")]
        public async Task<ActionResult<List<Worker>>> GetWorkers()
        {
            var workers = await _db.Workers.OrderByDescending(x => x.Salary).ToListAsync();
            return Ok(workers);
        }

        [HttpGet("GetPositions")]
        public async Task<ActionResult<List<string>>> GetPositions()
        {
            var workers = await _db.Workers.GroupBy(x => x.Position).Select(x => x.Key).ToListAsync();
            return Ok(workers);
        }

    }
}