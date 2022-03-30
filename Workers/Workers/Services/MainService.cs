using Workers.Services.WorkerService;

namespace Workers.Services
{
    internal class MainService
    {
        public static void Init()
        {
            WorkerServices = new WorkerService.WorkerService();
        }

        public static IWorkerService WorkerServices { get; set; }
    }
}
