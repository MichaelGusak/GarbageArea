using GarbageArea.ApplicationServices.Ports.Gateways.Database;
using GarbageArea.DomainObjects;
using GarbageArea.DomainObjects.Ports;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GarbageArea.ApplicationServices.Repositories
{
    public class DbAreaTypeRepository : IReadOnlyTransportOrganizationRepository,
                                                     ITransportOrganizationRepository
    {
        private readonly ITypeDatabaseGateway _databaseGateway;

        public DbAreaTypeRepository(ITypeDatabaseGateway databaseGateway)
            => _databaseGateway = databaseGateway;

        public async Task<TransportOrganization> GetTransportOrganization(long id)
            => await _databaseGateway.GetTransportOrganization(id);

        public async Task<IEnumerable<TransportOrganization>> GetAllTransportOrganizations()
            => await _databaseGateway.GetAllTransportOrganizations();

        public async Task<IEnumerable<TransportOrganization>> QueryTransportOrganizations(ICriteria<TransportOrganization> criteria)
            => await _databaseGateway.QueryTransportOrganizations(criteria.Filter);

        public async Task AddTransportOrganization(TransportOrganization transportOrganization)
            => await _databaseGateway.AddTransportOrganization(transportOrganization);

        public async Task UpdateTransportOrganization(TransportOrganization transportOrganization)
            => await _databaseGateway.UpdateTransportOrganization(transportOrganization);

        public async Task RemoveTransportOrganization(TransportOrganization transportOrganization)
            => await _databaseGateway.RemoveTransportOrganization(transportOrganization);
    }
}
