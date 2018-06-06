using System;
using System.Collections.Generic;
using System.Text;

namespace BeyondTask.Models.Contracts
{
    public interface IRepositoryWrapper
    {
        IRepositoryCustomer Customer { get; }
        IRepositoryGender Gender { get; }
    }
}
