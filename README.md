# FirstBankOfSuncoast

##Problem

- A program is needed to create a single list of transaction
- A past transaction should be opened when the program first starts
- User should be able to see their savings and checking
- Cant Withdraw more than avaliable (Aka no account can be negative)
- Make sure the amount to withdraw is positive and the transaction is positive
- Menu options should be
  - Deposit to Savings
  - Deposit to checkings
  - withdraw from savings
  - Withdraw from checkings
  - Option to view checkings and savings
- After each transaction write them to the file to save

C R U D

Create: Add new transaction
Read: Get lists of transactions that are in the history. Get balance of savings and checking
Update: Update information about a transaction (checking/Savings)
Delete: Remove a balance from transaction(withdraw/deposit)

##Examples

- If a customer withdraws $40, but they only have $20 the program should not withdraw and say "Insufficient funds"
- Customer should not be able to deposit -$50 into any account.
- Customer should be able to deposit $20 into checkings or savings account
- If a customer asks to make a withdraw from savings then the savings account should be displayed to withdraw from.
- If a customer asks for their transaction history then their whole list of transactions should print out.
- When a customer asks for their balance they should be returned with their total balance.

##Data

- Class transaction

  - Amount-int (The price you want)
  - Savings/Checking-string Type ()
  - Transfer--string

  - new list <transaction> csv

  - Behaviors that a property can do limited to transaction.
  - Behavior to describe the transaction

> var customerChoice= false;
> While (customerChoice==false);

- Menu Options

  - Deposit to Savings
  - Deposit to checkings
  - withdraw from savings
  - Withdraw from checkings
  - View Checking and Savings history
  - if (customerChoice=="quit"){
    customerChoice=true;
    }
  - Quit Option

  ##Algorithm

  class Transaction

  - Class transaction
    - Amount-int (The price you want)
    - Savings/Checking-string Type ()
    - Transfer--string

  1. Welcome to the bank
     var userChoice=false;

  - Read a file

  while (userChoice==false)

  2. Menu Options ("Would you like to?");

  - View
    - Savings
    - Checking
  - Balance
    - Savings
    - Checking
  - Deposit
    - Savings
    - Checking
  - Withdraw
    - Savings
    - Checking
  - Quit

  if (userChoice==View)

  - Write a question (savings or checking)
  - If question answer is savings
    - find savings
    - print Transaction history
  - If question answer is checking
    - find checking
    - print checking
    - print Transaction history

  if (userChoice==Deposit) ADD

  - Write a question (savings or checking)
    - var newAccount=Answer (savings or checkings)
  - How much do you want to add?
    - var newAmount= answer (How much)
    - var newTransfer=deposit (deposit or withdraw)

  var newtransaction= new Transaction()

  newtransaction.Account=newAccount
  newtransaction.Amount=newAmount
  newtransaction.Transfer=newTransfer

  transaction.Add(newtransaction)

  Four lines of WriteLines

  if (userChoice==withdraw) REMOVE

  - Write a question (savings or checking)
  - If question answer is savings
    - Find savings
    - Ask how much they would like to withdraw (int.Parce)
    - subtract that amount from savings
      - If that amount (savings<0)
      - Write "insufficient funds"
  - If question answer is checking
    - Find checking
    - Ask how much they would like to withdraw (int.Parce)
    - subtract that amount from checking
      - If that amount (checking<0)
      - Write "insufficient funds"
      - return money back?

  if (userChoice==quit)

  - var userChoise= true;

* Write to a file
  - Exit Bank account
