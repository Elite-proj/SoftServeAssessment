using AssessmentAppBackend.Models;

namespace AssessmentAppBackend.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AssessmentAppDbContext _context;

        public CustomerRepository(AssessmentAppDbContext context)
        {
            _context = context;
        }

        public string AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);

            _context.SaveChanges();

            return "Created";
        }

        public string DeleteCustomer(int id)
        {
           var customer= _context.Customers.Find(id);

            if (customer != null)
            {
                Customer customer1 = new Customer();

                customer1.CustomerID = customer.CustomerID;
                customer1.FirstName = customer.FirstName;
                customer1.LastName = customer.LastName;
                customer1.UserName = customer.UserName;
                customer1.EmailAddress = customer.EmailAddress;
                customer1.DateOfBirth = customer.DateOfBirth;
                customer1.age = customer.age;
                customer.DateCreated= customer.DateCreated;
                customer1.DateEdited= DateTime.Now;
                customer1.isDeleted = true;

                _context.Customers.Update(customer1);
                _context.SaveChanges();

                return ("Deleted");

            }
            else
            {
                return ("failed");
            }

           
        }

        public Customer GetCustomerById(int id)
        {
            //Customer customer = new Customer();

            var customer = _context.Customers.Find(id);

            if (customer != null)
            {
                return customer;
            }
            else
                return null;

            
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> list = new List<Customer>();

            list = _context.Customers.Where(c=>c.isDeleted==false).OrderBy(o=>o.FirstName).ToList();

            return list;
        }

        
        public string UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);

            _context.SaveChanges();

            return ("Updated");
        }
    }
}
