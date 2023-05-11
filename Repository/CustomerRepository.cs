using JWTASPNetCore.Interfaces;
using JWTASPNetCore.Models;
using System.Collections.Generic;

namespace JWTASPNetCore.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<CustomerModel> _customers = new List<CustomerModel>();
        public CustomerRepository()
        {
            _customers.Add(new CustomerModel { CustomerID = 1, FullName = "Nguyễn Văn Mạnh" });
            _customers.Add(new CustomerModel { CustomerID = 1, FullName = "Nguyễn Quang Minh" });
            _customers.Add(new CustomerModel { CustomerID = 1, FullName = "Nguyễn Văn Mộng" });
            _customers.Add(new CustomerModel { CustomerID = 1, FullName = "Trịnh Thị Mơ" });
        }
        public List<CustomerModel> GetCustomers()
        {
            return _customers;
        }
    }
}
