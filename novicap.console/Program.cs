using novicap.app;
using novicap.app.Exceptions;
using novicap.app.repositories;
using novicap.respository;
using System;
using System.Collections;
using System.Configuration;
using System.IO;

namespace novicap
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
        }

        private static void Init()
        {
            string path = string.Empty;
            try
            {
                path = ConfigurationManager.AppSettings.Get("PricingDataFilePath");
                PricingRepository repository = new PricingRepository(path);
                Hashtable pricingData = repository.GetPricingData();
                Checkout checkout = new Checkout(pricingData);
                while (true)
                {
                    Console.WriteLine("Enter 1 to scan data.");
                    Console.WriteLine("Enter 2 to calculate total price");
                    Console.WriteLine("Enter 0 to quit.");
                    string input = Console.ReadLine();
                    if(input == "0")
                    {
                        break;
                    }
                    else if(input == "1")
                    {
                        Console.WriteLine("Enter the item code");
                        string item = Console.ReadLine();
                        try
                        {
                            checkout.scan(item.ToUpper());
                        }
                        catch(ProductNotFoundException exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                    }
                    else if(input == "2")
                    {
                        Console.WriteLine("Total price is " + checkout.total().ToString());
                    }
                }

            }
            catch(FileNotFoundException fileEx)
            {
                Console.WriteLine(string.Format("Invalid file path " + path + " for pricing data in app.settings"));
                // Console.WriteLine(fileEx.ToString());
            }
            catch(DuplicateKeyException dEx)
            {
                Console.WriteLine(string.Format("Pricing rules has duplicate keys"));
            }
            catch(Exception ex)
            {
                Console.Write("Unknown Exception :");
                Console.WriteLine(ex.ToString());
                Console.WriteLine(typeof(Exception));
            }
        }
    }
}
