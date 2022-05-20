using System;
using WebApi.Core.Model;

namespace WebApi.Models
{
    public class Seat:IModel
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public bool Statue { get; set; } = false;
        public Seat()
        {
        }
        public Seat(int id, string number,bool statue)
        {
            Id = id;
            Number = number;
            Statue = statue;
        }
    }
}
