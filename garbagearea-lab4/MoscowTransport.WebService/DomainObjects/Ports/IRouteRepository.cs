using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace GarbageArea.DomainObjects.Ports
{
    public interface IReadOnlyRouteRepository
    {
        Task<Area> GetRoute(long id);

        Task<IEnumerable<Area>> GetAllAreas();

        Task<IEnumerable<Area>> QueryRoutes(ICriteria<Area> criteria);

    }

    public interface IRouteRepository
    {
        Task AddArea(Area route);

        Task RemoveRoute(Area route);

        Task UpdateRoute(Area route);
    }
}
