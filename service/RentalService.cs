using System;
using System.Collections.Generic;
using System.Linq;
using videostore_be.Models;

namespace videostore_be.service
{
    public class RentalService
    {
        private readonly IRepository<Videos> _videoRepository;

        private readonly IRepository<Customer> _customerRepository;

        public RentalService(IRepository<Videos> videoRepository, IRepository<Customer> customerRepository)
        {
            _videoRepository = videoRepository;
            _customerRepository = customerRepository;
        }
    }
}