﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency_Helper.Models
{
    public class MainAssetStorage
    {
        public ObservableCollection<MainIndex> data { get; set; }
        private string timestamp;

        public string Timestamp { get; set; }
    }
}
