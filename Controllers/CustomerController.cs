using Microsoft.AspNetCore.Mvc;
using videostore_be.Models;
using videostore_be.service;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly CustomerService _customerService;
    private readonly RentalService _rentalService;

    public CustomersController(CustomerService customerServices, RentalService rentalService)
    {
        _customerService = customerServices;
        _rentalService = rentalService;
    }

    // GET: api/customer
    [HttpGet]
    public async Task<IActionResult> GetCustomers()
    {
        var customer = await _customerService.getAllCustomer();
        return Ok(customer);
    }

    // GET: api/customer/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCustomerById(int id)
    {
        var Customer = await _customerService.getCustomerById(id);

        if (Customer == null)
        {
            return NotFound();
        }

        return Ok(Customer);
    }

    // POST: api/customer
    [HttpPost]
    public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _customerService.addCustomer(customer);
        return CreatedAtAction(nameof(GetCustomerById), new { id = customer.CustomerId }, customer);
    }

    // PUT: api/customer/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCustomer(int id, [FromBody] Customer Customer)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        Customer updatedcustomer;

        try
        {
            updatedcustomer = await _customerService.updateCustomerAsync(id, Customer);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unhandled exception: {ex}");
            return StatusCode(500, "An unexpected error occurred.");
        }

        return Ok(updatedcustomer);
    }

    // GET: api/customer/search_Customer?searchTerm=Action
    [HttpGet("search_Customer")]
    public async Task<IActionResult> GetCustomerByTitle(string searchTerm)
    {
        try
        {
            var searchResults = await _customerService.getCustomerByTitle(searchTerm);
            return Ok(searchResults);
        }
        catch (ArgumentException)
        {
            return NotFound();
        }

        catch (Exception ex)
        {
            Console.WriteLine($"Unhandled exception: {ex}");
            return StatusCode(500, "An unexpected error occurred.");
        }
    }
}
