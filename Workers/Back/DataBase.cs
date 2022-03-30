using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Back
{
    public class DataBase : DbContext
    {
        public DbSet<Worker> Workers { get; set; }

        public DataBase(DbContextOptions<DataBase> options) : base(options) {}
    }
}
