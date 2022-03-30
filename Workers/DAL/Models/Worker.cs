using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public string WorkerName { get; set; }
        public string Position { get; set; }
        public int Experience { get; set; }
        public int Salary { get; set; }
    }
}
