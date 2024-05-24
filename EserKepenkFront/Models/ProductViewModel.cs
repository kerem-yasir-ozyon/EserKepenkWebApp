using System.ComponentModel.DataAnnotations;

namespace EserKepenkFront.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Lütfen ürün ADINI giriniz.")]
        public string Name { get; set; }
        public string Description { get; set; }

        public string Picture { get; set; }
        public byte[] PictureFile { get; set; }
        [Required(ErrorMessage = "Lütfen ürün fotoğrafı seçiniz.")]
        public IFormFile PictureFormFile { get; set; }
        public CategoryViewModel Category { get; set; }
        [Range(1, byte.MaxValue, ErrorMessage = "Lütfen geçerli bir kategori seçiniz.")]
        public int CategoryId { get; set; }
        public int? RowNum { get; set; }
    }
}
