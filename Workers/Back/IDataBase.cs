using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Back
{
    public interface IDataBase
    {
        public DbSet<Worker>? Workers { get; set; }
    }
}