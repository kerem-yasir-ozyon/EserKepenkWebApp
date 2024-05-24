using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EserKepenk.Models
{
    public class ProductViewModel : BaseViewModel
    {
        [DisplayName("Ürünün İsmi")]
        [Required(ErrorMessage = "Lütfen ürün ADINI giriniz.")]
        public string Name { get; set; }
        [DisplayName("Ürünün Açıklaması")]
        public string Description { get; set; }
        
        public string Picture { get; set; }
        [Required(ErrorMessage = "Lütfen ürün fotoğrafı seçiniz.")]
        [DisplayName("Ürünün Resmi")]
        public IFormFile PictureFormFile { get; set; }
        [DisplayName("Ürünün Kategorisi")]
        public CategoryViewModel Category { get; set; }
        [Range(1, byte.MaxValue, ErrorMessage = "Lütfen geçerli bir kategori seçiniz.")]
        public int CategoryId { get; set; }
        public int? RowNum { get; set; }
    }
}
