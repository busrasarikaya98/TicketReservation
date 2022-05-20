using WebApi.Core.DataAccess.Concrete;
using WebApi.DataAccess.Abstract;
using WebApi.Models;

namespace WebApi.DataAccess.Concrete
{
    public class PriceRepository:BaseRepository<Price>,IPriceRepository
    {
    }
}
