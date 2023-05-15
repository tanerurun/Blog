using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRepository<T>
    {
        List<T> List();
        int  Save();
        int Delete(T obj);
        int Insert(T obj);
        int Update(T obj);
        T GetById(int id);
    }
}
