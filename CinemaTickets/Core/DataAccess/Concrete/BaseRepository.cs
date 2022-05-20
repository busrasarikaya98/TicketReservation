using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core.DataAccess.Abstract;
using WebApi.Core.Model;
using WebApi.Models;

namespace WebApi.Core.DataAccess.Concrete
{
    public class BaseRepository<T>:IBaseRepository<T> where T : class,IModel,new()
    {
        public bool Add(T model)
        {
            using(var context=new CinemaTicketDbContext())
            {
                var addedModel = context.Entry(model); //yeni model var bu modeli giriş yap
                addedModel.State = EntityState.Added;
                context.SaveChanges();
                return true;
            }
        }
        public bool DeleteById(int id)
        {
            var model = this.GetById(id);
            using (var context=new CinemaTicketDbContext())
            {
                var deletedModel = context.Entry(model);
                deletedModel.State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
        }
        public virtual List<T> GetAll()
        {
            using (var context = new CinemaTicketDbContext())
            {
                return context.Set<T>().ToList();
            }
        }
        public T GetById(int id)
        {
           using (var context=new CinemaTicketDbContext())
           {
                return context.Set<T>().SingleOrDefault(u => u.Id == id); //t genericindeki hangi modelse o modelin id si
           }
        }
        public bool Update(T model)
        {
           using(var context=new CinemaTicketDbContext())
            {
                var updatedModel = context.Entry(model);
                updatedModel.State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }
    }
}

