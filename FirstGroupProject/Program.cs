
using FirstGroupProject;

bool runProgram = true;
bool checkOut = true;
int customerItemChoice = 0;
int itemQuantityChoice = 0;
Menu menu = new Menu();
List<Product> cart = new List<Product>();
Console.WriteLine("Welcome to Lucas & Jon's game shop!");
Console.WriteLine();

while (runProgram)
{
    while (checkOut)
    {
        //showing menu (should let them choose by number)
        menu.ListProducts();
        ChooseItem();
        if (customerItemChoice >= 1 && customerItemChoice <= menu.Products.Count())
        {
            ChooseQuantity();   
            //Adds to cart & displays Line Total
            AddToCart();
        }
        else
        {
            Console.WriteLine("Sorry that was not a valid input");
        }
       checkOut = Validator.Validator.GetContinue("Would you like to add more items (y) or checkout (n)?");

    }
    decimal customerOrderTotal = 0m;
    DisplayCart();
    //Calculating and displaying cart total
    customerOrderTotal = cart.Sum(product => product.Price);
    Console.WriteLine($"Your order total is: {customerOrderTotal}");
    runProgram = Validator.Validator.GetContinue("Would you like to continue? y/n: ");//TODO: fix loop to rerun program & not just keep showing total
    Console.WriteLine();
}

//methods

int ChooseItem()
{
    Console.WriteLine();
    Console.Write("Enter a number to select an item: ");
    while (!int.TryParse(Console.ReadLine(), out customerItemChoice))
    {
        Console.Write("Not a valid option. Please try again: ");
    }
    return customerItemChoice;
}

int ChooseQuantity()
{
    Console.Write("How many would you like to purchase?: ");
    while (!int.TryParse(Console.ReadLine(), out itemQuantityChoice))
    {
        Console.Write("Not a valid option. Please try again: ");
    }
    return itemQuantityChoice;
}

void DisplayCart()
{
    foreach (Product i in cart)
    {
        Console.WriteLine(i);
    }
}

void AddToCart()
{
    Product chosenProduct = menu.Products[customerItemChoice - 1];
    for (int i = 0; i < itemQuantityChoice; i++)
    {
        cart.Add(chosenProduct);
    }
    decimal customerLineTotal = itemQuantityChoice * chosenProduct.Price;
    Console.WriteLine($"{customerLineTotal} will be added to your cart.");
}