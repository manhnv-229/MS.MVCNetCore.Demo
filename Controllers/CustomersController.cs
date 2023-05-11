using JWTASPNetCore.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace JWTASPNetCore.Controllers
{
    [Authorize]
    public class CustomersController : Controller
    {
        private readonly IConfiguration _config;
        private readonly ICustomerRepository _repository;
        private readonly ITokenService _tokenService;

        public CustomersController(IConfiguration config, ICustomerRepository repository, ITokenService tokenService)
        {
            _config = config;
            _repository = repository;
            _tokenService = tokenService;
        }


        public IActionResult Index()
        {
            var model = _repository.GetCustomers();
            return View(model);
        }
    }
}
