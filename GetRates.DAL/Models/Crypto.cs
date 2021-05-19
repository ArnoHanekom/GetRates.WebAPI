using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GetRates.DAL.Models
{
    public class Crypto
    {
        [Key]
        public int Id { get; set; }
        public int ApiRefId { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Slug { get; set; }
        public int Num_Market_Pairs { get; set; }
        public DateTime Date_Added { get; set; }
        public string Tags { get; set; }
#nullable enable                
        public decimal? Max_Supply { get; set; }        
        public decimal? Circulating_Supply { get; set; }        
        public decimal? Total_Supply { get; set; }
        public Platform? Platform { get; set; }
#nullable disable
        public int CMC_Rank { get; set; }
        public DateTime Last_Updated { get; set; }
        
        [ForeignKey("CryptoCMC_Ref_id")]
        public List<CryptoQuote> Quote { get; set; }
    }
}
