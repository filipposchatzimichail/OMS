using OMS.Business.Services.Generics;
using OMS.DataAccess.Entities;
using OMS.DataAccess.Repositories;

namespace OMS.Business.Services;

public class OrderItemService : Service<OrderItem>, IOrderItemService
{
    public OrderItemService(IOrderItemRepository repository) : base(repository)
    {
    }
    public override Task<OrderItem> Create(OrderItem item)
    {
        item.Id = Guid.NewGuid();
        return base.Create(item);
    }
}

public interface IOrderItemService : IService<OrderItem>
{
}