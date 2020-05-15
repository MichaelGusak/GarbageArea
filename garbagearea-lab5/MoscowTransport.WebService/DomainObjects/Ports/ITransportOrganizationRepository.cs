using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace GarbageArea.DomainObjects.Ports
{
    public interface IReadOnlyTransportOrganizationRepository
    {
        Task<TransportOrganization> GetTransportOrganization(long id);

        Task<IEnumerable<TransportOrganization>> GetAllTransportOrganizations();

        Task<IEnumerable<TransportOrganization>> QueryTransportOrganizations(ICriteria<TransportOrganization> criteria);
    }

    public interface ITransportOrganizationRepository
    {
        Task AddTransportOrganization(TransportOrganization transportOrganization);

        Task UpdateTransportOrganization(TransportOrganization transportOrganization);

        Task RemoveTransportOrganization(TransportOrganization transportOrganization);
    }
}
