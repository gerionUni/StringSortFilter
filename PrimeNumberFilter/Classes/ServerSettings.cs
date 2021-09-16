using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeNumberFilter.Classes
{
    public class ServerSettings
    {
        public string Sorting { get; set; }
        public string Filter { get; set; }
        
        public ServerSettings(IConfiguration config)
        {
            Sorting = config.GetValue<string>("SystemConf:Sorting");
            Filter = config.GetValue<string>("SystemConf:Filter");
        }
    }
}
