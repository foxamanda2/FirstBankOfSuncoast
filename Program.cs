using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

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
            var acc = transaction.Where(acct => acct.Account.ToLower() == account);
            var deposit = acc.Where(saving => saving.DepOrWith.ToLower() == "deposit");
            var withdraw = acc.Where(withdraw => withdraw.DepOrWith.ToLower() == "withdraw");
            var transferto = acc.Where(withdraw => withdraw.DepOrWith.ToLower() == "transferred to");
            var transferfrom = acc.Where(withdraw => withdraw.DepOrWith.ToLower() == "transferred from");

            var depositvalue = deposit.Sum(value => value.Amount);
            var withdrawvalue = withdraw.Sum(value => value.Amount);
            var transfertovalue = transferto.Sum(value => value.Amount);
            var transferfromvalue = transferfrom.Sum(value => value.Amount);

            var deposittotal = (depositvalue - withdrawvalue) + transfertovalue - transferfromvalue;

            return deposittotal;
        }

        public static string Prompt(string prompt)
        {
            Console.Write(prompt);
            var input = Console.ReadLine().ToLower();
            return input;
        }

        static void Main(string[] args)
        {


            Greeting("Welcome to the First Bank of SunCoast");

            var fileReader = new StreamReader("transactions.csv");

            var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
            var transaction = csvReader.GetRecords<Transactions>().ToList();

            fileReader.Close();


            // var transactions = new List<Transactions>()
            // {
            //   new Transactions
            //   {
            //     Account="Savings",
            //     DepOrWith="Deposit",
            //     Amount=45,
            //     TransactionTime=DateTime.Now,
            //   },

            //   new Transactions()
            //   {
            //     Account="Checking",
            //     DepOrWith="Deposit",
            //     Amount=150,
            //     TransactionTime=DateTime.Now,
            //   },

            //   new Transactions()
            //   {
            //     Account="Checking",
            //     DepOrWith="Withdraw",
            //     Amount=30,
            //     TransactionTime=DateTime.Now,
            //   },
            //   new Transactions()
            //   {
            //     Account="Savings",
            //     DepOrWith="Withdraw",
            //     Amount=5,
            //     TransactionTime=DateTime.Now,
            //   }

            // };


            var userQuit = false;
            while (userQuit == false)
            {
                Console.WriteLine("");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("View: Transaction History");
                Console.WriteLine("Balance");
                Console.WriteLine("Deposit");
                Console.WriteLine("Withdraw");
                Console.WriteLine("Transfer");
                Console.WriteLine("Quit");

                var userInput = Console.ReadLine().ToLower().Trim();

                if (userInput == "view")
                {
                    var SorC = Prompt("Would you like to view your Savings or Checking History?");

                    if (SorC == "savings" || SorC == "s")
                    {
                        var savings = transaction.Where(savings => savings.Account.ToLower() == "savings");
                        foreach (var save in savings)
                        {
                            Console.WriteLine($"Your Transaction History: Your {save.Account} was {save.DepOrWith} on {save.TransactionTime}:\n ${save.Amount}");
                        }
                    }
                    if (SorC == "checking" || SorC == "c")
                    {
                        var checking = transaction.Where(checking => checking.Account.ToLower() == "checking");
                        foreach (var check in checking)
                        {
                            Console.WriteLine($"Your Transaction History: Your {check.Account} was {check.DepOrWith} on {check.TransactionTime}:\n ${check.Amount}");
                        }
                    }

                }

                if (userInput == "balance")
                {
                    var SorC = Prompt("Would you like to view your savings or checking?");

                    if (SorC == "savings" || SorC == "s")
                    {
                        var totalbalance = AccountTotal(transaction, SorC);

                        Console.WriteLine(totalbalance);

                    }

                    if (SorC == "checking" || SorC == "c")
                    {

                        var totalbalance = AccountTotal(transaction, SorC);

                        Console.WriteLine(totalbalance);
                    }
                }

                if (userInput == "deposit")
                {
                    var depositAccount = Prompt("Would you like to deposit into your checking or savings? ");

                    var depositAmount = int.Parse(Prompt("How much would you like to deposit? "));

                    var newtransaction = new Transactions();
                    newtransaction.Account = depositAccount;
                    newtransaction.Amount = depositAmount;
                    newtransaction.DepOrWith = "Deposit";
                    newtransaction.TransactionTime = DateTime.Now;

                    transaction.Add(newtransaction);

                    var fileWriter = new StreamWriter("transactions.csv");

                    var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);

                    csvWriter.WriteRecords(transaction);

                    fileWriter.Close();

                    Console.WriteLine($"Thank you! Your deposit of {depositAmount} has been applied to your {depositAccount} account.");

                }

                if (userInput == "withdraw")
                {
                    var withdrawAccount = Prompt("Would you like to withdraw from your checking or savings?");

                    if (withdrawAccount == "savings" || withdrawAccount == "s")
                    {
                        var totalbalance = AccountTotal(transaction, withdrawAccount);

                        Console.WriteLine($"Your current balance is: {totalbalance}");

                        var amountWithdraw = int.Parse(Prompt("How much would you like to withdraw? "));

                        if (amountWithdraw < totalbalance)
                        {
                            var newtransaction = new Transactions();
                            newtransaction.Account = withdrawAccount;
                            newtransaction.Amount = (amountWithdraw);
                            newtransaction.DepOrWith = "Withdraw";
                            newtransaction.TransactionTime = DateTime.Now;

                            transaction.Add(newtransaction);

                            var fileWriter = new StreamWriter("transactions.csv");

                            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);

                            csvWriter.WriteRecords(transaction);

                            fileWriter.Close();

                        }

                        if (amountWithdraw > totalbalance)
                        {
                            Console.WriteLine("Insufficient funds");
                        }
                    }

                    if (withdrawAccount == "checking" || withdrawAccount == "c")
                    {
                        var totalbalance = AccountTotal(transaction, withdrawAccount);

                        Console.WriteLine($"Your current balance is: {totalbalance}");

                        var amountWithdraw = int.Parse(Prompt("How much would you like to withdraw? "));

                        if (amountWithdraw < totalbalance)
                        {
                            var newtransaction = new Transactions();
                            newtransaction.Account = withdrawAccount;
                            newtransaction.Amount = (amountWithdraw);
                            newtransaction.DepOrWith = "Withdraw";
                            newtransaction.TransactionTime = DateTime.Now;

                            transaction.Add(newtransaction);

                            var fileWriter = new StreamWriter("transactions.csv");

                            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);

                            csvWriter.WriteRecords(transaction);

                            fileWriter.Close();
                        }

                        if (amountWithdraw > totalbalance)
                        {
                            Console.WriteLine("Insufficient funds");
                        }
                    }
                }

                if (userInput == "transfer")
                {
                    var transferAccount = Prompt("Would you like to transfer from your savings or checking? ");

                    if (transferAccount == "savings")
                    {

                        var totalbalance = AccountTotal(transaction, transferAccount);

                        var transferAmount = int.Parse(Prompt($"How much would you like to transfer from {transferAccount} to your checking? "));

                        if (transferAmount < totalbalance)
                        {
                            var newtransactionto = new Transactions();
                            newtransactionto.Account = transferAccount;
                            newtransactionto.Amount = (transferAmount);
                            newtransactionto.DepOrWith = "Transferred from";
                            newtransactionto.TransactionTime = DateTime.Now;

                            transaction.Add(newtransactionto);

                            var newtransactionfrom = new Transactions();
                            newtransactionfrom.Account = "checking";
                            newtransactionfrom.Amount = (transferAmount);
                            newtransactionfrom.DepOrWith = "Transferred to";
                            newtransactionfrom.TransactionTime = DateTime.Now;

                            transaction.Add(newtransactionfrom);

                            var fileWriter = new StreamWriter("transactions.csv");

                            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);

                            csvWriter.WriteRecords(transaction);

                            fileWriter.Close();
                        }

                        if (transferAmount > totalbalance)
                        {
                            Console.WriteLine("insufficient funds to transfer");
                        }
                    }

                    if (transferAccount == "checking")
                    {

                        var totalbalance = AccountTotal(transaction, transferAccount);

                        var transferAmount = int.Parse(Prompt($"How much would you like to transfer from {transferAccount} to your checking? "));

                        if (transferAmount < totalbalance)
                        {
                            var newtransactionto = new Transactions();
                            newtransactionto.Account = transferAccount;
                            newtransactionto.Amount = (transferAmount);
                            newtransactionto.DepOrWith = "Transferred from";
                            newtransactionto.TransactionTime = DateTime.Now;

                            transaction.Add(newtransactionto);

                            var newtransactionfrom = new Transactions();
                            newtransactionfrom.Account = "savings";
                            newtransactionfrom.Amount = (transferAmount);
                            newtransactionfrom.DepOrWith = "Transferred to";
                            newtransactionfrom.TransactionTime = DateTime.Now;

                            transaction.Add(newtransactionfrom);

                            var fileWriter = new StreamWriter("transactions.csv");

                            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);

                            csvWriter.WriteRecords(transaction);

                            fileWriter.Close();
                        }

                        if (transferAmount > totalbalance)
                        {
                            Console.WriteLine("insufficient funds to transfer");
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

