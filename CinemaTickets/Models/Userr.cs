using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Core.Model;

namespace WebApi.Models
{
    public class Userr
    {
        [Key]
        public int UserrId { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "E-Posta"), StringLength(50, MinimumLength = 6, ErrorMessage = "{0} , {2} - {1} Karakter Olmalı"), DataType(DataType.EmailAddress, ErrorMessage = "{0} Uygun formatta değil!")]
        public string Emaill { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Şifre"), StringLength(20, MinimumLength = 6, ErrorMessage = "{0} , {2} - {1} Karakter Olmalı"), DataType(DataType.Password)]
        public string Passwordd { get; set; }

        [NotMapped, Display(Name = "Şifre Tekrar"), DataType(DataType.Password), Compare("Passwordd", ErrorMessage = "Şifreler Eşleşmiyor")]
        public string PasswordRepeatt { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Adı ve varsa İkinci Adı"), StringLength(40, MinimumLength = 2, ErrorMessage = "{0} , {2} - {1} Karakter Olmalı")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Soyadı"), StringLength(20, MinimumLength = 2, ErrorMessage = "{0} , {2} - {1} Karakter Olmalı")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), Display(Name = "Role")]
        public byte RoleeID { get; set; }



        public Rolee Rolee { get; set; } // navigasyon için gerekli

    }
}
