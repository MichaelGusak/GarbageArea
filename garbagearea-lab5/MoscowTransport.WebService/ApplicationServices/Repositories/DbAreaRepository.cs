using GarbageArea.ApplicationServices.Ports.Gateways.Database;
using GarbageArea.DomainObjects;
using GarbageArea.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarbageArea.ApplicationServices.Repositories
{
    public class DbAreaRepository : IReadOnlyRouteRepository,
                                     IRouteRepository
    {
        private readonly ITypeDatabaseGateway _databaseGateway;

        public DbAreaRepository(ITypeDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<Route> GetRoute(long id)
            => await _databaseGateway.GetRoute(id);

        public async Task<IEnumerable<Route>> GetAllRoutes()
            => await _databaseGateway.GetAllRoutes();

        public async Task<IEnumerable<Route>> QueryRoutes(ICriteria<Route> criteria)
            => await _databaseGateway.QueryRoutes(criteria.Filter);

        public async Task AddRoute(Route route)
            => await _databaseGateway.AddRoute(route);

        public async Task RemoveRoute(Route route)
            => await _databaseGateway.RemoveRoute(route);

        public async Task UpdateRoute(Route route)
            => await _databaseGateway.UpdateRoute(route);
    }
}
