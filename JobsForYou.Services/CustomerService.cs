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
    public class CustomerService
    {
        private readonly Guid _customerUserId;
        public CustomerService(Guid customerUserId)
        {
            _customerUserId = customerUserId;
        }
        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {

                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Location = model.Location,                  
                    UserId=_customerUserId
                    

                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CustomerListItem> GetCustomers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Customers

                    .Select(
                        e =>
                        new CustomerListItem
                        {
                            CustomerId = e.CustomerId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            JobSkills = e.JobList,
                            Location = e.Location
                        });
                return query.ToArray();
            }
        }
        public CustomerDetail GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.CustomerId == id);
                return
                    new CustomerDetail
                    {
                        CustomerId = entity.CustomerId,
                        FirstName = entity.FirstName,
                        LastName = entity.LastName,
                        Location = entity.Location,
                        JobSkills = entity.JobList
                    };
            }
        } 
        //public int GetCustomerId(Guid id)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var entity =
        //            ctx
        //            .Customers
        //            .Single(e => e.UserId == id);

        //        return entity.CustomerId;
                    
                    
        //    }
        //}
        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.CustomerId == model.CustomerId);
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.Location = model.Location;
                entity.JobList = model.JobSkills;

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
