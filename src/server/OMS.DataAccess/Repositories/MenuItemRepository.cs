using OMS.DataAccess.Entities;
using OMS.DataAccess.Repositories.Generics;

namespace OMS.DataAccess.Repositories;

public class MenuItemRepository : Repository<MenuItem>, IMenuItemRepository
{
    public MenuItemRepository(OMSDbContext context) : base(context)
    {
    }
}
public interface IMenuItemRepository : IRepository<MenuItem>
{
}
