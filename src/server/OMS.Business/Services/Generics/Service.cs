using OMS.DataAccess.Entities;
using OMS.DataAccess.Repositories.Generics;

namespace OMS.Business.Services.Generics;

public class Service<T> : IService<T> where T : class
{
    private readonly IRepository<T> _repository;

    public Service(IRepository<T> repository)
    {
        _repository = repository;
    }
    public virtual async Task<T> Create(T item)
    {
        _repository.Add(item);
        _repository.Save();

        return await Task.FromResult(item);
    }

    public async virtual Task<T> CreateFromDto(object dto)
    {
        return await Task.FromResult((T)dto);
    }

    public async Task<bool> Delete(Guid id)
    {
        _repository.Delete(id);
        _repository.Save();

        return await Task.FromResult(true);
    }

    public async virtual Task<IEnumerable<object>> GetAllAsDtoAsyc()
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>> GetAllAsyc()
    {
        return await Task.FromResult(_repository.GetAll().ToList());
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await Task.FromResult(_repository.Get(id));
    }

    public async Task<bool> Update(T item)
    {
        _repository.Update(item);
        _repository.Save();

        return await Task.FromResult(true);
    }
}
