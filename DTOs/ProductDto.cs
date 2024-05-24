using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class ProductDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public byte[] PictureFile { get; set; }
        public CategoryDto Category { get; set; }
        public int CategoryId { get; set; }
    }
}
