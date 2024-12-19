using Microsoft.EntityFrameworkCore;
using OMS.DataAccess.Entities;
using OMS.DataAccess.Repositories.Generics;

namespace OMS.DataAccess.Repositories;

public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(OMSDbContext context) : base(context)
    {
    }
    public override IEnumerable<OrderItem> GetAll()
    {
        return base._dbSet.Include(p => p.Item).Include(p => p.Order).AsEnumerable();
    }
}

public interface IOrderItemRepository : IRepository<OrderItem>
{
}
