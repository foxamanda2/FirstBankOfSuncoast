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
            Console.WriteLine(prompt);
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public static int AccountTotal(List<Transactions> transaction, string account)
        {
            var savings = transaction.Where(savings => savings.Account.ToLower().First() == account.First());
            var deposit = savings.Where(saving => saving.DepOrWith.ToLower() == "deposit");
            var withdraw = savings.Where(withdraw => withdraw.DepOrWith.ToLower() == "withdraw");

            var depositvalue = deposit.Sum(value => value.Amount);
            var withdrawvalue = withdraw.Sum(value => value.Amount);

            var deposittotal = depositvalue - withdrawvalue;

            return deposittotal;

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
                Console.WriteLine("View: Transaction History");
                Console.WriteLine("Balance");
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
                            Console.WriteLine($"Your Transaction History: Your{save.Account} was {save.DepOrWith} on {save.TransactionTime}:\n ${save.Amount}");
                        }
                    }
                    if (SorC == "checking" || SorC == "c")
                    {
                        var checking = transactions.Where(checking => checking.Account.ToLower() == "checking");
                        foreach (var check in checking)
                        {
                            Console.WriteLine($"Your Transaction History: Your {check.Account} was {check.DepOrWith} on {check.TransactionTime}:\n ${check.Amount}");
                        }
                    }

                }

                if (userInput == "balance")
                {
                    Console.Write("Would you like to view your savings or checking?");
                    var SorC = Console.ReadLine().ToLower();

                    if (SorC == "savings" || SorC == "s")
                    {
                        var totalbalance = AccountTotal(transactions, SorC);

                        Console.WriteLine(totalbalance);


                    }

                    if (SorC == "checking" || SorC == "c")
                    {

                        var totalbalance = AccountTotal(transactions, SorC);

                        Console.WriteLine(totalbalance);

                    }

                }

                if (userInput == "deposit")
                {
                    Console.Write("Would you like to deposit into your checking or savings? ");
                    var depositAccount = Console.ReadLine();

                    Console.Write("How much would you like to deposit? ");
                    var depositAmount = int.Parse(Console.ReadLine());
                    // if (depositAccount == "savings" || depositAccount == "s")
                    // {
                    //     savingsbalance += depositAmount;
                    // }
                    // if (depositAccount == "checking" || depositAccount == "c")
                    // {
                    //     checkingbalance += depositAmount;
                    // }


                    var newtransaction = new Transactions();
                    newtransaction.Account = depositAccount;
                    newtransaction.Amount = depositAmount;
                    newtransaction.DepOrWith = "Deposit";
                    newtransaction.TransactionTime = DateTime.Now;

                    transactions.Add(newtransaction);

                    Console.WriteLine($"Thank you! Your deposit of {depositAmount} has been applied to your {depositAccount} account.");

                }

                if (userInput == "withdraw")
                {
                    Console.Write("Would you like to withdraw from your checking or savings?");
                    var withdrawAccount = Console.ReadLine().ToLower();

                    if (withdrawAccount == "savings" || withdrawAccount == "s")
                    {
                        var totalbalance = AccountTotal(transactions, withdrawAccount);

                        Console.WriteLine(totalbalance);

                        Console.Write("How much would you like to withdraw? ");
                        var amountWithdraw = int.Parse(Console.ReadLine());


                        if (amountWithdraw < totalbalance)
                        {
                            var newtransaction = new Transactions();
                            newtransaction.Account = withdrawAccount;
                            newtransaction.Amount = (amountWithdraw);
                            newtransaction.DepOrWith = "Withdraw";
                            newtransaction.TransactionTime = DateTime.Now;

                            transactions.Add(newtransaction);

                        }

                        if (amountWithdraw > totalbalance)
                        {
                            Console.WriteLine("Insufficient funds");
                        }
                    }

                    if (withdrawAccount == "checking" || withdrawAccount == "c")
                    {
                        var totalbalance = AccountTotal(transactions, withdrawAccount);

                        Console.Write("How much would you like to withdraw? ");
                        var amountWithdraw = int.Parse(Console.ReadLine());


                        if (amountWithdraw < totalbalance)
                        {
                            var newtransaction = new Transactions();
                            newtransaction.Account = withdrawAccount;
                            newtransaction.Amount = (amountWithdraw);
                            newtransaction.DepOrWith = "Withdraw";
                            newtransaction.TransactionTime = DateTime.Now;

                            transactions.Add(newtransaction);

                        }

                        if (amountWithdraw > totalbalance)
                        {
                            Console.WriteLine("Insufficient funds");
                        }
                    }
                }


                if (userInput == "quit")
                {
                    userQuit = true;
                }
            }


            Greeting("Thank you for your business");

        }
    }
}

