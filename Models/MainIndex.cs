using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Cryptocurrency_Helper.Models
{
    public class MainIndex : INotifyPropertyChanged
    {
        private string id;
        private int rank;
        private string symbol;
        private string name;
        private decimal? supply;
        private decimal? maxSupply;
        private decimal? marketCapUsd;
        private decimal? volumeUsd24Hr;
        private decimal? priceUsd;
        private decimal? changePercent24Hr;
        private decimal? vwap24Hr;

        public string Id
        {
            set { this.id = value; OnPropertyChanged("Id"); }
            get { return this.id; }
        }
        public int Rank
        {
            set { this.rank = value; OnPropertyChanged("Rank"); }
            get { return this.rank; }
        }
        public string Symbol
        {
            set { this.symbol = value; OnPropertyChanged("Symbol"); }
            get { return this.symbol; }
        }
        public string Name
        {
            set { this.name = value; OnPropertyChanged("Name"); }
            get { return this.name; }
        }
        public decimal? Supply
        {
            set { this.supply = Convert.ToDecimal(value); OnPropertyChanged("Supply"); }
            get { return this.supply; }
        }
        public decimal? MaxSupply
        {
            set { this.maxSupply = Convert.ToDecimal(value); OnPropertyChanged("MaxSupply"); }
            get { return this.maxSupply; }
        }
        public decimal? MarketCapUsd
        {
            set { this.marketCapUsd = Convert.ToDecimal(value); OnPropertyChanged("MarketCapUsd"); }
            get { return this.marketCapUsd/1000000000; }
        }
        public decimal? VolumeUsd24Hr
        {
            set { this.volumeUsd24Hr = Convert.ToDecimal(value); OnPropertyChanged("VolumeUsd24Hr"); }
            get { return this.volumeUsd24Hr/1000000000; }
        }
        public decimal? PriceUsd
        {
            set { this.priceUsd = Convert.ToDecimal(value); OnPropertyChanged("PriceUsd"); }
            get { return this.priceUsd; }
        }
        public decimal? ChangePercent24Hr
        {
            set { this.changePercent24Hr = Convert.ToDecimal(value); OnPropertyChanged("ChangePercent24Hr"); }
            get { if (this.changePercent24Hr.HasValue && this.changePercent24Hr > (decimal)1.0) return Math.Round((decimal)changePercent24Hr, 1); else return Math.Round((decimal)changePercent24Hr, 3); }
        }
        public decimal? Vwap24Hr
        {
            set { this.vwap24Hr = Convert.ToDecimal(value); OnPropertyChanged("Vwap24Hr"); }
            get { return this.vwap24Hr; }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}