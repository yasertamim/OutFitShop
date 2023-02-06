using Microsoft.AspNetCore.Identity;
using OutFitShop.Models;

namespace OutFitShop.Data
{
    public class ApplicationDbInitializer
    {
        public static async void Initializer(ApplicationDbContext db, UserManager<ApplicationUser> um, RoleManager<IdentityRole> rm)
        {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var admin = new IdentityRole("Admin");

            rm.CreateAsync(admin).Wait();

            var adminUser = new ApplicationUser { Email = "yaser@uia.no", UserName = "yaser@uia.no", EmailConfirmed = true };
            um.CreateAsync(adminUser, "Password.1").Wait();

            var user = new ApplicationUser { Email = "yaser@gmail.com", UserName = "yaser@gmail.com", EmailConfirmed = true };
            um.CreateAsync(user, "Password.1").Wait();



            var products = new[]
            {
                new Product("Shirt", Category.Categ.menn,"this shirt is awsome", 40, "/media/shirt.jpg"),
                new Product("Shirt", Category.Categ.menn,"this shirt is awsome", 40,"/media/shirt.jpg"),
                new Product("Shirt", Category.Categ.menn,"this shirt is awsome", 40,"/media/shirt.jpg"),
                new Product("Shirt", Category.Categ.menn,"this shirt is awsome", 40,"/media/shirt.jpg"),
                new Product("Shirt", Category.Categ.menn,"this shirt is awsome", 40,"/media/shirt.jpg"),
                new Product("Shirt", Category.Categ.menn,"this shirt is awsome", 40,"/media/shirt.jpg"),
            };

            db.Products.AddRange(products);
            db.SaveChanges();

            var products2 = new[]
      {
                new Product("Shirt", Category.Categ.women,"this shirt is awsome", 70, "/media/womenpants.jpg"),
                new Product("Shirt", Category.Categ.women,"this shirt is awsome", 70,"/media/womenpants.jpg"),
                new Product("Shirt", Category.Categ.women,"this shirt is awsome", 70,"/media/swomenpants.jpg"),
                new Product("Shirt", Category.Categ.women,"this shirt is awsome", 70,"/media/womenpants.jpg"),
                new Product("Shirt", Category.Categ.women,"this shirt is awsome", 70,"/media/womenpants.jpg"),
                new Product("Shirt", Category.Categ.women,"this shirt is awsome", 70,"/media/womenpants.jpg"),
            };

            db.Products.AddRange(products2);
            db.SaveChanges();


            var products3 = new[]
       {
                new Product("Shirt", Category.Categ.babies,"this shirt is awsome", 120, "/media/baby.png"),
                new Product("Shirt", Category.Categ.babies,"this shirt is awsome", 120,"/media/baby.png"),
                new Product("Shirt", Category.Categ.babies,"this shirt is awsome", 120,"/media/baby.png"),
                new Product("Shirt", Category.Categ.babies,"this shirt is awsome", 120,"/media/baby.png"),
                new Product("Shirt", Category.Categ.babies,"this shirt is awsome", 120,"/media/baby.png"),
                new Product("Shirt", Category.Categ.babies,"this shirt is awsome", 120,"/media/baby.png"),
            };

            db.Products.AddRange(products3);
            db.SaveChanges();



            var products4 = new[]
{
                new Product("Shirt", Category.Categ.accessories,"this shirt is awsome", 130, "/media/access.jpg"),
                new Product("Shirt", Category.Categ.accessories,"this shirt is awsome", 130,"/media/access.jpg"),
                new Product("Shirt", Category.Categ.accessories,"this shirt is awsome", 130,"/media/access.jpg"),
                new Product("Shirt", Category.Categ.accessories,"this shirt is awsome", 130,"/media/access.jpg"),
                new Product("Shirt", Category.Categ.accessories,"this shirt is awsome", 130,"/media/access.jpg"),
                new Product("Shirt", Category.Categ.accessories,"this shirt is awsome", 130,"/media/access.jpg"),
            };

            db.Products.AddRange(products4);
            db.SaveChanges();


            //var order = new Order(DateTime.Now);
            //order.User = user;
            //db.Orders.Add(order);

            //db.SaveChanges();


            //var order2 = new Order(DateTime.Now);
            //order2.User = user;
            //db.Orders.Add(order2);

            //db.SaveChanges();


            //var orderLine = new OrderLine(1);

        
            //orderLine.Product = products[1];
          
            //db.OrderLines.Add(orderLine);
            //db.SaveChanges();

            //var orderLine2 = new OrderLine(1);

            //orderLine2.ProductId = products[1].Id;
            //orderLine2.Product = products2[1];
            //orderLine2.OrderId = order.Id;
            //orderLine2.Order = order;

            //db.OrderLines.Add(orderLine2);
            //db.SaveChanges();







        }
    }
}
