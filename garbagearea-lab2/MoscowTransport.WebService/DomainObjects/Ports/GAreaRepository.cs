using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace GarbageArea.DomainObjects.Ports
{
    public interface IReadOnlyAreaRepository
    {
        Task<GarbageArea> GetArea(long id);

        Task<IEnumerable<GarbageArea>> GetAllAreas();

        Task<IEnumerable<GarbageArea>> QueryAreas(ICriteria<GarbageArea> criteria);

    }

    public interface GAreaRepository
    {
        Task AddArea(GarbageArea area);

        Task RemoveArea(GarbageArea area);

        Task UpdateArea(GarbageArea area);
    }
}

