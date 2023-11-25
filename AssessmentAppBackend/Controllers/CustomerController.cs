using AssessmentAppBackend.Models;
using AssessmentAppBackend.Models.ViewModels;
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

        [HttpPost("AddCustomer")]
        public JsonResult AddCustomer(Customer customer)
        {
            #region Calculate age
            int BirthYear = customer.DateOfBirth.Year;
            int currentYear= DateTime.Now.Year;
            int age;

            age = currentYear - BirthYear;

            if(customer.DateOfBirth<DateTime.Now)
            {
                age = age - 1;
            }
            #endregion

            customer.CustomerID = Guid.NewGuid();
            customer.DateCreated = DateTime.Now.ToString("dd/MM/yyyy");
            customer.UserName = customer.FirstName + " " + customer.LastName;
            customer.isDeleted = false;
            


            customer.age = age;
            string results = _customerRepository.AddCustomer(customer);

            return new JsonResult(results);
        }

        [HttpGet("GetCustomers")]
      
        public JsonResult GetCustomers()
        {
            
           var customersList= _customerRepository.GetCustomers();

            List<CustomerViewModel> Customers= new List<CustomerViewModel>();

            foreach (var cust in customersList)
            {
                CustomerViewModel customer= new CustomerViewModel();

                customer.CustomerID = cust.CustomerID;
                customer.UserName = cust.UserName;
                customer.FirstName = cust.FirstName;
                customer.LastName = cust.LastName;
                customer.EmailAddress= cust.EmailAddress;
                customer.age = cust.age;
                customer.DateOfBirth = cust.DateOfBirth.ToString("dd/MM/yyyy");
                customer.DateCreated = cust.DateCreated;
                customer.DateEdited = cust.DateEdited;
                customer.isDeleted = cust.isDeleted;

                Customers.Add(customer);
            }

           return new JsonResult(Customers);
        }

        [HttpGet("GetCustomerByID/{id}")]
        
        public JsonResult GetCustomerByID(Guid id)
        {
            var cust= _customerRepository.GetCustomerById(id);

           return new JsonResult(cust);
        }

        [HttpPost("UpdateCustomer")]
        
        public JsonResult UpdateCustomer(Customer customer)
        {
            #region Calculate age
            int BirthYear = customer.DateOfBirth.Year;
            int currentYear = DateTime.Now.Year;
            int age;

            age = currentYear - BirthYear;

            if (customer.DateOfBirth < DateTime.Now)
            {
                age = age - 1;
            }
            #endregion

            customer.age = age;

            customer.DateEdited = DateTime.Now.ToString("dd/MM/yyyy");

            string results= _customerRepository.UpdateCustomer(customer);

            return new JsonResult(results);
        }

        [HttpPost("DeleteCustomer/{id}")]
        public JsonResult DeleteCustomer(Guid id)
        {
            string results= _customerRepository.DeleteCustomer(id);

            return new JsonResult(results);
        }
    }
}
