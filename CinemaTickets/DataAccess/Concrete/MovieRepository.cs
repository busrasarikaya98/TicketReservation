using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using WebApi.Core.DataAccess.Concrete;
using WebApi.DataAccess.Abstract;
using WebApi.Models;

namespace WebApi.DataAccess.Concrete
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public List<Movie> GetAllByTimeId(int seanseId)
        {
            using (var context = new CinemaTicketDbContext())
            {
                return context.Set<Movie>().Where(t => t.SeanseId == seanseId).ToList();
            }
        }
        public List<Movie> GetAllBySaloonId(int saloonId)
        {
            using (var context = new CinemaTicketDbContext())
            {
                return context.Set<Movie>().Where(t => t.SaloonId == saloonId).ToList();
            }
        }
        public List<MovieDto> GetAllWithTimeSaloonandPrice()
        {
            using (var context = new CinemaTicketDbContext())
            {
                var result = from m in context.Movies
                             join t in context.Seanses on m.SeanseId equals t.Id
                             join s in context.Saloons on m.SaloonId equals s.Id
                             join p in context.Prices on m.PriceId equals p.Id
                             select new MovieDto()
                             {
                                 Id = m.Id,
                                 Name = m.Name,
                                 Description = m.Description,
                                 IMDB = m.IMDB,
                                 ImageUrl= m.ImageUrl,
                                 Seanse = t.MovieTime,                                 
                                 Saloon=s.Name,
                                 Price=p.MoviePrice
                             };
                return result.ToList();
            }
        }

    }
}
