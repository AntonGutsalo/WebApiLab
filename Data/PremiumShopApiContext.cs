using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PremiumShopApi.Models;

namespace PremiumShopApi.Data
{
	public class PremiumShopApiContext : DbContext
	{
		public PremiumShopApiContext(DbContextOptions<PremiumShopApiContext> options)
			: base(options)
		{
			//Database.EnsureDeleted();
			Database.EnsureCreated();

			if (!Category.Any())
			{
				Category Toys = new Category { Name = "Toys", Slug = "" };
				Category Plugs = new Category { Name = "Plugs", Slug = "" };

				Product p1 = new Product { Name = "Teddy", Category = Toys, Price = 200, Description = "teddy", Slug = "", };
				Product p2 = new Product { Name = "Doll", Category = Toys, Price = 250, Description = "doll", Slug = "" };
				Product p3 = new Product { Name = "SomePlug", Category = Plugs, Price = 150, Description = "goodplug", Slug = "" };
				Product p4 = new Product { Name = "Bear", Category = Toys, Price = 250, Description = "bear(imaginary)", Slug = "" };
				Product p5 = new Product { Name = "AnotherPlug", Category = Plugs, Price = 150, Description = "badplug", Slug = "" };
				Category.AddRange(Toys, Plugs);
				Product.AddRange(p1, p2, p3, p4, p5);
				SaveChanges();

			}
		}
		public DbSet<Product> Product { get; set; } = default!;
		public DbSet<Category> Category { get; set; } = default!;
	}
}
