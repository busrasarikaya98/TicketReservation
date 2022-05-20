using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core.Model;

namespace WebApi.Models
{
    public class Saloon:IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public Saloon() { }
        public Saloon(int id,string name)
        {
            Id = id;
            Name = name;
        }
    }
}
