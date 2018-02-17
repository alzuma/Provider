using System.Collections.Generic;
using Provider.interfaces;
using Provider.WebApi.Tests.Controllers.Repositories;
using Provider.WebApi.Tests.Controllers.Repositories.interfaces;

namespace Provider.WebApi.Tests.Controllers.Services
{
    public class ValueService
    {
        private readonly IValueRepository _valueRepository;

        public ValueService(IValueRepository valueRepository)
        {
            _valueRepository = valueRepository;
        }

        public ValueService(IProvider<ValueRepository> provider,  string connectionString)
        {
            _valueRepository = provider.Get(connectionString);
        }

        public IEnumerable<string> GetValues()
        {
            return _valueRepository.GetValues();
        }
    }
}