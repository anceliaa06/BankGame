using System;
using System.Text; // for utf8 encoding  to get ₹ symbol

namespace BankGameApp
{
    class BankAccount
    {
        public string AccountHolder;
        public double Balance;

        // constructor
        public BankAccount(string name, double initialBalance)
        {
            AccountHolder = name;
            Balance = initialBalance;
        }

        // withdraw method
        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine($"{AccountHolder}: invalid withdrawal amount.");
                return;
            }

            if (amount > Balance)
            {
                Console.WriteLine($"{AccountHolder}: insufficient balance.");
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"{AccountHolder} withdrew ₹{amount}. balance: ₹{Balance}");
            }
        }

        // deposit method
        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine($"{AccountHolder}: invalid deposit amount.");
                return;
            }

            Balance += amount;
            Console.WriteLine($"{AccountHolder} deposited ₹{amount}. balance: ₹{Balance}");
        }
    }

    class Program
    {
        static void Main()
        {
            //  display ₹ symbol 
            Console.OutputEncoding = Encoding.UTF8;

            // 
            Random rand = new Random();
            BankAccount acc1 = new BankAccount("account1", rand.Next(4000, 70000));
            BankAccount acc2 = new BankAccount("account2", rand.Next(4000, 70000));

            // display starting balances
            Console.WriteLine($"starting balances:");
            Console.WriteLine($"{acc1.AccountHolder}: ₹{acc1.Balance}");
            Console.WriteLine($"{acc2.AccountHolder}: ₹{acc2.Balance}");

            
            for (int round = 1; round <= 3; round++)
            {
                Console.WriteLine($"\n round {round} ");

                Console.Write($"{acc1.AccountHolder} withdraw or deposit (w/d): ");
                string choice1 = Console.ReadLine().Trim().ToLower();

                Console.Write("enter amount: ");
                bool validAmount1 = double.TryParse(Console.ReadLine(), out double amount1);
                if (!validAmount1)
                {
                    Console.WriteLine("invalid amount input.");
                }
                else if (choice1 == "w")
                    acc1.Withdraw(amount1);
                else if (choice1 == "d")
                    acc1.Deposit(amount1);
                else
                    Console.WriteLine("invalid input.");

                Console.Write($"{acc2.AccountHolder} withdraw or deposit (w/d): ");
                string choice2 = Console.ReadLine().Trim().ToLower();

                Console.Write("enter amount: ");
                bool validAmount2 = double.TryParse(Console.ReadLine(), out double amount2);
                if (!validAmount2)
                {
                    Console.WriteLine("invalid amount input.");
                }
                else if (choice2 == "w")
                    acc2.Withdraw(amount2);
                else if (choice2 == "d")
                    acc2.Deposit(amount2);
                else
                    Console.WriteLine("invalid input.");
            }

            // final balances and winner announcement
            Console.WriteLine($"\nfinal balances:");
            Console.WriteLine($"{acc1.AccountHolder}: ₹{acc1.Balance}");
            Console.WriteLine($"{acc2.AccountHolder}: ₹{acc2.Balance}");

            if (acc1.Balance > acc2.Balance)
                Console.WriteLine($"\n winner: {acc1.AccountHolder}");
            else if (acc2.Balance > acc1.Balance)
                Console.WriteLine($"\n winner: {acc2.AccountHolder}");
            else
                Console.WriteLine("\nit's a tie!");
        }
    }
}
