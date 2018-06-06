
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BeyondTask.Models.Entities.Models;
using BeyondTask.Models.Entities;
using BeyondTask.Models.Contracts;
using BeyondTask.Models.Entities.ExtendedModels;
using BeyondTask.Models.Entities.Extensions;

namespace Repository
{
    public class RepositoryCustomer : Repository<Customer>, IRepositoryCustomer
    {
        public RepositoryCustomer(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
        }

        public void CreateCustomer(Customer customer)
        {
            //customer.Id = Guid.NewGuid();
            Create(customer);
            Save();
        }

        public void DeleteCustomer(Customer customer)
        {
            Delete(customer);
            Save();
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            return FindAll()
                .OrderBy(c => c.Name);
        }

        public Customer GetCustomerById(int customerId)
        {
            return FindByCondition(c => c.Id.Equals(customerId))
            .DefaultIfEmpty(new Customer())
            .FirstOrDefault();
        }

        public ExtendedCustomer GetCustomerWithDetails(int customerId)
        {
            Customer c = GetCustomerById(customerId);
            return new ExtendedCustomer(c)
            {
                Gender = RepositoryContext.Gender
                .FirstOrDefault(a => a.Id == c.GenderId)
            };
        }

        public void UpdateCustomer(Customer dbCustomer, Customer customer)
        {
            dbCustomer.Map(customer);
            Update(dbCustomer);
            Save();
        }
    }
}
