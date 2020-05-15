using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace GarbageArea.DomainObjects.Ports
{
    public abstract class ReadOnlyGAreaRepositoryDecorator : IReadOnlyNodeRepository

    {

        private readonly IReadOnlyAreaRepository _GarbageAreaRepository;

        public ReadOnlyGAreaRepositoryDecorator(IReadOnlyAreaRepository GAreaRepository)

        {

            _TransferNodeRepository = GAreaRepository;

        }

        public virtual async Task<IEnumerable<GarbageArea>> GetAllAreas()

        {

            return await _GarbageAreaRepository?.GetAllAreas();

        }

        public virtual async Task<GarbageArea> GetArea(long id)

        {

            return await _GarbageAreaRepository?.GetArea(id);

        }

        public virtual async Task<IEnumerable<GarbageArea>> QueryAreas(ICriteria<GarbageArea> criteria)

        {

            return await _GarbageAreaRepository?.QueryAreas(criteria);

        }

    }

}