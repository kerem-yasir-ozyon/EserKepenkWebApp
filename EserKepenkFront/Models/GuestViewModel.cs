using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EserKepenkFront.Models
{
	public class GuestViewModel
	{
		public int Id { get; set; }
		[Required(ErrorMessage = "Zorunlu Alan")]
		[StringLength(20, MinimumLength = 3, ErrorMessage = "Adınız minimum 3 maksimum 20 karakterli olabilir!")]
		[DisplayName("İsiminiz")]
		public string Name { get; set; }
		[DisplayName("Soyisiminiz")]
		[Required(ErrorMessage = "Zorunlu Alan")]
		[StringLength(20, MinimumLength = 2, ErrorMessage = "Soyadınız minimum 2 maksimum 20 karakterli olabilir!")]
		public string Surname { get; set; }
		[DisplayName("Telefon Numaranız")]
		[DataType(DataType.PhoneNumber)]
		[Required(ErrorMessage = "Telefon numarası girilmesi zorunludur")]
		public string? Phone { get; set; }
		[DisplayName("Mail Adresiniz")]
		[EmailAddress]
		[Required(ErrorMessage = "E-posta girilmesi zorunludur")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Açıklama girilmesi zorunludur")]
		[DisplayName("Mesajınız")]
		public string Description { get; set; }
	}
}
