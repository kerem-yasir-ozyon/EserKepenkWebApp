using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	public class Guest : BaseEntity
	{
		public string Name { get; set; }
		public string Surname { get; set; }
		[DataType(DataType.PhoneNumber)]
		public string? Phone {  get; set; }
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		public string Description { get; set; }

	}
}
