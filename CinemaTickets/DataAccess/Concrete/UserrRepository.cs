
using System.Collections.Generic;
using WebApi.Core.Model;
using WebApi.DataAccess.Abstract;

namespace WebApi.DataAccess.Concrete
{
    public class UserrRepository<T> : IUserrRepository<T> where T : class, IModel, new()
    {
        public UserrRepository()
        {
        }

        public bool Add(T model)
        {
            throw new System.NotImplementedException();
        }

        public bool DeleteById(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Update(T model)
        {
            throw new System.NotImplementedException();
        }
    }
}
