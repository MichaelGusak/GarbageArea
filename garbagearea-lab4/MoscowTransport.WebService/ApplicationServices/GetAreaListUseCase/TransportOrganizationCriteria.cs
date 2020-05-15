using GarbageArea.DomainObjects;
using GarbageArea.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GarbageArea.ApplicationServices.GetRouteListUseCase
{
    public class TransportOrganizationCriteria : ICriteria<Area>
    {
        public long TransportOrganizationId { get; }

        public TransportOrganizationCriteria(long transportOrganizationId)
            => TransportOrganizationId = transportOrganizationId;

        public Expression<Func<Area, bool>> Filter
            => (r => r.Organization.Id == TransportOrganizationId);
    }
}
