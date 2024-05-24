using System.ComponentModel.DataAnnotations;

namespace EserKepenkFront.Models
{
    public class SliderViewModel
    {
        public int Id { get; set; }
        public int RowNum { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public byte[] PictureFile { get; set; }
        [Required(ErrorMessage = "Lütfen ürün fotoğrafı seçiniz.")]
        public IFormFile PictureFormFile { get; set; }
        public byte Order { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created { get; set; }
    }
}
