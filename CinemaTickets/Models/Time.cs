using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core.Model;

namespace WebApi.Models
{
    public class Time:IModel
    {
        public int Id { get; set; }
        public DateTime MovieTime { get; set; }
        public Time()
        {
        }
        public Time(int id,DateTime movieTime)
        {
            Id = id;
            MovieTime = movieTime;
        }
    }
}
