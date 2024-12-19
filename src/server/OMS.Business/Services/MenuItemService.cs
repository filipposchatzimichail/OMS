using OMS.Business.Services.Generics;
using OMS.DataAccess.Entities;
using OMS.DataAccess.Repositories;

namespace OMS.Business.Services;

public class MenuItemService : Service<MenuItem>, IMenuItemService
{
    public MenuItemService(IMenuItemRepository repository) : base(repository)
    {
    }

    public override Task<MenuItem> Create(MenuItem item)
    {
        item.Id = Guid.NewGuid();
        return base.Create(item);
    }
}

public interface IMenuItemService : IService<MenuItem>
{
}