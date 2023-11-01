namespace TaskBoard.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();

        Task<bool> Create(T entity);

        Task<bool> Delete(T entity);

        Task<bool> Update(T entity);
    }
}
