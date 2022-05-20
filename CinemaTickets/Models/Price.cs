using WebApi.Core.Model;

namespace WebApi.Models
{
    public class Price:IModel
    {
        public int Id { get; set; }
        public int MoviePrice { get; set; }
        public Price()
        {
        }
        public Price(int id, int moviePrice)
        {
            Id = id;
            MoviePrice = moviePrice;
        }
    }
}
