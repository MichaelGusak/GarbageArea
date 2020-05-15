using MoscowTransport.DomainObjects;
using MoscowTransport.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace MoscowTransport.ApplicationServices.GetRouteListUseCase
{
    public class TransportOrganizationCriteria : ICriteria<Route>
    {
        public long TransportOrganizationId { get; }

        public TransportOrganizationCriteria(long transportOrganizationId)
            => TransportOrganizationId = transportOrganizationId;

        public Expression<Func<Route, bool>> Filter
            => (r => r.Organization.Id == TransportOrganizationId);
    }
}
