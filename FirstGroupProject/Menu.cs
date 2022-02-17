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
            new Product("Xbox series x", "Microsoft 's newest Xbox model", "Console", 499.99m),
            new Product("Playstation 5", "Sony's newest Playstation model", "Console", 499.99m),
            new Product("Nintendo Switch OLED", "Nintendo 's newest Switch model", "Console", 499.99m),
            new Product("Xbox Controller", "Controller used for the Xbox one and Xbox Series X", "Accessory", 59.99m),
            new Product("Playstation Controller", "Controller used for the Playstation 5", "Accessory", 69.99m),
            new Product("Nintendo Switch Joycon Pair", "Controller used for the Nintendo Switch", "Accessory", 79.99m),
            new Product("Sea of Thieves", "A game that is developed by Rare and published by Microsoft", "Video Game", 59.99m), 
            new Product("Ghost of Tsushima", "A game that is developed by Sucker Punch and published by Sony", "Video Game", 59.99m),
            new Product("GOAT Gamer Memberhsip", "Annual subscription to our exclusive gaming club membership", "Subscription", 14.99m),
            new Product("T-Shirt", "Basic t-shirts containing our brand name and logo", "Apparel", 19.99m),
            new Product("Gamer Guarantee Warranty", "Tech protection for one year on any console or video game purchased", "Warranty", 99.99m),
            new Product("Super Smash Bros Ultimate", " A game that is developed by Bandai Namco and published by Nintendo", "Video Game", 59.99m),
        };

        public void ListProducts()
        {
            for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine($"{i + 1} {Products[i].ToDisplayString()}"); //TODO: needs format
            }
        }


    }
}
