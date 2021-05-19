using System;
using System.Collections.Generic;
using System.Text;

namespace GetRates.DAL.Models
{
    public class ListingRoot
    {
        public ResponseStatus status { get; set; }
        public List<CryptoJson> data { get; set; }
    }
}
