using ElevenNote.Data;
using JobsForYou.Data;
using JobsForYou.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobsForYou.Services
{
    public class ProviderService
    {
        private readonly Guid _providerUserId;
        public ProviderService(Guid customerUserId)
        {
            _providerUserId = customerUserId;
        }
        public bool CreateProvider(ProviderCreate model)
        {
            var entity =
                new Provider()
                {
                    ProviderId=model.ProviderId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Location = model.Location,
                                 
                    
                   

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Providers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ProviderListItem> GetProviders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Providers
                    //.Where(e.guid == _thisguid)
                    .Select(
                        e =>
                        new ProviderListItem
                        {
                            ProviderId = e.ProviderId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            JobSkills = e.JobSkills,
                            Location = e.Location,
                           
                            
                        });
                return query.ToArray();
            }
        }
        public ProviderDetail GetProviderById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Providers
                    .Single(e => e.ProviderId == id);
                return
                    new ProviderDetail
                    {
                        ProviderId = entity.ProviderId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Location = entity.Location,
                        JobSkills = entity.JobSkills,
                        
                    };
            }
        }
        public bool UpdateProvider(ProviderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Providers
                    .Single(e => e.ProviderId == model.ProviderId);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Location = model.Location;
                entity.JobSkills = model.JobSkills;
                

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteCustomer(int customerId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.CustomerId == e.CustomerId);

                ctx.Customers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}