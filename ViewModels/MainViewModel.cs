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
using System.Diagnostics;

namespace Cryptocurrency_Helper.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private Page dashboard;
        private Page settings;
        private Page listAll;
        private Page markets;
        private Page currentPage;
        private Page about;
        private string searchRequest;

        public event PropertyChangedEventHandler? PropertyChanged;
        public Page CurrentPage
        {
            get => currentPage;
            set
            {
                currentPage = value;
                OnPropertyChanged("CurrentPage");
                OnPropertyChanged("MainIndexData");
                OnPropertyChanged("Top10");
                OnPropertyChanged("ListAll");
                OnPropertyChanged("MarketStorage");
                OnPropertyChanged("Markets");
            }
        }
        public Page Settings => settings;

        public Page ListAll => listAll;
        public Page Markets => markets;
        public Page Dashboard => dashboard;
        public Page About => about;

        private SearchData searchData;
        public string SearchRequest { get { return searchRequest; } set { searchRequest = value; OnPropertyChanged("About"); } }

        public ICommand MenuDashboardClick => new RelayCommand(CommandDashboardExecute, CanCommandExecute => (currentPage != dashboard));
        public ICommand MenuSettigsClick => new RelayCommand(CommandSettingsExecute, CanCommandExecute => (currentPage != settings));
        public ICommand MenuListAllClick => new RelayCommand(CommandListAllExecute, CanCommandExecute => (currentPage != listAll));
        public ICommand MenuMarketsClick => new RelayCommand(CommandMarketsExecute, CanCommandExecute => (currentPage != markets));
        public ICommand MenuDashboardRowClick => new RelayCommand(CommandDashboardRowClickExecute, CanCommandExecute => (true));
        public ICommand MenuMarketsRowClick => new RelayCommand(CommandMarketsRowClickExecute, CanCommandExecute => (true));
        public ICommand SearchClick => new RelayCommand(CommandSearchClick, CanCommandExecute => (true));

        public MainAssetStorage mainIndexData;
        public MainAssetStorage MainIndexData => mainIndexData;

        public MainAssetStorage top10;
        public MainAssetStorage Top10 => top10;

        public MarketStorage marketStorage;
        public MarketStorage MarketStorage => marketStorage;
        public SearchData SearchData { get { return searchData; } set { searchData = value; OnPropertyChanged("SearchData"); } }


        public MainViewModel()
        {
            InitializeData();
            dashboard = new Pages.Dashboard();
            settings = new Pages.Settigs();
            listAll = new Pages.ListAll();
            markets = new Pages.Markets();
            about = new Pages.About();
            dashboard.DataContext = this;
            currentPage = dashboard;
        }
        private async Task LoadMainIndexData()
        {
            this.mainIndexData = await MainIndexService.GetMainIndex();
            OnPropertyChanged("MainIndexData");
        }

        private async Task LoadTop10()
        {
            this.top10 = await GetTop10Service.GetTop10();
            OnPropertyChanged("Top10");
        }

        private async Task LoadMorkets()
        {
            this.marketStorage = await GetMarketsService.GetMarkets();
            OnPropertyChanged("Markets");
        }

        private async Task LoadSearchResults()
        {
            MainIndex index = MainIndexData.data.First(o => o.Name.ToLower() == searchRequest.ToLower());
            if (index != null)
            {
                this.searchData = await SearchCurrencyService.SearhByName(index.Id.ToLower());
                OnPropertyChanged("SearchData");
            }            
        }

        public async void InitializeData()
        {
            await LoadMainIndexData();
            await LoadTop10();
            await LoadMorkets();
        }


        private async void CommandSearchClick(object parameter)
        {
            try
            {
                await LoadSearchResults();
                about.DataContext = this;
                CurrentPage = About;
                OnPropertyChanged("About");
                OnPropertyChanged("SearchData");
                OnPropertyChanged("CurrentPage");
            }
            catch (Exception) { }
        }

        private void CommandMarketsRowClickExecute(object parameter)
        {
            Market item = parameter as Market;
            if (item != null)
            {
                Process.Start("explorer", item.ExchangeUrl);
            }
        }

        private async Task LoadSearchResultsFromDadaGrid(object parameter)
        {
            MainIndex index = parameter as MainIndex;
            if (index != null)
            {
                this.searchData = await SearchCurrencyService.SearhByName(index.Id.ToLower());
                OnPropertyChanged("SearchData");
            }
        }

        private async void CommandDashboardRowClickExecute(object parameter)
        {
            await LoadSearchResultsFromDadaGrid(parameter);
            about.DataContext = this;
            CurrentPage = About;
            OnPropertyChanged("About");
            OnPropertyChanged("SearchData");
            OnPropertyChanged("CurrentPage");
            OnPropertyChanged("ListAll");
        }

        private void CommandDashboardExecute(object parameter)
        {
            dashboard.DataContext = this;
            this.currentPage = dashboard;
            OnPropertyChanged("CurrentPage");
            OnPropertyChanged("Dashboard");
            OnPropertyChanged("Top10");
            OnPropertyChanged("ListAll");
        }

        private void CommandListAllExecute(object parameter)
        {
            listAll.DataContext = this;
            this.currentPage = listAll;
            OnPropertyChanged("CurrentPage");
            OnPropertyChanged("MainIndexData");
            OnPropertyChanged("ListAll");
        }
        private void CommandMarketsExecute(object parameter)
        {
            markets.DataContext = this;
            this.currentPage = markets;
            OnPropertyChanged("CurrentPage");
            OnPropertyChanged("MarketStorage");
            OnPropertyChanged("Markets");
        }
        private void CommandSettingsExecute(object parameter)
        {
            settings.DataContext = this;
            this.currentPage = settings;
            OnPropertyChanged("CurrentPage");
            OnPropertyChanged("Settings");
            OnPropertyChanged("MainIndexData");
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
