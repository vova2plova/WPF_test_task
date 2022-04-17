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
        /// <summary>
        /// ФИО
        /// </summary>
        public string WorkerName { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// Опыт работы
        /// </summary>
        public int Experience { get; set; }
        /// <summary>
        /// Зарплата
        /// </summary>
        public int Salary { get; set; }
    }
}
