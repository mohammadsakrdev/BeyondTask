
using BeyondTask.Models.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BeyondTask.Models.Entities.ExtendedModels
{
    public class ExtendedCustomer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int GenderId { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }

        public Gender Gender { get; set; }

        public ExtendedCustomer()
        {
        }

        public ExtendedCustomer(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            DateOfBirth = customer.DateOfBirth;
            GenderId = customer.GenderId;
            Address = customer.Address;
            PhoneNumber = customer.PhoneNumber;
            Email = customer.Email;
            Notes = customer.Notes;
        }
    }
}
