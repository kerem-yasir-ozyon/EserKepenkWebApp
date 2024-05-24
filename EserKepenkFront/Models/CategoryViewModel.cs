namespace EserKepenkFront.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ProductViewModel>? Products { get; set; }

        public int? RowNum { get; set; }
    }
}
