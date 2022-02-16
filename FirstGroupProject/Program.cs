
using FirstGroupProject;
bool runProgram = true;
Menu menu = new Menu(); 

Console.WriteLine("Welcome to Lucas & Jon's game shop.");

while (runProgram)
{
    //showing menu (should let them choose by number)
    menu.ListProduct();

    Console.WriteLine();
    Console.WriteLine("Enter a number to select an item.");

    //Let user choose item

    int customerItemChoice = 0;
    while (!int.TryParse(Console.ReadLine(), out customerItemChoice))
    {
        Console.Write("Not a valid option. Please try again.");
    }

    if (customerItemChoice >= 1 && customerItemChoice <= menu.product.Count())
    {
        Console.WriteLine("How many would you like to purchase?");
        //let user choose quantity of item 
        int itemQuantityChoice = 0;
        while (!int.TryParse(Console.ReadLine(), out itemQuantityChoice))
        {
            Console.WriteLine("Not a valid option. Please try again.");
        }
        //display Line Total
        Product product = menu.product[customerItemChoice - 1];
        decimal customerLineTotal = itemQuantityChoice * product.Price;
        Console.WriteLine($"{customerLineTotal}");
    }
}
