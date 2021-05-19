using GetRates.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetRates.DAL.Data
{
    public interface ICrypto : ICryptoBase<Crypto>
    {
        public Task<List<Crypto>> GetLatestListingsAsync(List<string> convertParams);
        public Task<List<Crypto>> GetAllFromDbAsync();
    }
}
