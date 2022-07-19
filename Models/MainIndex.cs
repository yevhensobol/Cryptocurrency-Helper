using Newtonsoft.Json;
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
        private string supply;
        private string maxSupply;
        private string marketCapUsd;
        private string volumeUsd24Hr;
        private string priceUsd;
        private string changePercent24Hr;
        private string vwap24Hr;


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
        public string Supply
        {
            set { this.supply = value; OnPropertyChanged("Supply"); }
            get { return this.supply; }
        }
        public string MaxSupply
        {
            set { this.maxSupply = value; OnPropertyChanged("MaxSupply"); }
            get { return this.maxSupply; }
        }
        public string MarketCapUsd
        {
            set { this.marketCapUsd = value; OnPropertyChanged("MarketCapUsd"); }
            get { return this.marketCapUsd; }
        }
        public string VolumeUsd24Hr
        {
            set { this.volumeUsd24Hr = value; OnPropertyChanged("VolumeUsd24Hr"); }
            get { return this.volumeUsd24Hr; }
        }
        public string PriceUsd
        {
            set { this.priceUsd = value; OnPropertyChanged("PriceUsd"); }
            get { return this.priceUsd; }
        }
        public string ChangePercent24Hr
        {
            set { this.changePercent24Hr = value; OnPropertyChanged("ChangePercent24Hr"); }
            get { return this.changePercent24Hr; }
        }
        public string Vwap24Hr
        {
            set { this.vwap24Hr = value; OnPropertyChanged("Vwap24Hr"); }
            get { return this.vwap24Hr; }
        }

        //[JsonProperty("name")]
        //private string name;
        //[JsonProperty("id")]
        //private string id;
        //[JsonProperty("last")]
        //private string last;

        //public string Name
        //{
        //    set { this.name = value; OnPropertyChanged("Name"); }
        //    get { return this.name; }
        //}
        //public string Id
        //{
        //    set { this.id = value; OnPropertyChanged("Id"); }
        //    get { return this.id; }
        //}
        //public string Last
        //{
        //    set { this.last = value; OnPropertyChanged("Last"); }
        //    get { return this.last; }
        //}


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}