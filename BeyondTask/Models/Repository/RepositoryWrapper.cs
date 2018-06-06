using BeyondTask.Models.Contracts;
using BeyondTask.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IRepositoryCustomer _customer;
        private IRepositoryGender _gender;

        public IRepositoryCustomer Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new RepositoryCustomer(_repoContext);
                }

                return _customer;
            }
        }

        public IRepositoryGender Gender
        {
            get
            {
                if (_gender == null)
                {
                    _gender = new RepositoryGender(_repoContext);
                }

                return _gender;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
    }
}
