using AssessmentAppBackend.Models;
using AssessmentAppBackend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AssessmentAppBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpPost]
        public JsonResult AddCustomer(Customer customer)
        {
            #region Calculate age
            int BirthYear = customer.DateOfBirth.Year;
            int currentYear= DateTime.Now.Year;
            int age;

            age = currentYear - BirthYear;
            #endregion


            customer.age = age;
            string results = _customerRepository.AddCustomer(customer);

            return new JsonResult(results);
        }

        [HttpGet]
        public JsonResult GetCustomers()
        {
            
           var customers= _customerRepository.GetCustomers();

           return new JsonResult(customers);
        }

        [HttpGet("id")]
        public JsonResult GetCustomerByID(int id)
        {
            var customer= _customerRepository.GetCustomerById(id);

            return new JsonResult(customer);
        }

        [HttpPost]
        public JsonResult UpdateCustomer(Customer customer)
        {
           string results= _customerRepository.UpdateCustomer(customer);

            return new JsonResult(results);
        }

        [HttpPost]
        public JsonResult DeleteCustomer(int id)
        {
            string results= _customerRepository.DeleteCustomer(id);

            return new JsonResult(results);
        }
    }
}
