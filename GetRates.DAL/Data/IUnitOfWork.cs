using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetRates.DAL.Data
{
    public interface IUnitOfWork : IDisposable
    {        
        ICrypto Cryptos { get; }
        int Complete();
        Task<int> CompleteAsync();
    }
}
