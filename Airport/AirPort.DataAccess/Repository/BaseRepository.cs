﻿using Airport.DataAccess;
using Airport.Domain.Repositiories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirPort.DataAccess
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> 
        where TEntity : class, IEntity
    {
        protected readonly AirportDbContext _dbContext;

        public BaseRepository(AirportDbContext dbContext)
        {
            _dbContext = dbContext;

            AddSeeds();
        }

        protected abstract void AddSeeds();



        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public async Task Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(Guid Id)
        {
            //var entity = await GetById(Id);
            var entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == Id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _dbContext.Set<TEntity>()
                        .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
