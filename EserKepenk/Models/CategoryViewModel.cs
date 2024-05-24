using System.ComponentModel;

namespace EserKepenk.Models
{
    public class CategoryViewModel : BaseViewModel
    {
        [DisplayName("Kategori Adı")]
        public string Name { get; set; }
        public IEnumerable<ProductViewModel>? Products { get; set; }

        public int? RowNum { get; set; }
    }
}
