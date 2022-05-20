using Nest;
using System;

namespace WebApi.Models
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double IMDB { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string Seanse { get; set; }
        public string Saloon { get; set; }
        public double Price { get; set; }       
    }
}
