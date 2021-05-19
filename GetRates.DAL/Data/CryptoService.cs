using GetRates.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using System.Linq;
using System.Diagnostics;
using System.Dynamic;
using Microsoft.EntityFrameworkCore;

namespace GetRates.DAL.Data
{
    public class CryptoService : CryptoBase<Crypto>, ICrypto
    {
        private string _apiKey = "f2bfb44e-db98-4b5e-bab5-1f2600d13fae";
        private string _baseUrl = "https://pro-api.coinmarketcap.com/v1/cryptocurrency";

        public CryptoContext CryptoContext
        {
            get { return _dbContext as CryptoContext; }
        }

        public CryptoService(CryptoContext context) : base(context)
        {
        }

        public async Task<List<Crypto>> GetLatestListingsAsync(List<string> convertParams)
        {
            List<CryptoJson> jsonList = await _getLatestListingsAsync(convertParams);
            List<Crypto> cryptos = ConvertJsonToDBModel(jsonList);

            bool addList = await AddToDb(cryptos);
            if (addList)
                return cryptos;
            else
                return new List<Crypto>();
        }
        private List<Crypto> ConvertJsonToDBModel(List<CryptoJson> jsonList)
        {
            List<Crypto> cryptos = new List<Crypto>();
            foreach (CryptoJson cj in jsonList)
            {
                Crypto Crypto = new Crypto
                {
                    ApiRefId = cj.Id,
                    Name = cj.Name,
                    Symbol = cj.Symbol,
                    Slug = cj.Slug,
                    Num_Market_Pairs = cj.Num_Market_Pairs,
                    Date_Added = cj.Date_Added,
                    Max_Supply = cj.Max_Supply,
                    Circulating_Supply = cj.Circulating_Supply,
                    Total_Supply = cj.Total_Supply,
                    CMC_Rank = cj.CMC_Rank,
                    Last_Updated = cj.Last_Updated
                };

                string tags = String.Join(",", cj.Tags.Select(x => x.ToString()).ToArray());
                Crypto.Tags = tags;

                Crypto.Platform = new Platform();

                if (cj.Platform == null)
                {
                    Crypto.Platform = null;
                }
                else
                {
                    Crypto.Platform.Name = cj.Platform.Name;
                    Crypto.Platform.Symbol = cj.Platform.Symbol;
                    Crypto.Platform.Slug = cj.Platform.Slug;
                    Crypto.Platform.token_address = cj.Platform.token_address;
                    Crypto.Platform.Json_Ref_Id = cj.Id;
                }

                Crypto.Quote = new List<CryptoQuote>();

                foreach (string quoteKey in cj.Quote.Keys)
                {
                    CryptoQuoteJson cqj = cj.Quote[quoteKey];
                    CryptoQuote cq = new CryptoQuote();
                    cq.Price = cqj.Price;
                    cq.Volume_24h = cqj.Volume_24h;
                    cq.Percent_Change_1h = cqj.Percent_Change_1h;
                    cq.Percent_Change_24h = cqj.Percent_Change_24h;
                    cq.Percent_Change_7d = cqj.Percent_Change_7d;
                    cq.Percent_Change_30d = cqj.Percent_Change_30d;
                    cq.Percent_Change_60d = cqj.Percent_Change_60d;
                    cq.Percent_Change_90d = cqj.Percent_Change_90d;
                    cq.Market_Cap = cqj.Market_Cap;
                    cq.Last_Updated = cqj.Last_Updated;
                    cq.QuoteCurrency = quoteKey;

                    Crypto.Quote.Add(cq);
                }

                cryptos.Add(Crypto);
            }

            return cryptos;
        }
        private async Task<List<CryptoJson>> _getLatestListingsAsync(List<string> convertParams)
        {
            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", _apiKey);
            client.Headers.Add("Accepts", "application/json");

            string listingsURL = BuildGetLatestURL(convertParams);            
            string response = await client.DownloadStringTaskAsync(listingsURL);
            ListingRoot listingRoot = JsonConvert.DeserializeObject<ListingRoot>(response);

            return listingRoot.data;
        }

        private async Task<bool> AddToDb(List<Crypto> cryptos)
        {
            try
            {                
                CryptoContext.Cryptos.RemoveRange(await GetAllFromDbAsync());
                await AddRangeAsync(cryptos);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Crypto>> GetAllFromDbAsync()
        {
            return await CryptoContext.Cryptos
                .Include(x => x.Platform)
                .Include(x => x.Quote)
                .ToListAsync();
        }

        private string BuildGetLatestURL(List<string> convertParams)
        {
            string convertParam = String.Join(",", convertParams.Select(x => x.ToString()).ToArray());
            return $"{_baseUrl}/listings/latest?convert={convertParam}";
        }
    }
}
