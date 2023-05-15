using DataAccess.EntityFramework.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public class Repository<T> : IRepository<T>
        where T:class,new()

    {
        private DbSet<T> _objectSet;
        private readonly DataContext _dbContext=new DataContext();
        public Repository()
        {
            
            _objectSet=_dbContext.Set<T>();
        }
        public int Delete(T obj)
        {
            _objectSet.Remove(obj);

            return Save();
        }

        public List<T> List()
        {
            return _objectSet.ToList();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(T obj)
        {
            _objectSet.Add(obj);
            return Save();
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public int Update(T obj)
        {
            _objectSet.AddOrUpdate(obj);
          return Save();
        }
    }
}
