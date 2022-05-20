using System.ComponentModel.DataAnnotations;
using WebApi.Core.Model;

namespace WebApi.Models
{
    public class Ticket:IModel
    {
        public int Id { get; set; } 
        public int MovieId { get; set; } 
        public int SaloonId { get; set; } 
        public int SeatId { get; set; }
        public int SeanseId { get; set; }
        public int PriceId { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "EMailDetail"), StringLength(50, MinimumLength = 6, ErrorMessage = "{0} , {2} - {1} Karakter Olmalı"), DataType(DataType.EmailAddress, ErrorMessage = "{0} Uygun formatta değil!")]
        public string EMailDetail { get; set; }
        public Ticket()
        {
        }
        public Ticket(int id, int saloonId, int seanseId, int movieId,int seatId, int priceId,string emailDetail)
        {
            Id = id;
            SeanseId = seanseId;
            SaloonId = saloonId;
            SeatId = seatId;
            MovieId= movieId;
            PriceId= priceId;
            EMailDetail = emailDetail;
        }
    }
}
