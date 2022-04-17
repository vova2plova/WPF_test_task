using Workers.Services.WorkerService;

namespace Workers.Services
{
    internal class MainService
    {
        /// <summary>
        /// Инициализация сервисов.
        /// </summary>
        public static void Init()
        {
            WorkerServices = new WorkerService.WorkerService();
        }

        /// <summary>
        /// Сервис для работы с контроллером работников.
        /// </summary>
        public static IWorkerService WorkerServices { get; set; }
    }
}
