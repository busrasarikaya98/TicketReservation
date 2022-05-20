using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Core.Model;

namespace WebApi.Models
{
    public class Movie:IModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double IMDB { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public int SeanseId { get; set; }
        public int SaloonId { get; set; }
        public int PriceId { get; set; }
        public virtual Seanse Seanse { get; set; }
        public virtual Price Price { get; set; }

        public Movie()
        {
        }
        public Movie(int id,int saloonId,int seanseId,string name,double imdb,string description,string imageUrl,int price)
        {
            Id = id;
            Name = name;
            IMDB = imdb;
            Description = description;
            ImageUrl = imageUrl;
            SeanseId = seanseId;
            SaloonId = saloonId;
            PriceId = price;
        }
    }
}
