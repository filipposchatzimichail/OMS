using OMS.DataAccess.Entities;
using OMS.DataAccess.Repositories.Generics;

namespace OMS.DataAccess.Repositories;

public class CustomerRepository : Repository<Customer>, ICustomerRepository
{
    public CustomerRepository(OMSDbContext context) : base(context)
    {
    }
}
public interface ICustomerRepository : IRepository<Customer>
{
}
