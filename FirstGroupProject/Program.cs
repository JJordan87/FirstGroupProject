
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
decimal change = 0;
int transactionNumber = 1000;

Menu menu = new Menu();
Cashier newCashier = new Cashier();
List<Product> cart = new List<Product>();
menu.CreateProductFile(); //- To create the text file intitially
menu.ReadTextFile();
while (runProgram)
{
    transactionNumber++;
    //reset cart
    cart.Clear();
    Console.Clear();
    //intro message
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine("Welcome to Lucas & Jon's Game Shop!");
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
                Console.WriteLine("Sorry this item is no longer available. Please be faster next time!");
            }
            else if (customerItemChoice == 0)
            {
                Console.WriteLine("#    " + String.Format("{0,-25}{1,-10}{2,-15}{3,-30}", "Name: ", "Price: ", "Category: ", "Description: "));
                menu.ListProducts();
            }
            else if(customerItemChoice == (menu.Products.Count()+1))
            {
                cart.Clear();
                Console.WriteLine("Your cart has been cleared.");
            }
            else
            {
                Console.WriteLine("Sorry that was not a valid input.");
            }
        }
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        checkOut = Validator.Validator.GetContinue("Would you like to add another item to your cart? [y] or checkout [n]?: ");
        Console.ResetColor();
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
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("How would you like to pay? We accept cash, credit, or check: ");
        Console.ResetColor();
        paymentChoice = Console.ReadLine().ToLower().Trim();

        if (paymentChoice == "cash")
        {
            change = newCashier.AcceptCash(grandTotal);
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
    Console.WriteLine();
    //start of receipt
    //header
    Console.BackgroundColor = ConsoleColor.DarkGray;
    Console.ForegroundColor = ConsoleColor.DarkBlue;
    Console.WriteLine();
    Console.WriteLine(String.Format("{0}", centeredString("Lucas & Jon's game shop!", 75)));
    Console.ResetColor();
    Console.BackgroundColor = ConsoleColor.DarkGray;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine(String.Format("{0}", centeredString("1234 Gamer Ave, Grand Rapids, MI", 75)));
    Console.WriteLine(String.Format("{0}", centeredString("Receipt #: " + transactionNumber, 75)));
    Console.WriteLine();

    //display items back to user
    DisplayCart();


    //displaying $$ totals
    Console.WriteLine("\n");
    Console.WriteLine($"Subtotal: \t${customerSubtotal}");
    Console.WriteLine($"Grand Total: \t${Math.Round(grandTotal, 2)}");
    Console.WriteLine($"Purchased by: {paymentChoice}.");
    if (paymentChoice == "cash")
    {
        Console.WriteLine($"Change: ${Math.Round(change, 2)}");
    }
    Console.ResetColor();
    Console.WriteLine();
    Console.WriteLine();

    Console.ForegroundColor = ConsoleColor.DarkGreen;
    bool isTrading = Validator.Validator.GetContinue("Would you like to trade in a game product? [y] or [n]: ");
    Console.ResetColor();
    if (isTrading)
    {
        menu.Products.Add(AddToMenu());
    }
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    runProgram = Validator.Validator.GetContinue("Would you like to start a new cart? [y] or [n]: ");
    Console.ResetColor();
}

menu.UpdateProductFile();

//methods

int ChooseItem()
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.Write("Enter a number to select an item or [0] to display menu: ");
    Console.ResetColor();

    while (!int.TryParse(Console.ReadLine(), out customerItemChoice))
    {
        Console.Write("Not a valid option. Please try again: ");
    }
    return customerItemChoice;
}

int ChooseQuantity()
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.Write("How many would you like to purchase?: ");
    Console.ResetColor();
    while (!int.TryParse(Console.ReadLine(), out itemQuantityChoice))
    {
        Console.Write("Not a valid option. Please try again: ");
    }
    return itemQuantityChoice;
}

void DisplayCart()
{
    List<Product> distinctCart = cart.GroupBy(p => p.Name).Select(p => p.First()).ToList();

    foreach (Product i in distinctCart)
    {
        int count = cart.Where(p => p.Name == i.Name).Count();
        Console.WriteLine($"{i} (x{count})");
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
    Console.WriteLine($"Awesome! {itemQuantityChoice} {chosenProduct.Name} will be added to your cart for ${customerLineTotal}");
    Console.WriteLine($"Your new subtotal is ${customerSubtotal}");
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

static Product AddToMenu()
{
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.Write("What is the product name?: ");
    Console.ResetColor();
    string newName = Console.ReadLine();
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.Write("Give a description of the product: ");
    Console.ResetColor();
    string newDescrtiption = Console.ReadLine();
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.Write("What is the products category?: ");
    Console.ResetColor();
    string newCategory = Console.ReadLine();
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.Write("What is the price?: ");
    Console.ResetColor();
    decimal newPrice;
    while (!decimal.TryParse(Console.ReadLine(), out newPrice))
    {
        Console.Write("Not a valid option. Please try again: ");
    }
    Product newProduct = new Product(newName, newDescrtiption, newCategory, (newPrice * 2));
    return newProduct;
}



