using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EserKepenk.Models
{
	public class SliderViewModel : BaseViewModel
    {
		
		public int RowNum { get; set; }
        [Required(ErrorMessage = "Lütfen slayt açıklaması yazınız.")]
        [DisplayName("Açıklama")]
		public string Description { get; set; }
        [Required(ErrorMessage = "Lütfen slayt başlığı yazınız.")]
        [DisplayName("Başlık")]
        public string Title { get; set; }
		public string Picture { get; set; }
        public byte[] PictureFile { get; set; }
        [DisplayName("Slay Fotoğrafı")]
		[Required(ErrorMessage = "Lütfen slayt fotoğrafı seçiniz.")]
		public IFormFile PictureFormFile { get; set; }
		[Required(ErrorMessage = "Lütfen slayt sırası seçiniz.")]
		[DisplayName("Slayt Sırası")]
		public byte Order { get; set; }
        [DisplayName("Aktif mi ?")]
        public bool IsActive { get; set; }
		public DateTime Created {  get; set; }

	}
}
