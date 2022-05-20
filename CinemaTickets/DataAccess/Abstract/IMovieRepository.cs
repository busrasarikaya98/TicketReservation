using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WebApi.Core.DataAccess.Abstract;
using WebApi.Models;

namespace WebApi.DataAccess.Abstract
{
    public interface IMovieRepository:IBaseRepository<Movie>
    {
        List<Movie> GetAllByTimeId (int timeId);
        List<Movie> GetAllBySaloonId (int saloonId);
        public List<MovieDto> GetAllWithTimeSaloonandPrice();
    }
}
