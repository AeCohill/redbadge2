using ElevenNote.Data;
using JobsForYou.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JobsForYou.Models
{
    public class JobService
    {
        private readonly Guid _userId;

        public JobService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateJob(JobCreate model)
        {
            var customerId = GetCustomerId(_userId);
            var providerId = GetProviderId(_userId);
           
            var entity =
            new Job()
            {      
                CustomerId = customerId,
                ProviderId = providerId,
                JobType = model.JobType,
                Location = model.Location,
                Description = model.Description,                
                CreatedUtc = DateTimeOffset.Now
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Jobs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<JobListItem> GetJobs()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Jobs
                    .Select(
                        e =>
                        new JobListItem
                        {
                            JobId=e.JobId,
                            JobType = e.JobType,
                            Location = e.Location,
                            Description = e.Description,
                            ModifiedUtc = DateTimeOffset.Now
                        }
                        );
                return query.ToArray();
            }
        }
        public JobListItem GetJobById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Jobs
                    .Single(e => e.JobId == id);
                return
                    new JobListItem
                    {
                        JobId=entity.JobId,
                        CustomerId = entity.CustomerId,
                        JobType = entity.JobType,
                        Location = entity.Location,
                        Description = entity.Description,
                        ProviderId = entity.ProviderId,
                        ModifiedUtc = DateTimeOffset.Now
                    };
            }
        }

        public bool UpdateJob(JobEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Jobs
                    .Single(e => e.JobId == model.JobId);
                entity.CustomerId = entity.CustomerId;
                entity.JobType = entity.JobType;
                entity.Location = entity.Location;
                entity.Description = entity.Description;
                entity.ProviderId = entity.ProviderId;
                entity.ModifiedUtc = DateTimeOffset.Now;

                return ctx.SaveChanges() == 1;
            }
        }
        
        public bool DeleteJob(int jobId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Jobs
                    .Single(e => e.JobId == jobId);

                ctx.Jobs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        public int? GetCustomerId(Guid id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.UserId == id);
                if (entity != null)                
                    return entity.CustomerId;

                return null;
            }
        }
        public int? GetProviderId(Guid? id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Providers
                    .Single(e => e.UserId == id);
                if (entity != null)
                    return entity.ProviderId;

                return null;
            }
        }
    }
}
