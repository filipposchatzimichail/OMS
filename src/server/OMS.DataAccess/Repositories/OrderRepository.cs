using Microsoft.EntityFrameworkCore;
using OMS.DataAccess.Entities;
using OMS.DataAccess.Repositories.Generics;

namespace OMS.DataAccess.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(OMSDbContext context) : base(context)
    {
    }
    public override IEnumerable<Order> GetAll()
    {
        return base._dbSet.Include(p => p.Customer).AsEnumerable();
    }
}

public interface IOrderRepository : IRepository<Order>
{
}
