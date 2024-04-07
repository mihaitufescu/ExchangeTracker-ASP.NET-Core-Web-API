using AutoMapper;
using ExchangeTracker.DAL.DBO;
using ExchangeTracker.DAL.Repository;
using ExchangeTracker.DAL.Repository.Interfaces;
using ExchangeTracker.Models;
using ExchangeTracker.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace ExchangeTracker.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class CurrencyEntryController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ICurrencyEntryService _currencyEntryService;
        private readonly ICurrencyEntryRepository _currencyEntryRepository;

        public CurrencyEntryController(IMapper mapper, ICurrencyEntryService currencyEntryService,ICurrencyEntryRepository currencyEntryRepository)
        {
            _mapper = mapper;
            _currencyEntryService = currencyEntryService;
            _currencyEntryRepository = currencyEntryRepository;
        }

        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CurrencyEntryModel>))]
        public IActionResult GetAllCurrencyEntries()
        {
            var currencyEntries = _currencyEntryService.GetAllCurrencyEntries();

            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(currencyEntries);
        }
        [HttpGet("[action]")]
        [ProducesResponseType(200, Type = typeof(Decimal))]
        public IActionResult GetCurrencyValueById(int id)
        {
            var value = _currencyEntryService.GetCurrencyValueById(id);
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(value);
        }
    }
}
