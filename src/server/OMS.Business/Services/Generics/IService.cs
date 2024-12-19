namespace OMS.Business.Services.Generics;

public interface IService<T>
{
    Task<IEnumerable<T>> GetAllAsyc();
    Task<IEnumerable<object>> GetAllAsDtoAsyc();
    Task<T> GetByIdAsync(Guid id);
    Task<T> Create(T item);
    Task<T> CreateFromDto(object dto);
    Task<bool> Update(T item);
    Task<bool> Delete(Guid id);
}
