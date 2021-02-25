using PropertyChanged;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace NETCore
{
    [AddINotifyPropertyChangedInterface]
    public class GPU
    {
        public string url { get; set; }
        public string gpuName { get; set; }
        public string price{ get; set; }
        public string availability { get; set; }
        public string country { get; set; }

        public GPU(string _url, string _gpuName, string _price, string _avail, string _country = null)
        {
            this.url = _url;
            this.gpuName = _gpuName;
            this.price = _price;
            this.availability = _avail;
            if(_country != null) this.country = _country;
        }
    }
}