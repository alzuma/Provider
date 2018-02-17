using System.Collections.Generic;

namespace Provider.WebApi.Tests.Controllers.Repositories.interfaces
{
    public interface IValueRepository
    {
        IEnumerable<string> GetValues();
    }
}