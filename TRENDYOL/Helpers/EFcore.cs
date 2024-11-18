using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using TRENDYOL.Core;
using TRENDYOL.Models;

namespace TRENDYOL.Helpers
{
    public class EFcore
    {
        List<Users>userler = new List<Users>();
        List<Users>users = new List<Users>();
        public void Add_User(Users users)
        {
            using (AppDbContex contex = new())
            {
               
                contex.Users.Add(users);
                userler=contex.Users.ToList();
                
                contex.SaveChanges();
            }
        }
        public void Show_products()
        {
            using (AppDbContex contex=new())
            {
                List<Products> products = new List<Products>();
                products= contex.Products.ToList();
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("*****************************");
                Console.BackgroundColor = default;
                foreach (Products p in products)
                {
                    Console.WriteLine("-------------------------");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Thread.Sleep(200);
                    Console.WriteLine("|" + p.ID + "." + p.Name + "-" + p.Price + "$ |");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("*****************************");
                Console.BackgroundColor = default;
            }
        }
       
        public bool Check_User(string name,string password)
        {
            bool isLogin = false;
            List<Users> users = new List<Users>();
            using (AppDbContex contex=new())
            {
                users = contex.Users.ToList();

                
            }
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].Username == name && users[i].Password==password)
                {
                    isLogin = true;
                    break;
                }
            }
            return isLogin;
        }
        public bool Check_product (int id )
        {
            bool isProduct = false;
            List <Products> products = new List<Products>();
            using(AppDbContex contex=new())
            {
                products = contex.Products.ToList();
            }
            for     (int i = 0;i < products.Count;i++)
            {
                if (products[i].ID==id)
                {
                    isProduct = true;
                    break;
                }
            }
            return isProduct;
        }

        public int User_ID(string username)
        {
           using (AppDbContex contex=new())
            {
                userler = contex.Users.ToList();
            }
            users.Clear();
            users = userler.FindAll(x => x.Username == username);
            return users[0].ID;
        }

        public List<Products> Show_Basket(int id)
        {
         
            using (var context = new AppDbContex())
            {
                List<Baskets> baskets = new List<Baskets>();
                baskets = context.Baskets.ToList();
                var z =baskets.FindAll(x => x.UsersID==id);
                List<Products> products = new List<Products>();
                products=context.Products.ToList();
                
                List<Products> products1 = [];    
                  
                List<Products> inbasket = new List<Products>();
                for (int i =0;i<z.Count;i++)
                {
                    for (int j = 0; j < products.Count; j++)
                    {
                        if (z[i].ProductsID == products[j].ID)
                        {
                            
                            products1.Add(products[j]);
                        }
                    }
                }
                return products1;
            }
               
        }
        public void product_bot()
        {

            Products product = new Products { Name = "Numune", Price = 9 };
              Products product2 =new Products{Name="Numune",Price=5};
              Products product3 =new Products{Name="Numune",Price=4};
              Products product4 =new Products{Name="Numune",Price=2};
            using (AppDbContex contex=new())
            {
                contex.Products.Add(product);
                contex.Products.Add(product2);
                contex.Products.Add(product3);
                contex.Products.Add(product4);
                contex.SaveChanges();

            }
           

        }
    }
}
