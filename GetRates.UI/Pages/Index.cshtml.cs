using GetRates.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace GetRates.UI.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string currency { get; set; }
        public List<Crypto> DbList { get; private set; }
        public List<SelectListItem> currencyOptions = new List<SelectListItem> {
            new SelectListItem{ Value = "USD", Text="USD" },
            new SelectListItem{ Value = "ZAR", Text="ZAR" },
            new SelectListItem{ Value = "EUR", Text="EUR" }
            };

        private const string _baseUrl = "https://localhost:44355/api/crypto";

        public IndexModel()
        {            
            DbList = GetDbListings().Result;
        }

        public async Task<List<Crypto>> GetDbListings()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_baseUrl}/listings"))
                {                    
                    if(response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        return JsonConvert.DeserializeObject<List<Crypto>>(apiResponse);
                    }
                    else
                    {
                        return new List<Crypto>();
                    }
                }
            }
        }
        public async Task<IActionResult> OnGetExternalListings()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_baseUrl}/latest/{currency}"))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        DbList = JsonConvert.DeserializeObject<List<Crypto>>(apiResponse);
                    }                    
                }
            }

            return Page();
        }
    }

    /// <summary>
    /// To form part of error logging as a response verification/error message or success list container
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class APIResponse<T> where T : class
    {
        public HttpStatusCode StatusCode { get; set; }
        public string ReasonPhrase { get; set; }
        public T Result { get; set; }
    }
}
