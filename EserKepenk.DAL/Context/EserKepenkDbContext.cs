using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Reflection.Metadata;

namespace EserKepenk.DAL.Context
{
	public class EserKepenkDbContext : DbContext
	{
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<AccountUser> AccountUsers { get; set; }
		public DbSet<Guest> Guests { get; set; }
		public DbSet<Slider> Sliders { get; set; }
		public EserKepenkDbContext(DbContextOptions<EserKepenkDbContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.HasDefaultSchema("eserDbUser");

			modelBuilder.Entity<AccountUser>()
						.HasData(new AccountUser
						{
							Id = 1,
							Name = "Admin",
							SurName = "Admin",
							Email = "admin@eserkepenk.com",
							Created = DateTime.Now,
							Password = Sifreleme.Md5Hash("@Dm1n*12345")
						});

					//	modelbuilder
					//.entity<category>()
					//.hasmany(e => e.products)
					//.withone(e => e.category)
					//.ondelete(deletebehavior.cascade);

			

		}


	}

	internal static class Sifreleme
	{
		public static string Md5Hash(string text)
		{
			MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

			// asd123 => 

			byte[] dizi = Encoding.UTF8.GetBytes(text);

			dizi = md5.ComputeHash(dizi);

			//string passHash = "";
			StringBuilder sb = new StringBuilder();

			foreach (byte b in dizi)
			{
				//passHash += b.ToString("X2").ToLower();

				sb.Append(b.ToString("X2").ToLower());
			}

			//return passHash;

			return sb.ToString();
		}
	}
}
