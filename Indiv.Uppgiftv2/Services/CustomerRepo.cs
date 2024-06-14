using Indiv.Uppgiftv2.Data;
using IndUppClassModels;
using Microsoft.EntityFrameworkCore;

namespace Indiv.Uppgiftv2.Services
{
    public class CustomerRepo : ICustomer
    {
        private AppDbContext _dbContext;
        public CustomerRepo(AppDbContext appDbContext) 
        {
            _dbContext = appDbContext;
        }
        public async Task<Customer> Add(Customer newCustomer)
        {
            var result = await _dbContext.Customers.AddAsync(newCustomer);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Customer> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers() //string pw
        {
            var result = await _dbContext.Customers.Include(c => c.Appointments).ToListAsync();
            return result;
            //lägg till pw-krav
        }

        public async Task<Customer> GetSingleCustomer(int id)
        {
            var result = await _dbContext.Customers.Include(c => c.Appointments).FirstOrDefaultAsync(c => c.CustomerID == id);
            return result;
        }

        public async Task<IEnumerable<Customer>> SearchForCustomer(string name)
            //Borde man inte ha två parametrar för för och efternamn här?
        {
            IQueryable<Customer> query = _dbContext.Customers;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(c => c.FirstName.Contains(name)
                || c.LastName.Contains(name));
                
            }
            return await query.ToListAsync();
        }

        public async Task<Customer> Update(Customer entity)
        {
            var customer = await _dbContext.Customers
                .Include(a => a.Appointments)
                .FirstOrDefaultAsync(c => c.CustomerID == entity.CustomerID);
            if (customer != null)
            {
                customer.FirstName = entity.FirstName;
                customer.LastName = entity.LastName;
                customer.PassWord = entity.PassWord;

                await _dbContext.SaveChangesAsync();
                return customer;
            }
            return null;
        }
    }
}
