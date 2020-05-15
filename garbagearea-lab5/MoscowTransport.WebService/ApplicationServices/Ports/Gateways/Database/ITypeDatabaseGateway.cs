using GarbageArea.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GarbageArea.ApplicationServices.Ports.Gateways.Database
{
    public interface ITypeDatabaseGateway
    {
        Task AddRoute(Route route);

        Task RemoveRoute(Route route);

        Task UpdateRoute(Route route);

        Task<Route> GetRoute(long id);

        Task<IEnumerable<Route>> GetAllRoutes();

        Task<IEnumerable<Route>> QueryRoutes(Expression<Func<Route, bool>> filter);


        Task AddTransportOrganization(TransportOrganization transportOrganization);

        Task UpdateTransportOrganization(TransportOrganization transportOrganization);

        Task RemoveTransportOrganization(TransportOrganization transportOrganization);

        Task<TransportOrganization> GetTransportOrganization(long id);

        Task<IEnumerable<TransportOrganization>> GetAllTransportOrganizations();

        Task<IEnumerable<TransportOrganization>> QueryTransportOrganizations(Expression<Func<TransportOrganization, bool>> filter);
    }
}
