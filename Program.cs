using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstBankOfSuncoast
{
    class Transactions
    {
        public string Account { get; set; }
        public string DepOrWith { get; set; }
        public int Amount { get; set; }

        public DateTime TransactionTime;
    }
    class Program
    {

        static void Greeting(string prompt)
        {
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Welcome to the First Bank of SunCoast");
            Console.WriteLine("");
            Console.WriteLine("");
        }
        static void Main(string[] args)
        {

            Greeting("Welcome to the First Bank of SunCoast");

            var transactions = new List<Transactions>()
            {
              new Transactions
              {
                Account="Savings",
                DepOrWith="Deposit",
                Amount=45,
                TransactionTime=DateTime.Now,
              },

              new Transactions()
              {
                Account="Checking",
                DepOrWith="Deposit",
                Amount=150,
                TransactionTime=DateTime.Now,
              },

              new Transactions()
              {
                Account="Checking",
                DepOrWith="Withdraw",
                Amount=30,
                TransactionTime=DateTime.Now,
              },
              new Transactions()
              {
                Account="Savings",
                DepOrWith="Withdraw",
                Amount=5,
                TransactionTime=DateTime.Now,
              }

            };
            var userQuit = false;
            while (userQuit == false)
            {
                Console.WriteLine("");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("View");
                Console.WriteLine("Deposit");
                Console.WriteLine("Withdraw");
                Console.WriteLine("Quit");

                var userInput = Console.ReadLine().ToLower().Trim();

                if (userInput == "view")
                {
                    Console.Write("Would you like to view your Savings or Checking History?");
                    var SorC = Console.ReadLine().ToLower();

                    if (SorC == "savings" || SorC == "s")
                    {
                        var savings = transactions.Where(savings => savings.Account.ToLower() == "savings");
                        foreach (var save in savings)
                        {
                            Console.WriteLine($"Your Transaction History: {save.Account}, {save.DepOrWith}, {save.Amount} at {save.TransactionTime}");
                        }
                    }
                    if (SorC == "checking" || SorC == "c")
                    {
                        var checking = transactions.Where(checking => checking.Account.ToLower() == "checking");
                        foreach (var check in checking)
                        {
                            Console.WriteLine($"Your Transaction History: {check.Account}, {check.DepOrWith}, {check.Amount} at {check.TransactionTime}");
                        }
                    }

                }

                if (userInput == "deposit")
                {
                    Console.Write("Would you like to deposit into your checkings or savings? ");
                    var depositAccount = Console.ReadLine();

                    Console.Write("How much would you like to deposit? ");
                    var depositAmount = Console.ReadLine();


                    var newtransaction = new Transactions();
                    newtransaction.Account = depositAccount;
                    newtransaction.Amount = int.Parse(depositAmount);
                    newtransaction.DepOrWith = "Deposit";
                    newtransaction.TransactionTime = DateTime.Now;

                    transactions.Add(newtransaction);

                    Console.WriteLine($"Thank you! Your deposit of {depositAmount} has been applied to your {depositAccount} account.");

                }





                if (userInput == "quit")
                {
                    userQuit = true;
                }
            }







            Greeting("Thank you for your buisness");

        }
    }
}

