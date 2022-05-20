using Nest;
using System;

namespace WebApi.Models
{
    public class TicketDto
    {
        public int Id { get; set; }
        public string Movie { get; set; }
        public string Saloon { get; set; }
        public string Seanse { get; set; }
        public string Seat { get; set; }
        public string EMailDetail { get; set; }
        public double Price { get; set; }
    }
}
