namespace Infrastructure.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id); // tarefa assincrona, nao bloqueia threads
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity); 
        Task DeleteAsync(T entity);
    }
}