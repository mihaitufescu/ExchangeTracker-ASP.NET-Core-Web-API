using ExchangeTracker.Services.Interfaces;
using Hangfire;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExchangeTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyApiController : Controller
    {
        private readonly string apiUrl = "https://www.bnr.ro/nbrfxrates.xml";
        private readonly HttpClient client;
        private readonly IXmlParserService _parserService;

        public CurrencyApiController(IHttpClientFactory httpClientFactory, IXmlParserService parserService)
        {
            client = httpClientFactory.CreateClient();
            _parserService = parserService;
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        [HttpGet("[action]")]
        public async Task<IActionResult> FetchCurrencyRates()
        {
            try
            {
                var response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                var xmlContent = await response.Content.ReadAsStringAsync();
                bool updateSuccess = await _parserService.UpdateCurrencyRatesAsync(xmlContent);
                if (!updateSuccess){
                    return StatusCode(500, "Error updating currency rates currency rates. Check parser service!");
                }
                return StatusCode(200, "Currency rates were updated succesfully!");
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error fetching currency rates: {ex.Message}");
            }
        }
        [HttpGet("[action]")]
        public IActionResult ScheduleFetchCurrencyRates()
        {
            RecurringJob.AddOrUpdate("FetchCurrencyRates", () => FetchCurrencyRates(), Cron.Daily(13)); // Executes every day at 1 PM
            return Ok("Currency rate fetching scheduled successfully");
        }
    }
}
