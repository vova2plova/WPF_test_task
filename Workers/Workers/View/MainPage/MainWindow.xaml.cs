using System.Windows;
using Workers.View.MainPage;

namespace Workers
{
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel _vm = new ();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = _vm;
        }

        /// <summary>
        /// Фильтрация по (Зарплата >= SalaryBox.Text, Должность = (Выбранный элемент)PositionList).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ActivateFiltering_Click(object sender, RoutedEventArgs e)
        {
            _vm.ActivateFiltering();
        }

        /// <summary>
        /// Отключает фильтрацию.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeactivateFiltering_Click(object sender, RoutedEventArgs e)
        {
            _vm.DeactivateFiltering();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _vm.LoadWorkers();
            _vm.LoadPositions();
        }

    }
}
