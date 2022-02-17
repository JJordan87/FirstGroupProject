
using FirstGroupProject;
bool runProgram = true;
Menu menu = new Menu();

Console.WriteLine("Welcome to Lucas & Jon's game shop!");
Console.WriteLine();

while (runProgram)
{
    //showing menu (should let them choose by number)
    menu.ListProduct();

    Console.WriteLine();
    Console.Write("Enter a number to select an item: ");

    //Let user choose item
    int customerItemChoice = 0;
    while (!int.TryParse(Console.ReadLine(), out customerItemChoice))
    {
        Console.Write("Not a valid option. Please try again: ");
    }

    if (customerItemChoice >= 1 && customerItemChoice <= menu.product.Count())
    {
        Console.Write("How many would you like to purchase?: ");

        //user chooses quantity of item 
        int itemQuantityChoice = 0;
        while (!int.TryParse(Console.ReadLine(), out itemQuantityChoice))
        {
            Console.WriteLine("Not a valid option. Please try again: ");
        }
        //display Line Total
        Product chosenProduct = menu.product[customerItemChoice - 1];

        decimal customerLineTotal = itemQuantityChoice * chosenProduct.Price;

        Console.WriteLine($"The total for that is: {customerLineTotal}"); // needs format

        List<Product> cart = new List<Product>();
        cart.Add(chosenProduct);
        foreach (Product i in cart)
        {
            Console.WriteLine(cart);
        }

    }
    else
    {
        Console.WriteLine("Sorry that was not a valid input");
    }
    runProgram = Validator.Validator.GetContinue("Would you like to continue? y/n: ");
}

//methods
//static int ChooseItem(string x)
//{
//    int customerItemChoice = 0;
//    while (!int.TryParse(Console.ReadLine(), out customerItemChoice))
//    {
//        Console.Write("Not a valid option. Please try again: ");
//    }
//    return customerItemChoice;
//}



//void DisplayCart()
//{
//    List<Product> cart = new List<Product>();
//    for (int i = 0; i < cart.Count; i++)
//    {
//        Console.WriteLine($"{i + 1} {cart[i].ToString()}");//need to format eventually
//    }
//}
