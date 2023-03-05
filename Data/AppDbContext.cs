using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Auction_House.Models
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole, String>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Seller> Sellers { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Seller_Item> Sellers_Items { get; set; }


        public object Bids { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Seller_Item>().HasKey(am => new
            {
                am.SellerId,
                am.ItemId
            });

            modelBuilder.Entity<Seller_Item>().HasOne(m => m.Seller).WithMany(am => am.Seller_Items).HasForeignKey(m => m.SellerId);
            modelBuilder.Entity<Seller_Item>().HasOne(m => m.Item).WithMany(am => am.Seller_Items).HasForeignKey(m => m.ItemId);


            modelBuilder.Entity<Seller>().HasData(
                new Seller()
                {
                    Id = -1,
                    FullName = "Billy Butcher",
                    Bio = "This is the Bio of the first seller",

                },
                new Seller()
                {
                    Id = -2,
                    FullName = "John Wick",
                    Bio = "This is the Bio of the second seller",
                   
                }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = -1,
                    Name = "Xbox Controller",
                    Description = "The controller features a predominantly white color scheme," +
                    " with black accents and a green Xbox logo button in the center. It has two thumbsticks, " +
                    "a directional pad, four face buttons, two triggers, two bumpers, and a set of menu buttons" +
                    ". The controller connects wirelessly to the Xbox console or PC using Bluetooth technology," +
                    " and it requires two AA batteries for power." +
                    " The white Xbox controller is a popular accessory for gamers who prefer a classic design and a comfortable," +
                    " responsive gaming experience.",
                    MinimumBid = 39.50,
                    AuctionStart = DateTime.Now.AddDays(-10),
                    AuctionEnd = DateTime.Now.AddDays(10),
                    ItemCondition = ItemCondition.BrandNew,
                    ItemCategory = ItemCategory.Electronics,
                    ImageURL = "/img/xboxcontroller.jpg"
                },
                new Item()
                {
                    Id = -2,
                    Name = "Gaming Chair",
                    Description = " specialized chair designed for gamers who spend long hours playing video games." +
                    " These chairs are typically designed with comfort and support in mind, " +
                    "and are often highly adjustable to fit the needs of individual users.",
                    MinimumBid = 29.50,
                    AuctionStart = DateTime.Now,
                    AuctionEnd = DateTime.Now.AddDays(3),
                    ItemCondition = ItemCondition.Refurbished,
                    ItemCategory = ItemCategory.Furniture,
                    ImageURL = "/img/gamerchair.jpg"
                },
                new Item()
                {
                    Id = -3,
                    Name = "Backpack",
                    Description = "This high-quality backpack is an essential accessory for anyone on-the-go. " +
                    "It boasts durable materials, multiple compartments, and specialized features such as padded straps or water-resistant materials. " +
                    "Available in various styles, colors, and patterns to suit individual preferences," +
                    " this backpack is a practical and stylish choice for everyday use or outdoor adventures." +
                    " Shop now to experience the comfort and convenience of this versatile accessory!",
                    MinimumBid = 29.50,
                    AuctionStart = DateTime.Now,
                    AuctionEnd = DateTime.Now.AddDays(3),
                    ItemCondition = ItemCondition.BrandNew,
                    ItemCategory = ItemCategory.Clothing,
                    ImageURL = "/img/backpack.jpg"
                },
                new Item()
                {
                    Id = -4,
                    Name = "Beats",
                    Description = "Experience exceptional sound quality and stylish design with these Beats headphones. " +
                    "The headphones feature high-quality sound drivers, noise-cancelling technology," +
                    " and Bluetooth connectivity for seamless wireless use. The sleek design is available in various colors to suit individual preferences," +
                    " and the headphones come with a convenient carrying case for on-the-go use. " +
                    "Whether you're listening to music or taking calls," +
                    " these Beats headphones deliver exceptional sound and style. " +
                    "Shop now to experience the ultimate in headphone technology!",
                    MinimumBid = 29.50,
                    AuctionStart = DateTime.Now,
                    AuctionEnd = DateTime.Now.AddDays(3),
                    ItemCondition = ItemCondition.Refurbished,
                    ItemCategory = ItemCategory.Electronics,
                    ImageURL = "/img/beats.jpg"
                },
                new Item()
                {
                    Id = -5,
                    Name = "Desk Lamp",
                    Description = "Illuminate your workspace with this stylish and functional desk lamp. " +
                    "Featuring adjustable brightness levels and color temperature, " +
                    "this lamp provides the perfect lighting for any task. The sleek design is perfect for modern or traditional decor, " +
                    "and the lamp is made with high-quality materials for durability and long-lasting use. " +
                    "Whether you're working late into the night or need a focused light for reading," +
                    " this desk lamp is the perfect solution. Shop now to enhance your productivity and workspace!",
                    MinimumBid = 29.50,
                    AuctionStart = DateTime.Now,
                    AuctionEnd = DateTime.Now.AddDays(3),
                    ItemCondition = ItemCondition.BrandNew,
                    ItemCategory = ItemCategory.Furniture,
                    ImageURL = "/img/desklamp.jpg"
                },
               
                new Item()
                {
                    Id = -6,
                    Name = "Hoodie",
                    Description = "Stay comfortable and stylish with this grey hoodie." +
                    " Made with high-quality materials, this hoodie is soft, warm," +
                    " and perfect for everyday wear. The classic design features a comfortable fit," +
                    " drawstring hood, and kangaroo pocket for added convenience. " +
                    "The neutral grey color is perfect for pairing with any outfit," +
                    " and the hoodie is available in various sizes to suit individual preferences. " +
                    "Whether you're lounging at home or running errands, this grey hoodie is the perfect choice for comfort and style." +
                    " Shop now to upgrade your wardrobe!",
                    MinimumBid = 29.50,
                    AuctionStart = DateTime.Now,
                    AuctionEnd = DateTime.Now.AddDays(3),
                    ItemCondition = ItemCondition.BrandNew,
                    ItemCategory = ItemCategory.Clothing,
                    ImageURL = "/img/hoodie.jpg"
                }
            );
        }

        private static IFormFile CreateFormFile(string filePath, string contentType, string fileName)
        {
            var fileContents = System.IO.File.ReadAllBytes(filePath);
            return new FormFile(
                baseStream: new System.IO.MemoryStream(fileContents),
                baseStreamOffset: 0,
                length: fileContents.Length,
                name: "file",
                fileName: fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = contentType
            };
        }

        public static async Task SeedUsersAndRolesAsync(IServiceProvider serviceProvider)
        {
            //Roles
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            string adminUserEmail = "admin@AuctionHouse.com";

            var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
            if (adminUser == null)
            {
                var newAdminUser = new ApplicationUser()
                {
                    FullName = "buyer",
                    UserName = "buyer",
                    Email = adminUserEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(newAdminUser, "buyer");
                await userManager.AddToRoleAsync(newAdminUser, Data.Static.UserRoles.Admin);
            }
            string appUserEmail = "user@AuctionHouse15.com";

            var appUser = await userManager.FindByEmailAsync(appUserEmail);
            if (appUser == null)
            {
                var newAppUser = new ApplicationUser()
                {
                    FullName = "Application User",
                    UserName = "app-user",
                    Email = appUserEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(newAppUser, "buyer");
                await userManager.AddToRoleAsync(newAppUser, Data.Static.UserRoles.User);
            }
        }
    }

}
