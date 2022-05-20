using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core.Model;

namespace WebApi.Models
{
    public class Seanse:IModel
    {
        public int Id { get; set; }
        public string MovieTime { get; set; }
        public Seanse()
        {
        }
        public Seanse(int id,string movieTime)
        {
            Id = id;
            MovieTime = movieTime;
        }
    }
}
