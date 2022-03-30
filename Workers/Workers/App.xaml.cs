using System.Windows;
using Workers.Services;

namespace Workers
{
    public partial class App : Application
    {
        public App()
        {
            MainService.Init();
        }

    }
}
