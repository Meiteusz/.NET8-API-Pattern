using AutoglassChallenge.Domain.Entities;

namespace AutoglassChallenge.Domain.Repositories
{
    public interface IBaseRepository<T> where T : EntityBase
    {
        long Create(T obj);

        T? GetById(long id);

        IEnumerable<T?> GetFromPagination(int pageNumber, int pageSize);

        void Update(T obj);

        void Delete(long id);
    }
}
