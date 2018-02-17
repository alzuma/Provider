using System.Collections.Generic;
using Provider.WebApi.Tests.Controllers.Repositories.interfaces;

namespace Provider.WebApi.Tests.Controllers.Repositories
{
    public class ValueRepository: IValueRepository
    {
        private readonly string _connectionString;

        public ValueRepository()
        {
        }

        public ValueRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<string> GetValues()
        {
            return _connectionString == null ? new[] {"value1", "value2"} : new[] { "value1", "value2", "value3" };
        }
    }
}