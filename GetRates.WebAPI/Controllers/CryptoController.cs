using GetRates.DAL.Data;
using GetRates.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetRates.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CryptoController : ControllerBase
    {
        private readonly IUnitOfWork _IUnitOfWork;
        public CryptoController(IUnitOfWork IUnitOfWork)
        {
            _IUnitOfWork = IUnitOfWork;
        }
        
        [HttpGet]
        [Route("latest/{converts}")]
        public async Task<List<Crypto>> GetLatestListingsAsync(string converts)
        {
            List<string> convertList = converts.Split(',').ToList();
            await _IUnitOfWork.Cryptos.GetLatestListingsAsync(convertList);

            return await _IUnitOfWork.Cryptos.GetAllFromDbAsync();
        }

        [HttpGet]
        [Route("listings")]
        public async Task<List<Crypto>> GetDbListings()
        {             
            return await _IUnitOfWork.Cryptos.GetAllFromDbAsync();
        }
    }
}
