# ProjectAssingment-Team-Strawberry
End project assignment for the C# OOP course By Daniel Svensson, Elias Hammou, Jesper Andersson
UML image is located in folder "non-program-files"

This is our take on the Banking interface/application for the final project of the "Objektorienterad programmering med C# och .NET" course.

To begin with we have structured the program around being some what modular in regards to the menus of the diffrent sections.

Classes;

Menus : that holds the startmenu and all the other menu's for the diffrent parts,Also it's here that all the diffrent classes are initialized,

LoginServices : has everything that encapsulates "user login"

UserHandling : Creation and handling of user specifik methods, like checking if a username is already taken, 
support for users (if they are locked out or need a new password)

BankAccounts Inherits UserHandling : handles all that is Bankaccounts, creation/moneytransfers/Deposits/Balances

Loans Inherits BankAccounts : handles the loaning of money to the accounts and all that entails

Objects;
Program.cs
Menus menu; - initilazation of the StartMenu and all it entails, gives access to all other parts of the program

Menus.cs
LoginServices login; - handles the recurring login calls, as you can switch users mid program.
Userhandling currentUser; - swaps user depending on what info is entered into the loginservice (method handle switches between user and currentUser)
Userhandling admin; - default admin account to have access to "everything"
Userhandling guest; - default non-admin accunt that is more restricted to itself
BankAccounts accounts; - gives access to the methods in BankAccounts, the actual BankAccounts are a List in UserHandling, 
List<Userhandling> Users; - in liue of a database Keeps track of all the users that are "currently relevant" 
Loans loan;

UserHandling.cs
List<BankAccounts> MyAccounts; - in liue of a database Keeps track of all the Accounts that are "currently relevant" for "this" user

BankAccounts.cs
List<string> transactionLog; - in liue of a database Keeps track of all the Transactions that are "currently relevant" for "this" Account

Methods:
-------------------------
-Menus.cs
-------------------------
  public void createadmin() 
  - creates a instance of the standard admin user, along with 2 bankaccounts, (was primarily used for testing)
  
  public Menus() 
  - constructor that initializes the diffrent objects needed in the program at this point
  
  public void StartMenu() 
  - holds the first login and access to all the sub-menus for the diffrent parts of the program
  
  public void UserManagement(List<Userhandling> Users, Userhandling user) 
  - Menu for accessing diffrent aspects of Userhandling creating a user, supporting a user or logging in as a diffrent user.
  
  public void accountMenu(List<Userhandling> users, Userhandling user) 
  - Menu for interacting with the diffrent options for the Accounts show balance,
  deposit to accounts, loans, create account, transfer between accounts and internal for user between accounts.

  public void userLoanMenu(Userhandling user) 
  - handles loaning, interestrates for loans.
  
  public void UserSupportMenu(List<Userhandling> users) 
  - handles the menu for supporting users, Lockouts and password resets
-------------------------
-LoginServices.cs
-------------------------
  public Userhandling LoginUser(List<Userhandling> users) - takes in the list of users to check if usernames and passwords are correct,
  then returns that user as the "currentUser"
  
-------------------------
-UserHandling.cs
-------------------------
  public void CreateUser(List<Userhandling> Users, Userhandling currentUser) 
  -Admin only method-  Creates user and then stores that information in the List of Users.
  
  public bool CheckUserName(List<Userhandling> userList, string username) 
  - checks to see if a username is already taken or not (also checks if username is correct for login)
  
  public void CorrectInput(List<string> savedinfo, string tempString,string placeholder)
  - a method that checks if the entered information is correct, (used in creation of new Users)
  public void CorrectInput(List<int> savedinfo, int tempInt, string placeholder)
  -Overloaded for Integers, same base function as the other one
  
  public void RemoveLockout(List<Userhandling> users, string tempUser)
  - Admin only method - removes the lockout from a user that has entered the wrong password to meny times.
  
  public void ChangePassword(List<Userhandling> users, string tempUser)
  - method for changing the password of a user
-------------------------
-BankAccounts.cs
-------------------------
  -public void createBankAccounts(List<Userhandling> Users) 
  -Admin method- for creation of Bankaccounts that are connected to a certain user (input from admin)
  
  -public void createBankAccounts(Userhandling currentUser) - overloaded - 
  -regular method for user to make a new account at the bank
  
  public void transferMoney(Userhandling user1, Userhandling user2)
  -Transfer money between 2 account holders bankaccounts. IE User A sends money to User B.
  
  public void transferMoney(Userhandling currentUser)
  -Transfer money between you own accounts, IE from salary account to savings.
  
  public void currencyConverter(string currency, string currency2, double exchangeRate)
  - meant to convert currency at a fixed rate for the day - not implemented
  
  public void ShowlogTransaction(List<BankAccounts> accounts)
  -meant to show the transaction logs on selected account - not implemented
  
  public void ShowMyAccountsBalance(Userhandling currentUser)
  - shows the balance of all accounts the user has.
  
  public void DepositCurrency(Userhandling user)
  - deposits money into a selected account, IE: i got my salary and i deposited it to Account ABC123

-------------------------
Loans.cs
-------------------------
  public double customerInterestAmount(double amount)
  - checks the interest amount for this loan
  
  public bool issueLoan(Userhandling currentUser, double amount)
  - meant to issue a loan with interest rates to the users account - not fully implemented, missing currencys
