using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core.DataAccess.Concrete;
using WebApi.DataAccess.Abstract;
using WebApi.Models;

namespace WebApi.DataAccess.Concrete
{
    public class TimeRepository : BaseRepository<Time>, ITimeRepository
    {
    }
}
