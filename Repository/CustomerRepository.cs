using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using videostore_be.Models;
using videostore_be.Repository.Interface;

public class CustomerRepository : IRepository<Customer>
{
    private readonly VideoStoreContext _context;

    public CustomerRepository(VideoStoreContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        return await _context.Customer.ToListAsync();
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        return await _context.Customer.FindAsync(id);
    }

    public async Task<IEnumerable<Customer>> FindAsync(Expression<Func<Customer, bool>> predicate)
    {
        return await _context.Customer.Where(predicate).ToListAsync();
    }

    public async Task AddAsync(Customer customer)
    {
        _context.Customer.Add(customer);
        await _context.SaveChangesAsync();
    }

    public async Task<Customer> UpdateAsync(int id, Customer customer)
    {
        var existingCustomer = await _context.Customer.FindAsync(id);

        if (existingCustomer == null)
        {
            throw new ArgumentException("Customer not found.");
        }

        existingCustomer.Name = customer.Name;
        existingCustomer.Address = customer.Address;
        existingCustomer.PhoneNumber = customer.PhoneNumber;

        await _context.SaveChangesAsync();

        return existingCustomer;
    }

    public async Task<IEnumerable<Customer>> GetByNameAsync(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            return Enumerable.Empty<Customer>();
        }

        return await _context.Customer
            .Where(c => EF.Functions.Like(c.Name, $"%{searchTerm}%"))
            .ToListAsync();
    }
}
