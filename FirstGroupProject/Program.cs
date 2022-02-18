﻿
using FirstGroupProject;
using System.Text.RegularExpressions;

bool runProgram = true;
bool checkOut = true;
int customerItemChoice = 0;
int itemQuantityChoice = 0;
decimal customerSubtotal = 0m;
Menu menu = new Menu();
Cashier newCashier = new Cashier();
List<Product> cart = new List<Product>();

while (runProgram)
{
    //reset cart
    cart.Clear();
    Console.Clear();
    //intro message
    Console.WriteLine("Welcome to Lucas & Jon's game shop!");
    Console.WriteLine();
    while (checkOut)
    {
        //showing menu (should let them choose by number)
        Console.WriteLine("#    " + String.Format("{0,-25}{1,-10}{2,-15}{3,-30}", "Name: ", "Price: ", "Category: ", "Description: "));
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
        Console.WriteLine();
        customerSubtotal = cart.Sum(product => product.Price);
        checkOut = Validator.Validator.GetContinue("Would you like to return to the menu? (y) or checkout (n)?: ");
    }
    //Calculating and displaying cart total
    //customerSubtotal = cart.Sum(product => product.Price);
    Console.WriteLine();
    Console.WriteLine($"Subtotal: ${customerSubtotal}");
    //Displaying the grand total 
    decimal grandTotal = newCashier.AddTax(customerSubtotal);
    Console.WriteLine($"Grand total: ${Math.Round(grandTotal, 2)}");
    Console.WriteLine();

    //accepting payment from user
    Console.Write("How would you like to pay? We accept cash, credit, or check: ");
    string paymentChoice = Console.ReadLine().ToLower().Trim();
    if (paymentChoice == "cash")
    {
        decimal change = newCashier.AcceptCash(grandTotal);
        Console.WriteLine($"Your change is: ${Math.Round(change, 2)}");
    }
    else if (paymentChoice == "credit")
    {
        newCashier.AcceptCard();
    }
    else if (paymentChoice == "check")
    {
        newCashier.AcceptCheck();
    }
    else
    {
        Console.WriteLine("Not a valid input.");
    }
    //display all chosen items in cart
    Console.WriteLine();
    DisplayCart();
    checkOut = true;

    //displaying $$ totals
    Console.WriteLine();
    Console.WriteLine($"Subtotal: \t${customerSubtotal}");
    Console.WriteLine($"Grand Total: \t${Math.Round(grandTotal, 2)}");
    Console.WriteLine($"Purchased by: {paymentChoice}.");

    Console.WriteLine();
    runProgram = Validator.Validator.GetContinue("Would you like to start a new cart? y/n: "); //TODO: fix loop to rerun program & not just keep showing total
}


//methods

int ChooseItem()
{
    Console.WriteLine();
    Console.Write("Enter a number to select an item: ");
    
    while (!int.TryParse(Console.ReadLine(), out customerItemChoice))
    {
        if (customerItemChoice > 0 && customerItemChoice < 13)
        {
            
        }
        else
        {
            
        }
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
    Console.WriteLine($"Awesome! {itemQuantityChoice} {chosenProduct.Name} will be added to your cart for ${customerLineTotal}.");
    Console.WriteLine($"Your new subtotal is {customerSubtotal}");
}



