# FirstBankOfSuncoast

##Problem

- A program is needed to create a single list of transaction
- A past transaction should be opened when the program first starts
- User should be able to see their savings and checking
- Cant Withdraw more than avaliable (Aka no account can be negative)
- Make sure the amount to withdraw is positive and the transaction is positive
- Menu options should be
  -- Deposit to Savings
  --Deposit to checkings
  --withdraw from savings
  --Withdraw from checkings
  --Option to view checkings and savings
- After each transaction write them to the file to save

##Examples

- If a customer withdraws $40, but they only have $20 the program should not withdraw and say "Insufficient funds"
- Customer should not be able to deposit -$50 into any account.
- Customer should be able to deposit $20 into checkings or savings account
- If a customer asks to make a withdraw from savings then the savings account should be displayed to withdraw from

##Data

- Class BankAccount
  --Name-String
  --Savings-int
  --Checkings-int

> var customerChoice= false;
> While (customerChoice==false);

- Menu Options
  -- Deposit to Savings
  --Deposit to checkings
  --withdraw from savings
  --Withdraw from checkings
  --View Checkings and Savings
  --if (customerChoice=="quit"){
  customerChoise=true;
  }
  --Quit Option

  Algorithm

  1. Welcome to the bank
     var userChoice=false;

  - Read a file

  while (userChoice==false)

  2. Menu Options ("Would you like to?");
     -View
     --Savings
     --Checking
     -Deposit
     --Savings
     --Checking
     -Withdraw
     --Savings
     --Checking
     -Quit

  if (userChoice==View)
  -Write a question (savings or checking)
  -If question answer is savings
  --find savings
  --print savings
  -If question answer is checking
  --find checking
  --print checking

  if (userChoice==Deposit)
  -Write a question (savings or checking)
  -If question answer is savings
  --Find savings
  --Ask how much they would like to deposit (int.Parce)
  --Add that amount from savings
  -If question answer is checking
  --Find checking
  --Ask how much they would like to deposit (int.Parce)
  --Add that amount from checking

  if (userChoice==withdraw)
  -Write a question (savings or checking)
  -If question answer is savings
  --Find savings
  --Ask how much they would like to withdraw (int.Parce)
  --subtract that amount from savings
  ---If that amount (savings<0)
  ---Write "insufficient funds"
  ---return money back?
  -If question answer is checking
  --Find checking
  --Ask how much they would like to withdraw (int.Parce)
  --subtract that amount from checking
  ---If that amount (checking<0)
  ---Write "insufficient funds"
  ---return money back?

  if (userChoice==quit)
  -var userChoise= true;

* Write to a file
  -Exit Bank account
