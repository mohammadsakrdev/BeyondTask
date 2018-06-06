using BeyondTask.Models.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeyondTask.Models.Entities.Extensions
{
    public static class CustomerExtensions
    {
        public static void Map(this Customer dbCustomer, Customer customer)
        {
            dbCustomer.Name = customer.Name;
            dbCustomer.Address = customer.Address;
            dbCustomer.DateOfBirth = customer.DateOfBirth;
            dbCustomer.GenderId = customer.GenderId;
            dbCustomer.PhoneNumber = customer.PhoneNumber;
            dbCustomer.Email = customer.Email;
            dbCustomer.Notes = customer.Notes;
        }
    }
}
