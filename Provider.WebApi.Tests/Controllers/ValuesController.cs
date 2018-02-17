using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Provider.interfaces;
using Provider.WebApi.Tests.Controllers.Services;

namespace Provider.WebApi.Tests.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IProvider<ValueService> _provider;

        public ValuesController(IProvider<ValueService> provider)
        {
            _provider = provider;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return _provider.Get().GetValues();
        }

        [HttpGet("admin")]
        public IEnumerable<string> GetAdmin()
        {
            const string connectionString = "connectToAdminDB";
            return _provider.Get(connectionString).GetValues();
        }

    }
}
