using GarbageArea.DomainObjects;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using GarbageArea.ApplicationServices.Ports.Gateways.Database;

namespace GarbageArea.InfrastructureServices.Gateways.Database
{
    public class TypeEFSqliteGateway : ITypeDatabaseGateway
    {
        private readonly TypeContext _transportContext;

        public TypeEFSqliteGateway(TypeContext transportContext)
            => _transportContext = transportContext;

        public async Task<Route> GetRoute(long id)
           => await _transportContext.Routes.Include(r => r.Organization).Where(r => r.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<Route>> GetAllRoutes()
            => await _transportContext.Routes.Include(r => r.Organization).ToListAsync();
          
        public async Task<IEnumerable<Route>> QueryRoutes(Expression<Func<Route, bool>> filter)
            => await _transportContext.Routes.Include(r => r.Organization).Where(filter).ToListAsync();

        public async Task AddRoute(Route route)
        {
            _transportContext.Routes.Add(route);
            await _transportContext.SaveChangesAsync();
        }

        public async Task UpdateRoute(Route route)
        {
            _transportContext.Entry(route).State = EntityState.Modified;
            await _transportContext.SaveChangesAsync();
        }

        public async Task RemoveRoute(Route route)
        {
            _transportContext.Routes.Remove(route);
            await _transportContext.SaveChangesAsync();
        }


        public async Task<TransportOrganization> GetTransportOrganization(long id)
            => await _transportContext.TransportOrganizations.Where(to => to.Id == id).FirstOrDefaultAsync();

        public async Task<IEnumerable<TransportOrganization>> GetAllTransportOrganizations()
            => await _transportContext.TransportOrganizations.ToListAsync();

        public async Task<IEnumerable<TransportOrganization>> QueryTransportOrganizations(Expression<Func<TransportOrganization, bool>> filter)
            => await _transportContext.TransportOrganizations.Where(filter).ToListAsync();

        public async Task AddTransportOrganization(TransportOrganization transportOrganization)
        {
            _transportContext.TransportOrganizations.Add(transportOrganization);
            await _transportContext.SaveChangesAsync();
        }

        public async Task UpdateTransportOrganization(TransportOrganization transportOrganization)
        {
            _transportContext.Entry(transportOrganization).State = EntityState.Modified;
            await _transportContext.SaveChangesAsync();
        }

        public async Task RemoveTransportOrganization(TransportOrganization transportOrganization)
        {
            _transportContext.TransportOrganizations.Remove(transportOrganization);
            await _transportContext.SaveChangesAsync();
        }
    }
}
