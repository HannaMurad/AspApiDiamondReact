using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SlutProject.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Diamond> Diamonds { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //seed diamonds

            modelBuilder.Entity<Diamond>().HasData(new Diamond
            {
                DiamondId = 1,
                Name = "Cocktail Ring",
                Price = 1200.95M,
                Description = "Our famous diamond ring!",
                ImageName = "pro01.jpg",
                InStock = true,
                OnSale = true
            });

            modelBuilder.Entity<Diamond>().HasData(new Diamond
            {
                DiamondId = 2,
                Name = "Mourning Ring",
                Price = 1800.95M,
                Description = "A summer classic!",
                ImageName = "pro02.jpg",
                InStock = true,
                OnSale = false
            });

            modelBuilder.Entity<Diamond>().HasData(new Diamond
            {
                DiamondId = 3,
                Name = "Cameo Ring",
                Price = 1800.95M,
                Description = "Blazing as fire",
                ImageName = "pro03.jpg",
                InStock = true,
                OnSale = false
            });

            modelBuilder.Entity<Diamond>().HasData(new Diamond
            {
                DiamondId = 4,
                Name = "Eternity Ring",
                Price = 1500.95M,
                Description = "Everlasting love",
                ImageName = "pro04.jpg",
                InStock = true,
                OnSale = false
            });

            modelBuilder.Entity<Diamond>().HasData(new Diamond
            {
                DiamondId = 5,
                Name = "Puzzle Ring",
                Price = 1300.95M,
                Description = "A Christmas favorite",
                ImageName = "pro05.jpg",
                InStock = true,
                OnSale = false
            });

            modelBuilder.Entity<Diamond>().HasData(new Diamond
            {
                DiamondId = 6,
                Name = "Rosary Ring",
                Price = 1700.95M,
                Description = "Pure daimond. Pure pleasure.",
                ImageName = "pro06.jpg",
                InStock = true,
                OnSale = false
            });

            modelBuilder.Entity<Diamond>().HasData(new Diamond
            {
                DiamondId = 7,
                Name = "Purity Ring",
                Price = 1500.95M,
                Description = "My God, so elegent!",
                ImageName = "pro07.jpg",
                InStock = false,
                OnSale = false
            });

            modelBuilder.Entity<Diamond>().HasData(new Diamond
            {
                DiamondId = 8,
                Name = "Birthstone Ring",
                Price = 1200.95M,
                Description = "Happy holidays with this ring!",
                ImageName = "pro08.jpg",
                InStock = true,
                OnSale = true
            });


            modelBuilder.Entity<Diamond>().HasData(new Diamond
            {
                DiamondId = 9,
                Name = "Armour Ring",
                Price = 1500.95M,
                Description = "You'll love it!",
                ImageName = "pro09.jpg",
                InStock = true,
                OnSale = true
            });
 
        }
    }
}
