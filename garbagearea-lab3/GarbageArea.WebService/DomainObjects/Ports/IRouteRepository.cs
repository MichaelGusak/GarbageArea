using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace MoscowTransport.DomainObjects.Ports
{
    public interface IReadOnlyRouteRepository
    {
        Task<Route> GetRoute(long id);

        Task<IEnumerable<Route>> GetAllRoutes();

        Task<IEnumerable<Route>> QueryRoutes(ICriteria<Route> criteria);

    }

    public interface IRouteRepository
    {
        Task AddRoute(Route route);

        Task RemoveRoute(Route route);

        Task UpdateRoute(Route route);
    }
}
