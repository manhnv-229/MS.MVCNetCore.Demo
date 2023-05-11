using JWTASPNetCore.Models;
using System.Collections.Generic;

namespace JWTASPNetCore.Interfaces
{
    public interface ICustomerRepository
    {
        List<CustomerModel> GetCustomers();
    }
}
