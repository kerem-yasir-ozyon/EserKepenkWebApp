using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Picture { get; set; }
        public byte[] PictureFile { get; set; }

        public Category Category { get; set; }
        public int? CategoryId { get; set; }
    }
}
