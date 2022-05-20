using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core.DataAccess.Abstract;
using WebApi.Models;

namespace WebApi.DataAccess.Abstract
{
    public interface IUserrRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        bool Add(T model);
        bool Update(T model);
        bool DeleteById(int id);
    }
}
