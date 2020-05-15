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
    public class InMemoryAreaRepository : IReadOnlyRouteRepository,
                                           IRouteRepository 
    {
        private readonly List<Area> _areas = new List<Area>();

        public InMemoryAreaRepository(IEnumerable<Area> areas = null)
        {
            if (areas != null)
            {
                _areas.AddRange(areas);
            }
        }

        public Task AddArea(Area route)
        {
            _areas.Add(route);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<Area>> GetAllAreas()
        {
            return Task.FromResult(_areas.AsEnumerable());
        }

        public Task<Area> GetRoute(long id)
        {
            return Task.FromResult(_areas.Where(r => r.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<Area>> QueryRoutes(ICriteria<Area> criteria)
        {
            return Task.FromResult(_areas.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveRoute(Area route)
        {
            _areas.Remove(route);
            return Task.CompletedTask;
        }

        public Task UpdateRoute(Area route)
        {
            var foundRoute = GetRoute(route.Id).Result;
            if (foundRoute == null)
            {
                AddArea(route);
            }
            else
            {
                if (foundRoute != route)
                {
                    _areas.Remove(foundRoute);
                    _areas.Add(route);
                }
            }
            return Task.CompletedTask;
        }
    }
}
