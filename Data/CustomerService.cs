using CSApiRestPractice02.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace CSApiRestPractice02.Data {

    public class CustomerService: DbContext {

        public CustomerService(DbContextOptions<CustomerService> options) : base(options) {


        }

        public DbSet<Customer> CustomerDao { get; set; }

        public async Task<List<Customer>> GetCustomers() {

            List<Customer> customers = CustomerDao.Select(customer => customer).ToList();

            return customers;

        }

        public async Task<Customer> GetCustomer(int id) {

            return await CustomerDao.FirstOrDefaultAsync(customer => customer.CustomerId == id);

        }

        public async Task<Customer> SaveCustomer(Customer customer) {

            Customer customerToSave = new Customer(
                
                customer.Address,
                customer.FirstName,
                customer.LastName,
                customer.Email,
                customer.Password

                );

            EntityEntry<Customer> response = await CustomerDao.AddAsync(customerToSave);

            await SaveChangesAsync();

            return await GetCustomer(response.Entity.CustomerId);

        }

        public async Task<Customer> UpdateCustomer(int id, Customer customer) {

            Customer customerToUpdate = new Customer(
                
                id,
                customer.Address,
                customer.FirstName,
                customer.LastName,
                customer.Email,
                customer.Password
                
                );

            CustomerDao.Update(customerToUpdate);

            SaveChanges();

            return customerToUpdate;

        }

        public async Task<Boolean> DeleteCustomer(int id) {

            Customer customerToDelete = await GetCustomer(id);

            CustomerDao.Remove(customerToDelete);

            SaveChanges();

            return true;

        }

    }

}
