using BeyondTask.Models.Entities.ExtendedModels;
using BeyondTask.Models.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeyondTask.Models.Contracts
{
    public interface IRepositoryCustomer : IRepository<Customer>
    {
        IEnumerable<Customer> GetAllCustomer();
        Customer GetCustomerById(int customerId);
        ExtendedCustomer GetCustomerWithDetails(int customerId);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer dbCustomer, Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
