using System.Windows;
using Workers.View.MainPage;

namespace Workers
{
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _vm = new MainWindowViewModel();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;
        }

        private void ActivateFiltering_Click(object sender, RoutedEventArgs e)
        {
            _vm.ActivateFiltering();
        }

        private void DeactivateFiltering_Click(object sender, RoutedEventArgs e)
        {
            _vm.DeactivateFiltering();
        }

        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            _vm.LoadWorkers();
            _vm.LoadPositions();
        }

    }
}
