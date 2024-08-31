namespace ECommerceCompanyApplication.Repositories.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task AddData(T obj);

        Task DeleteData(object ID);

        Task EditData(object ID, T obj);

        Task<T> GetValue(object ID);

        Task<IEnumerable<T>> GetAllValues();
    }
}
