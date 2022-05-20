using System.Collections.Generic;
using WebApi.Core.DataAccess.Abstract;
using WebApi.Models;

namespace WebApi.DataAccess.Abstract
{
    public interface ITicketRepository:IBaseRepository<Ticket>
    {
        List<Ticket> GetAllByTimeId(int timeId);
        List<Ticket> GetAllBySaloonId(int saloonId);
        List<Ticket> GetAllBySeatId(int seatId);
        List<Ticket> GetAllByMovieId(int movieId);
        public List<TicketDto> GetAllWithTimeSaloonSeatMovieandPrice();
    }
}
