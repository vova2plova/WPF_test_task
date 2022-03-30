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

        private static List<Worker> _workers = new List<Worker>();
        private static List<string> _positions = new List<string>();
        private string _position = "";
        private int _salary;

        public string Salary
        {
            set
            {
                Int32.TryParse(value, out _salary);
            }
        }

        public string Position
        {
            set => _position = value;
        }
        public async void LoadWorkers()
        {
            var workers = await MainService.WorkerServices.GetWorkers();
            if (workers.IsSuccessStatusCode)
            {
                _workers = workers.Content;
                Workers = new ObservableCollection<Worker>(_workers);
                OnPropertyChanged(nameof(Workers));
            }
        }

        public async void LoadPositions()
        {
            var positions = await MainService.WorkerServices.GetPositions();
            if (positions.IsSuccessStatusCode)
            {
                _positions = positions.Content;
                Positions = new ObservableCollection<string>(_positions);
                OnPropertyChanged(nameof(Positions));
            }
        }

        public void ActivateFiltering()
        {
            Workers = new ObservableCollection<Worker>(_workers.Where(w => w.Salary >= _salary && w.Position == _position));
            OnPropertyChanged(nameof(Workers));
        }

        public void DeactivateFiltering()
        {
            Workers = new ObservableCollection<Worker>(_workers);
            OnPropertyChanged(nameof(Workers));
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


    }
}
