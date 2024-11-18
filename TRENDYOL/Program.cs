using Microsoft.EntityFrameworkCore;
using TRENDYOL.Core;
using TRENDYOL.Helpers;
using TRENDYOL.Models;

namespace TRENDYOL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            string title = "*******************MRSTORE****************";
            Console.ForegroundColor = ConsoleColor.Green;
            for(int i=0; i<title.Length-1; i++)
            {
               
                Console.Write(title[i]);
                Thread.Sleep(50);
            }
            Console.WriteLine(title[title.Length-1]);
            Console.ForegroundColor= ConsoleColor.White;
            EFcore eFcore = new EFcore();
            eFcore.product_bot();
            bool menu1= false;
            bool menu2= false;  
            bool menu3= false;
            bool deyisen= false;
            string username = null;
            string sifre;
            string ad;
            do
            {
                Console.ForegroundColor=ConsoleColor.Yellow;
                Console.WriteLine("\n\n\n1.Qeydiyyatdan kec\n\n\n\n2.Daxil ol\n\n");
                Console.ForegroundColor=ConsoleColor.White;
                int giris1;
                do
                {
                    deyisen=int.TryParse(Console.ReadLine(), out giris1);


                }while (!deyisen);
                Console.Beep();
                switch (giris1)
                {
                    case 1:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("\nAd daxil edin : ");
                        string name = Console.ReadLine();
                        Console.Write("\nSoyad daxil edin : ");
                        string surname = Console.ReadLine();
                        
                        string password=null;
                        bool check=false;
                        
                        do
                        {
                            Console.Write("Istifadeci adi daxil edin : ");
                            username = Console.ReadLine();
                            Console.Write("Sifre teyin edin : ");
                            password = Console.ReadLine();
                            if (username.Trim() != "" && password.Trim() != "")
                            {


                                check = true;

                            }
                            else
                            {

                                Console.Beep();
                                Console.Beep();
                                Console.Beep();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("ISTIFADECI ADI VE SIFRE MUTLEQ DOLDURULMALIDIR!");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        while (!check);
                        Users users = new Users {Name=name.Trim(),Username=username.Trim(),Password=password.Trim(),Surname=surname.Trim()};
                        eFcore.Add_User(users);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("HESABINIZ MUVEFFEQIYYETLE YARADILDI !");
                        Console.Beep();
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                        case 2:
                        Console.Clear();
                        do
                        {

                            
                            bool check2 = false;
                            do
                            {



                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.Write("\n\n\nIstifadeci adi : ");
                                ad = Console.ReadLine();
                                Console.Write("\n\n\nSifre : ");
                                sifre = Console.ReadLine();

                                check2 = eFcore.Check_User(ad, sifre);

                                if (check2 == false)
                                {
                                    Console.Beep();
                                    Console.Beep();
                                    Console.Beep();
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("Istifadeci adi ve yaxud sifre yanlisdir");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }

                            } while (!check2);
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Xos Geldiniz");
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            do
                            {
                                Console.Clear() ;
                               
                                Console.WriteLine($"                                                                                                  USER:{ad}\n\n\n1.Mehsullara bax\n\n\n2.Sebete bax\n\n\n3.Hesabdan cix ");

                                int giris2;
                                do
                                {
                                    deyisen = int.TryParse(Console.ReadLine(), out giris2);
                                } while (!deyisen);
                                switch (giris2)
                                {
                                    case 1:
                                        Console.Beep();
                                        Console.Clear();
                                        

                                        eFcore.Show_products();
                                      
                                        Console.Write("Sebete elave et(Mehsul id):");
                                        
                                        int mehsulsecimi;
                                        bool mehsulcheck = false;
                                        do
                                        {
                                            do
                                            {
                                                deyisen = int.TryParse(Console.ReadLine(), out mehsulsecimi);
                                                if (deyisen == false)
                                                {
                                                    Console.Beep();
                                                    Console.Beep();
                                                    Console.Beep();
                                                    Console.ForegroundColor = ConsoleColor.Red;
                                                    Console.WriteLine("Reqem daxil edin");
                                                    Console.ForegroundColor = ConsoleColor.White;
                                                }
                                            } while (!deyisen);
                                            mehsulcheck = eFcore.Check_product(mehsulsecimi);
                                            if (mehsulcheck == false)
                                            {
                                                Console.Beep();
                                                Console.Beep();
                                                Console.Beep();
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("Bele id-li mehsul yoxdur");
                                                Console.ForegroundColor = ConsoleColor.White;
                                            }


                                        } while (!mehsulcheck);

                                        using (AppDbContex contex = new AppDbContex())
                                        {
                                            Products products = new Products();
                                            products = contex.Products.Find(mehsulsecimi);


                                            Baskets baskets = new Baskets
                                            {
                                                ProductsID = products.ID,
                                                UsersID = eFcore.User_ID(ad)
                                            };
                                            contex.Baskets.Add(baskets);
                                            contex.SaveChanges();
                                            Console.ForegroundColor = ConsoleColor.Green;
                                            Console.WriteLine("ADDED");
                                            Console.Beep();
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Thread.Sleep(1000);




                                        }
                                        break;
                                    case 2:
                                        Console.Beep();
                                        Console.Clear();

                                        List<Products> basket = eFcore.Show_Basket(eFcore.User_ID(ad));
                                        if(basket.Any()==false)
                                        {
                                            Console.Beep();
                                            Console.Beep();
                                            Console.Beep();
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine("Sebet bosdur");
                                            Console.ForegroundColor = ConsoleColor.White;
                                            Thread.Sleep(1000);
                                            break;
                                        }
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("**************************");
                                        Console.ForegroundColor=ConsoleColor.White;
                                        foreach (var item in basket)
                                        {
                                            Thread.Sleep(100);
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("-------------------------");
                                            
                                            Console.WriteLine("|"+item.ID+"."+item.Name+" - "+item.Price+" $ |");
                                            Console.WriteLine("-------------------------");
                                            Console.ForegroundColor= ConsoleColor.White;
                                        }
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("**************************");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.Write("\nSilmek istediyiniz mehsulu daxin edin (Id) : ");
                                        int id;
                                        do
                                        {
                                            deyisen = int.TryParse(Console.ReadLine(), out id);

                                            if(deyisen==false)
                                            {
                                                Console.Beep();
                                                Console.Beep();
                                                Console.Beep();
                                                Console.ForegroundColor=ConsoleColor.Red;
                                                Console.WriteLine("Reqem daxil edin");
                                                Console.ForegroundColor=ConsoleColor.White;
                                            }
                                        } while (!deyisen);
                                        using (AppDbContex contex=new())
                                        {
                                            contex.Baskets.Where(x=> x.ProductsID==id).ExecuteDelete();
                                            contex.SaveChanges();
                                        }
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Beep();
                                        Console.WriteLine("Removed!");
                                       
                                        Console.ForegroundColor=ConsoleColor.White ;
                                        Thread.Sleep(1000); 




                                        break;

                                    case 3:
                                        Console.Beep();
                                        Console.Clear();
                                        menu3=true;
                                        menu2 = true;
                                        break;
                                    
                                }
                               

                            } while (!menu3);
                            
                        } while (!menu2);
                        break;

                        
                   
                }


            } while (!menu1);
            

        }
    }
}
