using GarbageArea.DomainObjects;
using GarbageArea.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GarbageArea.ApplicationServices.GetAreaListUseCase
{
    public class AreaTypeCriteria : ICriteria<Route>
    {
        public long AreaTypeId { get; }

        public AreaTypeCriteria(long areaTypeId)
            => AreaTypeId = areaTypeId;

        public Expression<Func<Area, bool>> Filter
            => (r => r.Type.Id == AreaTypeId);
    }
}
