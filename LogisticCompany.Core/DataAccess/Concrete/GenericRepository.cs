using LogisticCompany.Core.DataAccess.Abstract;
using LogisticCompany.Core.Entities.Concrete;
using LogisticCompany.Core.Utilities.Results;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LogisticCompany.Core.DataAccess.Concrete
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
         where TEntity : BaseEntity, new()
    {
        protected readonly DbContext Context;
        protected readonly DbSet<TEntity> DbSet;

        public GenericRepository(DbContext context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbSet.AsQueryable().Where(x => !x.IsDeleted);
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.Where(x => !x.IsDeleted).FirstOrDefault(filter);
        }

        public TEntity GetById(int id)
        {
            return DbSet.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
        }

        public IDataResult<TEntity> Add(TEntity entity)
        {
            var addedEntity = Context.Entry(entity);
            addedEntity.State = EntityState.Added;
            Context.SaveChanges();
            return new SuccessDataResult<TEntity>(addedEntity.Entity);
        }


        public IDataResult<TEntity> Update(TEntity entity)
        {
            entity.ModifyDate = DateTime.Now;

            var updatedEntity = Context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            Context.SaveChanges();
            return new SuccessDataResult<TEntity>(updatedEntity.Entity);
        }

        public IDataResult<TEntity> Delete(TEntity entity)
        {
            entity.IsDeleted = true;
            var deletedEntity = Context.Entry(entity);
            Context.SaveChanges();
            return new SuccessDataResult<TEntity>(deletedEntity.Entity);
        }

        public IDataResult<List<TEntity>> AddRange(List<TEntity> entities)
        {
            DbSet.AddRange(entities);
            Context.SaveChanges();
            return new SuccessDataResult<List<TEntity>>(entities);
        }
        public IDataResult<List<TEntity>> UpdateRange(List<TEntity> entities)
        {
            entities.ForEach(x =>
            {
                x.ModifyDate = DateTime.Now;
            });

            DbSet.UpdateRange(entities);
            Context.SaveChanges();
            return new SuccessDataResult<List<TEntity>>(entities);
        }

        public IDataResult<List<TEntity>> DeleteRange(List<TEntity> entities)
        {
            entities.ForEach(x =>
            {
                x.IsDeleted = true;
            });

            DbSet.UpdateRange(entities);
            Context.SaveChanges();
            return new SuccessDataResult<List<TEntity>>(entities);
        }
        public bool Exist(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.Where(x => !x.IsDeleted).Any(filter);
        }
    }
}
