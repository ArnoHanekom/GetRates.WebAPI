using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GetRates.DAL.Data
{
    public class UnitOfWorkService : IUnitOfWork
    {        
        private readonly CryptoContext _cryptoContext;
        public UnitOfWorkService(CryptoContext cryptoContext)
        {
            _cryptoContext = cryptoContext;         
            Cryptos = new CryptoService(_cryptoContext);
        }

        public ICrypto Cryptos { get; private set; }

        public int Complete()
        {
            return _cryptoContext.SaveChanges();
        }

        public async Task<int> CompleteAsync()
        {
            return await _cryptoContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _cryptoContext.Dispose();
        }
    }
}
