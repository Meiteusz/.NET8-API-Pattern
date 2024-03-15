using AutoglassChallenge.Domain.Entities;
using AutoglassChallenge.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AutoglassChallenge.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        private readonly AutoglassChallengeContext _context;

        public BaseRepository(AutoglassChallengeContext context)
        {
            _context = context;
        }

        public long Create(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
            return obj.Id;
        }

        public T? GetById(long id)
            => _context.Set<T>()
                       .AsNoTracking()
                       .Where(x => x.Id == id)
                       .FirstOrDefault();

        public IEnumerable<T?> GetFromPagination(int pageNumber, int pageSize)
            => _context.Set<T>()
                       .AsNoTracking()            
                       .Skip((pageNumber - 1) * pageSize)
                       .Take(pageSize)
                       .ToList();

        public void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var obj = _context.Set<T>().Find(id);

            if (obj == null)
                return;

            _context.Remove(obj);
            _context.SaveChanges();
        }
    }
}
