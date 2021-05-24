using Glossary.Persistence.Context;
using Glossary.Persistence.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Glossary.Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly GlossaryDBContext _context;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(GlossaryDBContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public virtual async Task<IEnumerable<T>> ListBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> query = _dbSet;

                if (predicate != null)
                {
                    query = query.Where(predicate).AsQueryable();
                }

                if (includeProperties != null)
                {
                    query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
                }
                return await query.ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual async Task<IEnumerable<T>> ListBy(Expression<Func<T, bool>> predicate)
        {
            try
            {
                IQueryable<T> query = _dbSet;
                if (predicate != null)
                {
                    query = query.Where(predicate).AsQueryable();
                }
                return await query.ToListAsync();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public virtual async Task<IEnumerable<T>> ListBy()
        {
            try
            {
                return await _dbSet.ToListAsync();

            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public virtual async Task<T> GetBy(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            try
            {
                IQueryable<T> query = _dbSet;

                if (predicate != null)
                {
                    query = query.Where(predicate).AsQueryable();
                }

                if (includeProperties != null)
                {
                    query = includeProperties.Aggregate(query, (current, include) => current.Include(include));
                }
                return await query.FirstOrDefaultAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _dbSet.Where(predicate).AnyAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public virtual async Task<T> GetById(object id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                return entity;
            }
            catch (Exception e)
            {

                throw e;
            }
        }


        public async Task<T> Insert(T entity)
        {
            try
            {
                entity.CreatedAt = DateTime.Now;
                entity.Active = true;
                _context.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<T> Update(object id, T entity)
        {
            try
            {
                var editedEntity = await GetById(id);
                editedEntity.UpdatedAt = DateTime.Now;
                _context.Entry(editedEntity).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return editedEntity;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task<T> Update(T entity)
        {
            try
            {
                entity.UpdatedAt = DateTime.Now;
                _context.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {

                throw e;
            }
        }
        public async Task UpdateRange(IEnumerable<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    entity.UpdatedAt = DateTime.Now;
                    _context.Attach(entity);
                    _context.Entry(entity).State = EntityState.Modified;
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                foreach (var entity in entities)
                {
                    await Remove(entity);
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task Remove(T entity)
        {
            try
            {
                entity.Active = false;
                entity.RemovedAt = DateTime.Now;
                await Update(entity);
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public async Task Remove(object id)
        {
            try
            {
                var entity = await GetById(id);
                await Remove(entity);
            }
            catch (Exception e)
            {

                throw e;
            }
        }




    }
}
