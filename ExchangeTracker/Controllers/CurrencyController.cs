using ExchangeTracker.Models;
using ExchangeTracker.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ExchangeTracker.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CurrencyController : Controller
    {
        private readonly ICurrencyService currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type= typeof(IEnumerable<CurrencyModel>))]
        public IActionResult GetCurrencies() {
            var currencies =  currencyService.GetAllCurrencies();

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(currencies);
        }
        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CurrencyModel>))]
        public IActionResult GetCurrencyByAbbreviation(String abbreviation)
        {
            var currency = currencyService.GetCurrencyByAbbreviation(abbreviation);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(currency);
        }
    }
}
