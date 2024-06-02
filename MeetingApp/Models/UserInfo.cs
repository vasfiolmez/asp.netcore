using System.ComponentModel.DataAnnotations;

namespace MeetingApp.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen Ad Soyad Alanını Boş Geçmeyiniz ")]

        public string? Name { get; set; }
        [Required(ErrorMessage = "Telefon alanı zorunludur")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Email alanı zorunlu")]
        [EmailAddress(ErrorMessage = "Hatalı Email girişi yaptınız.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Katılım durumunuzu belirtiniz.")]
        public bool? WillAttend { get; set; }
    }

}