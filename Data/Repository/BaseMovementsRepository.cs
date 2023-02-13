using Data.Config;
using Domain.Entities;
using Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BaseMovementsRepository<TEntity> : IBaseMovementsRepository<TEntity> where TEntity : class
    {
        private readonly ContextBase contextBase;

        public BaseMovementsRepository(ContextBase contextBase)
        {
            this.contextBase = contextBase;
        }

        public Task<bool> ResetState(TEntity Object)
        {
            try
            {
                contextBase.Entry(Object).State = EntityState.Modified;
                contextBase.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> Contract(TEntity Object)
        {
            try
            {
                contextBase.Entry(Object).State = EntityState.Modified;
                contextBase.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Task<bool> Inclinate(TEntity Object)
        {
            try
            {
                contextBase.Entry(Object).State = EntityState.Modified;
                contextBase.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> Rotate(TEntity Object)
        {
            try
            {
                contextBase.Entry(Object).State = EntityState.Modified;
                contextBase.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
