// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using EcommerceFronted.models;

// namespace EcommerceFronted.customServer
// {
//     public static  class ProductService
//     {
//        static List<Products> productslist = new List<Products>()
//         {
//             new Products
//             {
//                 Id = 1,
//                 Name = "Shoes",
//                 Description = "Shoe from UK",
//                 dateAdded = DateTime.Now.ToString(),
//                 price = 2000,
//             },
//             new Products
//             {
//                 Id = 2,
//                 Name = "Laptop",
//                 Description = "High-performance laptop",
//                 dateAdded = DateTime.Now.AddDays(-7).ToString(), // Custom date: 7 days ago
//                 price = 1500,
//             },
//             new Products
//             {
//                 Id = 3,
//                 Name = "T-shirt",
//                 Description = "Cotton T-shirt",
//                 dateAdded = DateTime.Now.AddMonths(-1).ToString(), 
//                 price = 25,
//             },
//             new Products
//             {
//                 Id = 4,
//                 Name = "Smartphone",
//                 Description = "Latest smartphone model",
//                 dateAdded = DateTime.Now.AddDays(-15).ToString(), 
//                 price = 800,
//             },
//             new Products
//             {
//                 Id = 5,
//                 Name = "Watch",
//                 Description = "Luxury watch",
//                 dateAdded = DateTime.Now.AddYears(-2).ToString(), 
//                 price = 500,
//             },
//             new Products
//             {
//                 Id = 6,
//                 Name = "Backpack",
//                 Description = "Durable backpack",
//                 dateAdded = DateTime.Now.AddMonths(-3).ToString(), 
//                 price = 50,
//             }
//         };



//     public  static List<Products> getAllproducts()
//     {
//         return productslist;
//     }


//     public static Products getProductByID(int id)
//     {
//        Products products= productslist.FirstOrDefault(e=>e.Id==id);
//        return products;
//     }

    
//     }




// }
