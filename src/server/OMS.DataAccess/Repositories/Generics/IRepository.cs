namespace OMS.DataAccess.Repositories.Generics;
public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    T Get(object id);
    void Add(T entity);
    void Update(T entity);
    void Delete(object id);
    int Count();
    void Save();
}