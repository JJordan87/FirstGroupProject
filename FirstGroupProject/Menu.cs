using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstGroupProject
{
    internal class Menu
    {
        public List<Product> Products = new List<Product>()
        {
        };

        public void ListProducts()
        {
            for (int i = 0; i < Products.Count; i++)
            {
                if (i < 9)
                {
                    Console.WriteLine($"[{i + 1}]  {Products[i].ToDisplayString()}"); 
                }
                else
                {
                    Console.WriteLine($"[{i + 1}] {Products[i].ToDisplayString()}"); 
                }
            }
            Console.WriteLine("[" + (Products.Count + 1) + "] To clear cart");
        }

        public void CreateProductFile()
        {
             List<Product> pods = new List<Product>()
             {
                new Product("Xbox Series X", "Microsoft's newest Xbox model.", "Console", 499.99m),
                new Product("Playstation 5", "Sony's newest Playstation model.", "Console", 499.99m),
                new Product("Nintendo Switch OLED", "Nintendo 's newest Switch model.", "Console", 499.99m),
                new Product("Xbox Controller", "Wireless controller compatible with Xbox one & Xbox Series X", "Accessory", 59.99m),
                new Product("Playstation Controller", "Wireless controller comnpatible with Playstation 5", "Accessory", 69.99m),
                new Product("Switch Joycon Pair", "Controller used for the Nintendo Switch", "Accessory", 79.99m),
                new Product("Sea of Thieves", "A game that is developed by Rare, and published by Microsoft.", "Video Game", 59.99m),
                new Product("Ghost of Tsushima", "A game that is developed by Sucker Punch, and published by Sony.", "Video Game", 59.99m),
                new Product("Super Smash Bros", "A game that is developed by Bandai Namco, and published by Nintendo.", "Video Game", 59.99m),
                new Product("GOAT Gamer Memberhsip", "Annual subscription to our exclusive gaming club membership.", "Subscription", 14.99m),
                new Product("T-Shirt", "Basic t-shirts containing our brand name and logo.", "Apparel", 19.99m),
                new Product("Gamer Guarantee Warranty", "Tech protection for one year on any console or video game purchased.", "Warranty", 99.99m),
             };

            string productFilePath = "../../../Products.txt";
            if (File.Exists(productFilePath) == false)
            {
                StreamWriter tempProductwriter = new StreamWriter(productFilePath);

                foreach (Product p in pods)
                {
                    tempProductwriter.WriteLine($"{p.Name}/{p.Description}/{p.Category}/{p.Price}");
                }
                tempProductwriter.Close();
            }
        }

        public void ReadTextFile()
        {
            string productFilePath = "../../../Products.txt";
            StreamReader ProductReader = new StreamReader(productFilePath);
            while (true)
            {
                string Line = ProductReader.ReadLine();
                if (Line == null)
                {
                    break;
                }
                else
                {
                    string[] properties = Line.Split("/");
                    string name = properties[0];
                    string description = properties[1];
                    string category = properties[2];
                    decimal price = decimal.Parse(properties[3]);
                    Products.Add(new Product(name, description, category, price));
                }
            }
            ProductReader.Close();

        }

        public void UpdateProductFile()
        {
            string productFilePath = "../../../Products.txt";

            StreamWriter tempProductwriter = new StreamWriter(productFilePath);

            foreach (Product p in Products)
            {
                tempProductwriter.WriteLine($"{p.Name}/{p.Description}/{p.Category}/{p.Price}");
            }
            tempProductwriter.Close();
        }
    }
}

