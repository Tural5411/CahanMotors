using CahanMotors.Shared.Entities.Abstract;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CahanMotors.Entities.DTOs
{
    public class RegisterAddDto:DtoGetBase
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Number { get; set; }
        public string Message { get; set; }
        [DisplayName("Aktivdir ?")]
        [Required(ErrorMessage = "{0}  boş ola bilməz!")]
        public bool IsActive { get; set; }
    }
}
