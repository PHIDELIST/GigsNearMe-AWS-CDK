using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using GigsNearMe.Contracts;
using GigsNearMe.Data;

namespace GigsNearMe.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {
        protected GigsNearMeDbContext RepositoryContext { get; set; }

        public RepositoryBase(GigsNearMeDbContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        /*
        public IQueryable<Artist> Artists => context.Artists;

        public IQueryable<Artist> TouringArtists
        {
            get 
            {
                return (from a in context.Artists
                            .Include(a => a.Tours)
                        where a.Tours.Count > 0
                        select a)
                        .OrderBy(a => a.Name);
            }
        }

        public IQueryable<Tour> Tours => from t in context.Tours.Include(t => t.Artist) select t;

        public Tour TourDetails(int tourID)
        {
            return context.Tours
                        .Include(t => t.Artist)
                        .Include(t => t.Gigs)
                            .ThenInclude(g => g.Venue)
                        .FirstOrDefault(m => m.TourID == tourID);
        }

        public IQueryable<Venue> Venues => from v in context.Venues select v;
        */
    }
}
