using System.Collections.Generic;
using System.Linq;
using WebApi.Core.DataAccess.Concrete;
using WebApi.DataAccess.Abstract;
using WebApi.Models;

namespace WebApi.DataAccess.Concrete
{
    public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
    {
        public List<Ticket> GetAllByMovieId(int movieId)
        {
            using (var context = new CinemaTicketDbContext())
            {
                return context.Set<Ticket>().Where(t => t.MovieId == movieId).ToList();
            }
        }

        public List<Ticket> GetAllBySaloonId(int saloonId)
        {
            using (var context = new CinemaTicketDbContext())
            {
                return context.Set<Ticket>().Where(t => t.SaloonId == saloonId).ToList();
            }
        }

        public List<Ticket> GetAllBySeatId(int seatId)
        {
            using (var context = new CinemaTicketDbContext())
            {
                return context.Set<Ticket>().Where(t => t.SeatId == seatId).ToList();
            }
        }

        public List<Ticket> GetAllByTimeId(int seanseId)
        {
            using (var context = new CinemaTicketDbContext())
            {
                return context.Set<Ticket>().Where(t => t.SeanseId == seanseId).ToList();
            }
        }

        public List<TicketDto> GetAllWithTimeSaloonSeatMovieandPrice()
        {
            using (var context = new CinemaTicketDbContext())
            {
                var result = from tic in context.Tickets
                             join m in context.Movies on tic.MovieId equals m.Id
                             join sa in context.Saloons on tic.SaloonId equals sa.Id
                             join se in context.Seats on tic.SeatId equals se.Id
                             join tm in context.Seanses on tic.SeanseId equals tm.Id
                             join pr in context.Prices on tic.PriceId equals pr.Id
                             select new TicketDto()
                             {
                                 Id = tic.Id,
                                 Movie = m.Name,
                                 Saloon = sa.Name,
                                 Seat = se.Number,
                                 Seanse = tm.MovieTime,
                                 Price= pr.MoviePrice
                                 
                             };
                return result.ToList();
            }
        }
    }
}
