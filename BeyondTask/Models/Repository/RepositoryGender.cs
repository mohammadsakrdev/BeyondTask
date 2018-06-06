using BeyondTask.Models.Contracts;
using BeyondTask.Models.Entities;
using BeyondTask.Models.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    class RepositoryGender : Repository<Gender>, IRepositoryGender
    {
        public RepositoryGender(RepositoryContext repositoryContext)
            :base(repositoryContext)
        {
        }
    }
}
