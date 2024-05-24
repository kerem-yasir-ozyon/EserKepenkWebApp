using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EserKepenk.Models
{
    public class SliderEditViewModel : BaseViewModel
    {
       
        public int RowNum { get; set; }

        [DisplayName("Açıklama")]
        public string Description { get; set; }

        [DisplayName("Başlık")]
        public string Title { get; set; }
        public string? Picture { get; set; }
        public byte[]? PictureFile { get; set; }
        [DisplayName("Slayt Fotoğrafı")]

        public IFormFile? PictureFormFile { get; set; }

        [DisplayName("Slayt Sırası")]
        public byte Order { get; set; }
        [DisplayName("Aktif mi ?")]
        public bool IsActive { get; set; }

    }
}
