using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Slider : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
		public string Picture { get; set; }
		public byte[] PictureFile { get; set; }
		public byte Order { get; set; }
        public bool IsActive { get; set; }

    }
}
