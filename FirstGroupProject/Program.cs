
using FirstGroupProject;
using System.Text.RegularExpressions;

bool runProgram = true;
bool checkOut = true;
int customerItemChoice = 0;
int itemQuantityChoice = 0;
decimal customerSubtotal = 0m;
decimal salesTax = 0;
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
            Console.WriteLine("Sorry that was not a valid input.");
        }
        checkOut = Validator.Validator.GetContinue("Would you like to add more items (y) or checkout (n)?: ");

    }
    //display all chosen items in cart
    Console.WriteLine();
    DisplayCart();
    //Calculating and displaying cart total
    customerSubtotal = cart.Sum(product => product.Price);
    Console.WriteLine();
    Console.WriteLine($"Subtotal: {customerSubtotal}");
    //Displaying the grand total 
    decimal grandTotal = AddTax(customerSubtotal);
    Console.WriteLine($"Grand total: {Math.Round(grandTotal, 2)}");
    Console.WriteLine();
    //accepting payment from user
    Console.Write("How would you like to pay? We accept cash, credit, or check: ");
    string paymentChoice = Console.ReadLine().ToLower().Trim();
    if (paymentChoice == "cash")
    {
        decimal change = AcceptCash(grandTotal);
        Console.WriteLine($"Your change is: {Math.Round(change, 2)}");
    }
    else if(paymentChoice == "credit")
    {
        AcceptCard();        
    }



    runProgram = Validator.Validator.GetContinue("Would you like to continue? y/n: "); //TODO: fix loop to rerun program & not just keep showing total
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

decimal AddTax(decimal subtotal)
{
    decimal salesTax = customerSubtotal * 0.06m;
    Console.WriteLine($"Tax: {Math.Round(salesTax, 2)}");
    decimal grandTotal = customerSubtotal + salesTax;
    return grandTotal;
}

decimal AcceptCash(decimal grandTotal)
{
    Console.Write("Enter tendered cash amount: ");
    decimal tenderedCash = 0;
    while (!decimal.TryParse(Console.ReadLine(), out tenderedCash))
    {
        Console.Write("Not a valid option. Please try again: ");
    }
    decimal change = tenderedCash - grandTotal;

    return change;
}

void AcceptCard()
{
    string cardNumber = Console.ReadLine();
    ValidateCard(cardNumber);
}

bool ValidateCard(string cardNumber)
{
    if (Regex.IsMatch(cardNumber, @"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$"))
    {
        return true;
    }
    else
    {
        Console.WriteLine("That was not a valid card number.");
        return false;
    }
}


