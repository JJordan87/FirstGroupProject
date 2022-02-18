
using FirstGroupProject;
using System.Text.RegularExpressions;

Console.Title = "Lucas & Jon's Game Shop!";
Console.WindowWidth = 150;

bool runProgram = true;
bool checkOut = true;
int customerItemChoice = 0;
int itemQuantityChoice = 0;
decimal customerSubtotal = 0m;
string paymentChoice = "";

Menu menu = new Menu();
Cashier newCashier = new Cashier();
List<Product> cart = new List<Product>();
menu.CreateProductFile(); //- To create the text file intitially
menu.ReadTextFile();
while (runProgram)
{
    //reset cart
    cart.Clear();
    Console.Clear();
    //intro message
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Welcome to Lucas & Jon's game shop!");
    Console.ResetColor();
    Console.WriteLine();
    Console.WriteLine("#    " + String.Format("{0,-25}{1,-10}{2,-15}{3,-30}", "Name: ", "Price: ", "Category: ", "Description: "));
    menu.ListProducts();
    while (checkOut)
    {
        //showing menu (should let them choose by number)
        while (true)
        {
            ChooseItem();
            if (customerItemChoice >= 1 && customerItemChoice <= menu.Products.Count() && customerItemChoice != 2)
            {
                
                ChooseQuantity();
                //Adds to cart & displays Line Total
                AddToCart();
                break;
            }
            else if (customerItemChoice == 2)
            {
                Console.WriteLine("Sorry this item is no longer available. Please try again on the Playstation 6!");
            }
            else if (customerItemChoice == 0)
            {
                Console.WriteLine("#    " + String.Format("{0,-25}{1,-10}{2,-15}{3,-30}", "Name: ", "Price: ", "Category: ", "Description: "));
                menu.ListProducts();
            }
            else
            {
                Console.WriteLine("Sorry that was not a valid input.");
            }
        }
        Console.WriteLine();

        checkOut = Validator.Validator.GetContinue("Would you like to add another item to your cart? (y) or checkout (n)?: ");
    }
    //Calculating and displaying cart total
    Console.WriteLine();
    Console.WriteLine($"Subtotal: ${customerSubtotal}");
    //Displaying the grand total 
    decimal grandTotal = newCashier.AddTax(customerSubtotal);
    Console.WriteLine($"Grand total: ${Math.Round(grandTotal, 2)}");
    Console.WriteLine();

    //accepting payment from user
    while (true)
    {
        Console.Write("How would you like to pay? We accept cash, credit, or check: ");
        paymentChoice = Console.ReadLine().ToLower().Trim();
        if (paymentChoice == "cash")
        {
            decimal change = newCashier.AcceptCash(grandTotal);
            Console.WriteLine($"Your change is: ${Math.Round(change, 2)}");
            break;
        }
        else if (paymentChoice == "credit")
        {
            newCashier.AcceptCard();
            break;
        }
        else if (paymentChoice == "check")
        {
            newCashier.AcceptCheck();
            break;
        }
        else
        {
            Console.WriteLine("Not a valid input.");
        }
    }
    checkOut = true;
    Console.WriteLine("\n");
    //start of receipt
    //header
    Console.WriteLine(String.Format("{0}", centeredString("Lucas & Jon's game shop!", 75)));
    Console.WriteLine(String.Format("{0}", centeredString("1234 Gamer Ave, Grand Rapids, MI", 75)));
    Console.WriteLine();

    //display items back to user
    DisplayCart();


    //displaying $$ totals
    Console.WriteLine("\n");
    Console.WriteLine($"Subtotal: \t${customerSubtotal}");
    Console.WriteLine($"Grand Total: \t${Math.Round(grandTotal, 2)}"); //TODO: format
    Console.WriteLine($"Purchased by: {paymentChoice}.");

    Console.WriteLine();
    runProgram = Validator.Validator.GetContinue("Would you like to start a new cart? y/n: "); 
}
//menu.Products.Add(new Product("Used GOT", "video game", "game", 25.00m));

menu.UpdateProductFile();

//methods

int ChooseItem()
{
    Console.WriteLine();
    Console.Write("Enter a number to select an item (0 to re-display menu): ");
    
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
    customerSubtotal = cart.Sum(product => product.Price);
    Console.WriteLine($"Awesome! {itemQuantityChoice} {chosenProduct.Name} will be added to your cart for ${customerLineTotal}.");
    Console.WriteLine($"Your new subtotal is {customerSubtotal}");
}

static string centeredString(string s, int width)
{
    if (s.Length >= width)
    {
        return s;
    }

    int leftPadding = (width - s.Length) / 2;
    int rightPadding = width - s.Length - leftPadding;

    return new string(' ', leftPadding) + s + new string(' ', rightPadding);
}



