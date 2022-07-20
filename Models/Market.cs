using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency_Helper.Models
{
    public class Market : INotifyPropertyChanged
    {
        private string id;
        private string name;
        private int rank;
        private decimal? percentTotalVolume;
        private decimal? volumeUsd;
        private int? tradingPairs;
        private bool? socket;
        private string exchangeUrl;
        private string updated;

        public string Id
        {
            set { this.id = value; OnPropertyChanged("Id"); }
            get { return this.id; }
        }

        public string Name
        {
            set { this.name = value; OnPropertyChanged("Name"); }
            get { return this.name; }
        }

        public int Rank
        {
            set { this.rank = value; OnPropertyChanged("Rank"); }
            get { return this.rank; }
        }

        public decimal? PercentTotalVolume
        {
            set { this.percentTotalVolume = value; OnPropertyChanged("PercentTotalVolume"); }
            get { if (this.percentTotalVolume.HasValue && this.percentTotalVolume > (decimal)1.0) return Math.Round((decimal)percentTotalVolume, 1); else return Math.Round((decimal)percentTotalVolume, 3); }
        }

        public decimal? VolumeUsd
        {
            set { this.volumeUsd = value; OnPropertyChanged("VolumeUsd"); }
            get { return this.volumeUsd / 1000000000; }
        }

        public int? TradingPairs
        {
            set { this.tradingPairs = value; OnPropertyChanged("TradingPairs"); }
            get { return this.tradingPairs; }
        }
        public bool? Socket
        {
            set { this.socket = value; OnPropertyChanged("Socket"); }
            get { return this.socket; }
        }
        public string ExchangeUrl
        {
            set { this.exchangeUrl = value; OnPropertyChanged("ExchangeUrl"); }
            get { return this.exchangeUrl; }
        }
        public string Updated
        {
            set { this.updated = value; OnPropertyChanged("Updated"); }
            get { return this.updated; }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
