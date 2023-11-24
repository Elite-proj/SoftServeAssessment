using AssessmentAppBackend.Models;

namespace AssessmentAppBackend.Services
{
    public interface ICustomerRepository
    {
        public List<Customer> GetCustomers();

        public string AddCustomer(Customer customer);
        public Customer GetCustomerById(int id);
        public string UpdateCustomer(Customer customer);
        public string DeleteCustomer(int id);
     }
}
