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

        public string DeleteCustomer(Guid id)
        {
            var customer = _context.Customers.Find(id);

            if (customer != null)
            {
                

                customer.CustomerID = customer.CustomerID;
                customer.DateEdited = DateTime.Now.ToString("dd/MM/yyyy");
                customer.isDeleted = true;

                _context.Customers.Update(customer);
                _context.SaveChanges();

                return ("Deleted");

            }
            else
            {
                return ("failed");
            }


        }

        public Customer GetCustomerById(Guid id)
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
