using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core.DataAccess.Abstract;
using WebApi.Models;

namespace WebApi.DataAccess.Abstract
{
    interface ITimeRepository:IBaseRepository<Time>
    {
    }
}
