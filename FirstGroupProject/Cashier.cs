using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FirstGroupProject
{
    public class Cashier
    {
        public Cashier()
        {

        }
        //methods 
        public decimal AddTax(decimal subtotal)
        {
            decimal salesTax = subtotal * 0.06m;
            Console.WriteLine($"Tax: ${Math.Round(salesTax, 2)}");
            decimal grandTotal = subtotal + salesTax;
            return grandTotal;
        }
        public decimal AcceptCash(decimal grandTotal)
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
        public void AcceptCard()
        {
            bool finishCheckout = true;
            while (finishCheckout)
            {
                Console.WriteLine("Please enter your credit card number. (Do not include spaces or dashes)");
                string cardNumber = Console.ReadLine();

                    if (Regex.IsMatch(cardNumber, @"^(?:4[0-9]{12}(?:[0-9]{3})?|5[1-5][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\d{3})\d{11})$"))
                    {
                        while (finishCheckout)
                        {
                            Console.Write("Please enter card's expiration date (MM/YY): ");
                            string cardExpDate = Console.ReadLine();

                            if (Regex.IsMatch(cardExpDate, @"^(0[1-9]|1[0-2])\/?([0-9]{2})$"))
                            {
                                while (finishCheckout)
                                {
                                    Console.Write("Please enter the card's CVV: ");
                                    string cardCVV = Console.ReadLine();
                                    if (!Regex.IsMatch(cardCVV, @"^[0-9]{3, 4}$"))
                                    {
                                        finishCheckout = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("That was not a valid CVV.");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("That is not a valid expiration date.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("That was not a valid card number.");
                    }
            }
        }
        public void AcceptCheck()
        {
            int checkNumber = 0;
            Console.WriteLine("Please enter the 4-digit check number:");
            while (!int.TryParse(Console.ReadLine(), out checkNumber))
            {
                Console.WriteLine("Not a check number. Please try again: ");
            }
        }
    }
}
