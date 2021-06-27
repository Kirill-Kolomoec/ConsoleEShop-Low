using System;
using System.Collections.Generic;
using System.Text;

namespace Store
{
    class Order
    {
        public static uint staticID = 0;
        public uint ID { get; set; }
        public StatusOrder Status { get; set; }
        public string NameUser { get; set; }
        public string City { get; set; }
        private  List<Product> ProdList;


        public Order()
        {

        }

        public Order(uint ID, StatusOrder Status, string NameUser, string City)
        {
            this.ID = ID;
            this.Status = Status;
            this.NameUser = NameUser;
            this.City = City;
            this.ProdList = new List<Product>();
        }

        public void ChangeStatusOrder()
        {
            Console.WriteLine("-------StatusOrder--------");
            Console.Write("1.New\n2.CanceledAdmin\n3.PaymentReceived\n4.Sent\n5.Received");

            while (true)
            {
                try
                {
                    Console.Write("\n(Enter Stop to return to the menu)\n");
                    Console.WriteLine("\nWhich order do you like to edit - ");


                    string caseSwitch = Console.ReadLine();
                    if (caseSwitch == "Stop" || caseSwitch == "stop" || caseSwitch == "STOP")
                    {
                        
                        break;
                    }

                    switch (Convert.ToInt32(caseSwitch))
                    {
                        case 1:
                            Status = StatusOrder.New;
                            Console.WriteLine("StatusOrder has been changed on New");
                            break;
                        case 2:
                            Status = StatusOrder.CanceledAdmin;
                            Console.WriteLine("StatusOrder has been changed on CanceledAdmin");
                            break;
                        case 3:
                            Status = StatusOrder.PaymentReceived;
                            Console.WriteLine("StatusOrder has been changed on PaymentReceived");
                            break;
                        case 4:
                            Status = StatusOrder.Sent;
                            Console.WriteLine("StatusOrder has been changed on Sent");
                            break;
                        case 5:
                            Status = StatusOrder.Received;
                            Console.WriteLine("StatusOrder has been changed on Received");
                            break;
                        default:
                            Console.WriteLine("There is no such StatusOrder");
                            break;
                    }



                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("There is no product with such index, enter another index!\n");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("There is no product with such index, enter another index!\n");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter string instead of string\n");
                }

            }


            

        }


        public void PrintProductList()
        {
            foreach (var item in ProdList)
            {
                item.Print();
            }


        }
        public void AddProduct(int index)
        {
           
            ProdList.Add(ProductList.products[index]);
        }
        public void RemoveAt()
        {
            int index;
            Console.Write($"Enter index of elemet, which you would like to remove - ");
            index = Convert.ToInt32(Console.ReadLine());
            ProdList.RemoveAt(index);
        }
        

        public void Print()
        {
            Console.WriteLine("------------------------------------");
            Console.Write($"ID: {ID}\nStatus: {Status}\nNameUser: {NameUser}\nCity: {City}\nProductList:\n");
            PrintProductList();
            Console.WriteLine("------------------------------------");

        }

        public void Ordering()
        {
            int n = 0;
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("-----------------ProductList----------------");
            
            foreach (var item in ProductList.products)
            {
                Console.WriteLine("-------------------------------");
                Console.WriteLine($"{n}. {item.Name}");
                Console.WriteLine("-------------------------------");
                n++;
            }
            Console.WriteLine("--------------------------------------------");



            Console.WriteLine($"Ordering");
            staticID += 1;
            this.ID = staticID;
            this.Status = StatusOrder.New;
            Console.Write($"Enter Name - ");
            this.ProdList = new List<Product>();
            this.NameUser = Console.ReadLine();
            Console.Write($"Enter City - ");
            this.City = Console.ReadLine();
            
           
            
            while (true)
            {
                try
                {
                    Console.Write("Enter index of product - ");

                    string index = Console.ReadLine();
                    if (index == "Stop" || index == "stop" || index == "STOP")
                    {
                        Console.Write("Enter esc to return to the menu - ");
                        break;
                    }
                    AddProduct(Convert.ToInt32(index));
                }
                
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("There is no product with such index, enter another index!\n");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Enter string instead of string\n");
                }
                







            }
            
            
            


        }


    }
    enum StatusOrder
    {
        New,
        CanceledAdmin,
        PaymentReceived,
        Sent,
        Received,
        Completed,
        CanceledUser
    }
}
