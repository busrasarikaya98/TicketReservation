using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Rolee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public byte RoleeID { get; set; }
        [Required(ErrorMessage = "{0} Gerekli"), StringLength(20, MinimumLength = 6, ErrorMessage = "{0} , {2} - {1} Karakter Olmalı"), Display(Name = "Rol Adı")]
        public string RoleeName { get; set; }
    }
}