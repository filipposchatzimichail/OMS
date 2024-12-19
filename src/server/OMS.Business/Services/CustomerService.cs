using OMS.Business.Services.Generics;
using OMS.DataAccess.Entities;
using OMS.DataAccess.Repositories;

namespace OMS.Business.Services;

public class CustomerService : Service<Customer>, ICustomerService
{
    public CustomerService(ICustomerRepository repository) : base(repository)
    {
    }

    public override Task<Customer> Create(Customer item)
    {
        item.Id = Guid.NewGuid();
        return base.Create(item);
    }
}

public interface ICustomerService : IService<Customer>
{
}