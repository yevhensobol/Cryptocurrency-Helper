using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Cryptocurrency_Helper.Services;
using Cryptocurrency_Helper.Models;
using System.Collections.ObjectModel;

namespace Cryptocurrency_Helper.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private Page dashboard;
        private Page settings;
        private Page listAll;
        private Page favorites;
        private Page currentPage;
        public event PropertyChangedEventHandler? PropertyChanged;
        public Page CurrentPage => currentPage;
        public Page Settings => settings;
        public Page ListAll => listAll;
        public Page Favorites => favorites;
        public Page Dashboard => dashboard;
        public ICommand MenuDashboardClick => new RelayCommand(CommandDashboardExecute, CanCommandExecute => (currentPage != dashboard));
        public ICommand MenuSettigsClick => new RelayCommand(CommandSettingsExecute, CanCommandExecute => (currentPage != settings));
        public ICommand MenuListAllClick => new RelayCommand(CommandListAllExecute, CanCommandExecute => (currentPage != listAll));
        public ICommand MenuFavoritesClick => new RelayCommand(CommandFavoritesExecute, CanCommandExecute => (currentPage != favorites));       


        //public ObservableCollection<MainIndex> mainIndexData;
        //public ObservableCollection<MainIndex> MainIndexData => mainIndexData;

        public MainAssetStorage mainIndexData;
        public MainAssetStorage MainIndexData => mainIndexData;
     

        private async Task LoadMainIndexData()
        {
            this.mainIndexData = await MainIndexService.GetMainIndex();
            OnPropertyChanged("MainIndexData");
        }

        public MainViewModel()
        {
            InitializeData();
            dashboard = new Pages.Dashboard();
            settings = new Pages.Settigs();
            listAll = new Pages.ListAll();
            favorites = new Pages.Favorites();
            currentPage = Dashboard;            
        } 

       
        public async void InitializeData()
        {
            await LoadMainIndexData();            
        }


        private void CommandDashboardExecute(object parameter)
        {
            this.currentPage = dashboard;
            OnPropertyChanged("CurrentPage");
            OnPropertyChanged("MainIndexData");
        }


        private void CommandListAllExecute(object parameter)
        {
            this.currentPage = listAll;
            OnPropertyChanged("CurrentPage");
        }
        private void CommandFavoritesExecute(object parameter)
        {
            this.currentPage = favorites;
            OnPropertyChanged("CurrentPage");
        }
        private void CommandSettingsExecute(object parameter)
        {
            this.currentPage = settings;
            OnPropertyChanged("CurrentPage");
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
