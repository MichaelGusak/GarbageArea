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
    public class InMemoryAreaTypenRepository : IReadOnlyTransportOrganizationRepository,
                                                           ITransportOrganizationRepository
    {
        private readonly List<TransportOrganization> _transportOrganizations = new List<TransportOrganization>();

        public InMemoryAreaTypenRepository(IEnumerable<TransportOrganization> transportOrganizations)
        {
            if (transportOrganizations != null)
            {
                _transportOrganizations.AddRange(transportOrganizations);
            }
        }

        public Task AddTransportOrganization(TransportOrganization transportOrganization)
        {
            _transportOrganizations.Add(transportOrganization);
            return Task.CompletedTask;
        }

        public Task<IEnumerable<TransportOrganization>> GetAllTransportOrganizations()
        {
            return Task.FromResult(_transportOrganizations.AsEnumerable());
        }

        public Task<TransportOrganization> GetAreaType(long id)
        {
            return Task.FromResult(_transportOrganizations.Where(r => r.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<TransportOrganization>> QueryTransportOrganizations(ICriteria<TransportOrganization> criteria)
        {
            return Task.FromResult(_transportOrganizations.Where(criteria.Filter.Compile()).AsEnumerable());
        }

        public Task RemoveTransportOrganization(TransportOrganization transportOrganization)
        {
            _transportOrganizations.Remove(transportOrganization);
            return Task.CompletedTask;
        }

        public Task UpdateTransportOrganization(TransportOrganization transportOrganization)
        {
            var foundTransportOrganization = GetAreaType(transportOrganization.Id).Result;
            if (foundTransportOrganization == null)
            {
                AddTransportOrganization(transportOrganization);
            }
            else
            {
                if (foundTransportOrganization != transportOrganization)
                {
                    _transportOrganizations.Remove(foundTransportOrganization);
                    _transportOrganizations.Add(transportOrganization);
                }
            }
            return Task.CompletedTask;
        }
    }
}
