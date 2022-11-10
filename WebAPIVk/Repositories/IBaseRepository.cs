namespace WebAPIVk.Repositories
{
    public interface IBaseRepository<T> 
    {
        Task<T> Insert(T entity);
        Task Save();
    }
}
