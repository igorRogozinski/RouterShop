namespace RouterShop.Repositories.Interfaces
{
    public interface IGenericRepo<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T?> GetById(int id);

    }
}
