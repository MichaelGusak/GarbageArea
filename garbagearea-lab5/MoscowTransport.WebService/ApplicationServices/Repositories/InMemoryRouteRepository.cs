using GarbageArea.DomainObjects;
using GarbageArea.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GarbageArea.ApplicationServices.Repositories
{
    public class InMemoryRouteRepository : IReadOnlyRouteRepository,
                                           IRouteRepository 
    {
        private readonly List<Route> _routes = new List<Route>();

        public InMemoryRouteRepository(IEnumerable<Route> routes = null)
        {
            if (routes != null)
            {
                _routes.AddRange(routes);
            }
        }

        public Task AddRoute(Route route)
        {
            _routes.Add(route);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Route>> GetAllRoutes()
        {
            return Task.FromResult(_routes.AsEnumerable());
        }

        public Task<Route> GetRoute(long id)
        {
            return Task.FromResult(_routes.Where(r => r.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<Route>> QueryRoutes(ICriteria<Route> criteria)
        {
            return Task.FromResult(_routes.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveRoute(Route route)
        {
            _routes.Remove(route);
            return Task.CompletedTask;
        }

        public Task UpdateRoute(Route route)
        {
            var foundRoute = GetRoute(route.Id).Result;
            if (foundRoute == null)
            {
                AddRoute(route);
            }
            else
            {
                if (foundRoute != route)
                {
                    _routes.Remove(foundRoute);
                    _routes.Add(route);
                }
            }
            return Task.CompletedTask;
        }
    }
}
