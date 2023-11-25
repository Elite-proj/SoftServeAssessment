using AssessmentAppBackend.Models;

namespace AssessmentAppBackend.Services
{
    public interface ICustomerRepository
    {
        public List<Customer> GetCustomers();

        public string AddCustomer(Customer customer);
        public Customer GetCustomerById(Guid id);
        public string UpdateCustomer(Customer customer);
        public string DeleteCustomer(Guid id);
     }
}
