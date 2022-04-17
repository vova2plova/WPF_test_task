using DAL.Models;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Workers.Services;

namespace Workers.View.MainPage
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public ObservableCollection<Worker> Workers { get; set; } = new ObservableCollection<Worker>();
        public ObservableCollection<string> Positions { get; set; } = new ObservableCollection<string>();

        private static List<Worker> _workers = new ();
        private static List<string> _positions = new ();
        private string _position = "";
        private int _salary;

        /// <summary>
        /// Служит для привязки ввода зарплаты.
        /// </summary>
        public string Salary
        {
            set
            {
                Int32.TryParse(value, out _salary);
            }
        }

        /// <summary>
        /// Служит для привязки ввода должности.
        /// </summary>
        public string Position
        {
            set => _position = value;
        }

        /// <summary>
        /// Загружает работников в ItemsControl - StaffList.
        /// </summary>
        public async void LoadWorkers()
        {
            
            var workers = await MainService.WorkerServices.GetAllWorkersAsync();
            if (workers.IsSuccessStatusCode)
            {
                _workers = workers.Content;
                Workers = new ObservableCollection<Worker>(_workers);
                OnPropertyChanged(nameof(Workers));
            }
        }

        /// <summary>
        /// Загружает список должностей в ComboBox - PositionList.
        /// </summary>
        public async void LoadPositions()
        {
            var positions = await MainService.WorkerServices.GetUniquePositionsAsync();
            if (positions.IsSuccessStatusCode)
            {
                _positions = positions.Content;
                Positions = new ObservableCollection<string>(_positions);
                OnPropertyChanged(nameof(Positions));
            }
        }

        /// <summary>
        /// Активирует фильтрацию работников по правилу (Зарплата >=, Должность =).
        /// </summary>
        public void ActivateFiltering()
        {
            Workers = new ObservableCollection<Worker>(_workers.Where(w => w.Salary >= _salary && w.Position == _position));
            OnPropertyChanged(nameof(Workers));
        }

        /// <summary>
        /// Отключает фильтрацию работников.
        /// </summary>
        public void DeactivateFiltering()
        {
            Workers = new ObservableCollection<Worker>(_workers);
            OnPropertyChanged(nameof(Workers));
        }

        /// <summary>
        /// Передаёт информацию о том, что объект изменился.
        /// </summary>
        /// <param name="propertyName">Изменённый объект</param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
