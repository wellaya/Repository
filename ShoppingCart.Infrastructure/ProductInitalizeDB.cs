using ShoppingCart.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Infrastructure
{

    public class ProductInitalizeDB : DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            GetCategories().ForEach(c => context.Categories.Add(c));
            GetProducts().ForEach(p => context.Products.Add(p));
            context.SaveChanges();
            base.Seed(context);
        }

        private static List<Category> GetCategories()
        {
            var categories = new List<Category> {
                new Category
                {
                    Id = 1,
                    Name = "Cars"
                },
                new Category
                {
                    Id = 2,
                    Name = "Planes"
                },
                new Category
                {
                    Id = 3,
                    Name = "Trucks"
                },
                new Category
                {
                    Id = 4,
                    Name = "Boats"
                },
                new Category
                {
                    Id = 5,
                    Name = "Rockets"
                },
            };

            return categories;
        }

        private static List<Product> GetProducts()
        {
            var products = new List<Product> {
                new Product
                {
                    Id = 1,
                    Name = "Convertible Car",
                    Description = "This convertible car is fast! The engine is powered by a neutrino based battery (not included)." +
                                  "Power it up and let it go!",
                    ImagePath="carconvert.png",
                    Price = 22.50m,
                    CategoryID = 1
               },
                new Product
                {
                    Id = 2,
                    Name = "Old-time Car",
                    Description = "There's nothing old about this toy car, except it's looks. Compatible with other old toy cars.",
                    ImagePath="carearly.png",
                    Price = 15.95m,
                     CategoryID = 1
               },
                new Product
                {
                    Id = 3,
                    Name = "Fast Car",
                    Description = "Yes this car is fast, but it also floats in water.",
                    ImagePath="carfast.png",
                    Price = 32.99m,
                    CategoryID = 1
                },
                new Product
                {
                    Id = 4,
                    Name = "Super Fast Car",
                    Description = "Use this super fast car to entertain guests. Lights and doors work!",
                    ImagePath="carfaster.png",
                    Price = 8.95m,
                    CategoryID = 1
                },
                new Product
                {
                    Id = 5,
                    Name = "Old Style Racer",
                    Description = "This old style racer can fly (with user assistance). Gravity controls flight duration." +
                                  "No batteries required.",
                    ImagePath="carracer.png",
                    Price = 34.95m,
                    CategoryID = 1
                },
                new Product
                {
                    Id = 6,
                    Name = "Ace Plane",
                    Description = "Authentic airplane toy. Features realistic color and details.",
                    ImagePath="planeace.png",
                    Price = 95.00m,
                    CategoryID = 2
                },
                new Product
                {
                    Id = 7,
                    Name = "Glider",
                    Description = "This fun glider is made from real balsa wood. Some assembly required.",
                    ImagePath="planeglider.png",
                    Price = 4.95m,
                    CategoryID = 2
                },
                new Product
                {
                    Id = 8,
                    Name = "Paper Plane",
                    Description = "This paper plane is like no other paper plane. Some folding required.",
                    ImagePath="planepaper.png",
                    Price = 2.95m,
                    CategoryID = 2
                },
                new Product
                {
                    Id = 9,
                    Name = "Propeller Plane",
                    Description = "Rubber band powered plane features two wheels.",
                    ImagePath="planeprop.png",
                    Price = 32.95m,
                    CategoryID = 2
                },
                new Product
                {
                    Id = 10,
                    Name = "Early Truck",
                    Description = "This toy truck has a real gas powered engine. Requires regular tune ups.",
                    ImagePath="truckearly.png",
                    Price = 15.00m,
                    CategoryID = 3
                },
                new Product
                {
                    Id = 11,
                    Name = "Fire Truck",
                    Description = "You will have endless fun with this one quarter sized fire truck.",
                    ImagePath="truckfire.png",
                    Price = 26.00m,
                    CategoryID = 3
                },
                new Product
                {
                    Id = 12,
                    Name = "Big Truck",
                    Description = "This fun toy truck can be used to tow other trucks that are not as big.",
                    ImagePath="truckbig.png",
                    Price = 29.00m,
                    CategoryID = 3
                },
                new Product
                {
                    Id = 13,
                    Name = "Big Ship",
                    Description = "Is it a boat or a ship. Let this floating vehicle decide by using its " +
                                  "artifically intelligent computer brain!",
                    ImagePath="boatbig.png",
                    Price = 95.00m,
                    CategoryID = 4
                },
                new Product
                {
                    Id = 14,
                    Name = "Paper Boat",
                    Description = "Floating fun for all! This toy boat can be assembled in seconds. Floats for minutes!" +
                                  "Some folding required.",
                    ImagePath="boatpaper.png",
                    Price = 4.95m,
                    CategoryID = 4
                },
                new Product
                {
                    Id = 15,
                    Name = "Sail Boat",
                    Description = "Put this fun toy sail boat in the water and let it go!",
                    ImagePath="boatsail.png",
                    Price = 42.95m,
                    CategoryID = 4
                },
                new Product
                {
                    Id = 16,
                    Name = "Rocket",
                    Description = "This fun rocket will travel up to a height of 200 feet.",
                    ImagePath="rocket.png",
                    Price = 122.95m,
                    CategoryID = 5
                }
            };

            return products;
        }
    }
}