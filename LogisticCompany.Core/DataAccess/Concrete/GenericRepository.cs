using LogisticCompany.Core.DataAccess.Abstract;
using LogisticCompany.Core.Entities.Concrete;
using LogisticCompany.Core.Helpers;
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
        private readonly IHttpAccessorHelper _httpAccessorHelper;

        public GenericRepository(DbContext context, IHttpAccessorHelper httpAccessorHelper)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
            _httpAccessorHelper = httpAccessorHelper;
        }

        public async Task<IQueryable<TEntity>> GetAllAsync()
        {
            return await Task.FromResult(DbSet.AsQueryable().Where(x => !x.IsDeleted));
        }
        public IQueryable<TEntity> GetAll()
        {
            return DbSet.AsQueryable().Where(x => !x.IsDeleted);
        }
        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await DbSet.Where(x => !x.IsDeleted).FirstOrDefaultAsync(filter);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }

        public async Task<IDataResult<TEntity>> AddAsync(TEntity entity)
        {
            entity.CreatedDate = DateTime.Now.ToUniversalTime();
            entity.CreatedBy = _httpAccessorHelper.GetUserId() == null ? 0 : _httpAccessorHelper.GetUserId().Value;
            var addedEntity = await Context.AddAsync(entity); // await ile asenkron metot çağrısını bekleyin
            addedEntity.State = EntityState.Added;
            Context.SaveChanges();
            return new SuccessDataResult<TEntity>(addedEntity.Entity);
        }

        public IDataResult<TEntity> Update(TEntity entity)
        {
            entity.ModifyDate = DateTime.Now.ToUniversalTime();
            entity.ModifyBy = _httpAccessorHelper.GetUserId().Value;
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
            entities.ForEach(x =>
            {
                x.CreatedDate = DateTime.Now.ToUniversalTime();
            });
            DbSet.AddRange(entities);
            Context.SaveChanges();
            return new SuccessDataResult<List<TEntity>>(entities);
        }
        public IDataResult<List<TEntity>> UpdateRange(List<TEntity> entities)
        {
            entities.ForEach(x =>
            {
                x.ModifyDate = DateTime.Now.ToUniversalTime();
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
