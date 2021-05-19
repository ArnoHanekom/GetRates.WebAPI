using System;
using System.Collections.Generic;
using System.Text;

namespace GetRates.DAL.Models
{
    public class CryptoQuoteJson
    {        
        public decimal Price { get; set; }
#nullable enable
        public decimal? Volume_24h { get; set; }
        public decimal? Percent_Change_1h { get; set; }
        public decimal? Percent_Change_24h { get; set; }
        public decimal? Percent_Change_7d { get; set; }
        public decimal? Percent_Change_30d { get; set; }
        public decimal? Percent_Change_60d { get; set; }
        public decimal? Percent_Change_90d { get; set; }
        public decimal? Market_Cap { get; set; }
#nullable disable 
        public DateTime Last_Updated { get; set; }
    }
}
