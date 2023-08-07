using videostore_be.Models;
using videostore_be.Repository.Interface;

public class CustomerService
{
    private readonly IRepository<Customer> _customerRepository;

    public CustomerService(IRepository<Customer> customerRepository)
    {
        _customerRepository = customerRepository;
    }

    public async Task<IEnumerable<Customer>> getAllCustomer() => await _customerRepository.GetAllAsync();

    public async Task<IEnumerable<Customer>> getCustomerByTitle(string searchTerm) => await _customerRepository.GetByNameAsync(searchTerm);

    public async Task addCustomer(Customer customer) => await _customerRepository.AddAsync(customer);

    public async Task<Customer> updateCustomerAsync(int id, Customer customer) => await _customerRepository.UpdateAsync(id, customer);

    public Task<Customer> getCustomerById(int id) => _customerRepository.GetByIdAsync(id);
}
