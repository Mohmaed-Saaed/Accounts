using System.Xml.Linq;

namespace Accounts
{
    public static class AccountUtil
    {
        // Utility helper functions for Account class
        public static void Deposit(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc.Name}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc.Name}");
            }
        }

        public static void Withdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc.Name}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc.Name}");
            }
        }

        // Helper functions for SavingsAccount
        public static void DepositSavings(List<SavingsAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Savings Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc.Name}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }

        public static void WithdrawSavings(List<SavingsAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Savings Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc.Name}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc.Name}");
            }
        }

        // Helper functions for CheckingAccount
        public static void DepositChecking(List<CheckingAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Checking Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc.Name}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc.Name}");
            }
        }

        public static void WithdrawChecking(List<CheckingAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Checking Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc.Name}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc.Name}");
            }
        }

        // Helper functions for TrustAccount
        public static void DepositTrust(List<TrustAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Trust Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc.Name}");
                else
                    Console.WriteLine($"Failed Deposit of {amount} to {acc.Name}");
            }
        }

        public static void WithdrawTrust(List<TrustAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Trust Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc.Name}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc.Name}");
            }
        }
    }
    public class Account
    {
        public string Name { get; set; }
        public double Balance { get; set; }

        public Account(string name = "Unnamed Account", double balance = 0.0)
        {
            Name = name;
            Balance = balance;
        }

        public bool Deposit(double amount)
        {
            if (amount <= 0)
            {
                return false;

            }

            Balance += amount;
            return true;

        }

        public bool Withdraw(double amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
        public static double operator+(Account lhs, Account rhs)
        {
            return lhs.Balance + rhs.Balance;
        }
    }

    public class SavingsAccount : Account
    {
        public SavingsAccount(string name = "Unnamed Account", double balance = 0.0, double rate = 0.2) : base(name, balance)
        {
            this.Rate = rate;
        }

        public double Rate { get; private set; }

        public new bool Withdraw(double amount) {
            return base.Withdraw(amount + (amount * Rate));
        }


    }

    public class TrustAccount : SavingsAccount
    {   
        public int CurrentYear { get; private set; }

        public int MaxTryForYear = 3;

        public const int Bonus = 50;

        public const double MaxWithdrawAmount = 0.2;

        private int withdrawalsThisYear;

        public TrustAccount(string name = "Unnamed Account", double balance = 0.0, double rate = 0.2) : base(name , balance , rate)
        {
            CurrentYear = DateTime.Now.Year;
            withdrawalsThisYear = 0;
        }
        
        public new  bool Deposit(double amount)
        {
            if(amount >= 5000)
                return base.Deposit(amount + Bonus);

          return base.Deposit(amount);
        }


        public new bool Withdraw(double amount )
        {
            if (amount > (base.Balance * MaxWithdrawAmount))
                return false;


            int transactionYear = DateTime.Now.Year;

            if(transactionYear > CurrentYear)
            {
                CurrentYear = transactionYear;
                withdrawalsThisYear = 0;              
            }

            if(MaxTryForYear > withdrawalsThisYear)
            {

              if (base.Withdraw(amount))
                {
                withdrawalsThisYear++;
                return true;
                }
            }
            return false;
        }
    }

    public class CheckingAccount : Account
    {

        private const double Fee = 1.50;

        public CheckingAccount(string name = "Unnamed Account", double balance = 0.0) : base(name, balance)
        {

        }

        public new bool Withdraw(double amount)
        {
            return base.Withdraw(amount + Fee);
        }

    }

    internal class Program
    {
        static void Main()
        {
            // Accounts
            var accounts = new List<Account>();
            accounts.Add(new Account());
            accounts.Add(new Account("Larry"));
            accounts.Add(new Account("Moe", 2000));
            accounts.Add(new Account("Curly", 5000));

            AccountUtil.Deposit(accounts, 1000);
            AccountUtil.Withdraw(accounts, 2000);

            // Savings
            var savAccounts = new List<SavingsAccount>();
            savAccounts.Add(new SavingsAccount());
            savAccounts.Add(new SavingsAccount("Superman"));
            savAccounts.Add(new SavingsAccount("Batman", 2000));
            savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 5.0));

            AccountUtil.DepositSavings(savAccounts, 1000);
            AccountUtil.WithdrawSavings(savAccounts, 2000);

            // Checking
            var checAccounts = new List<CheckingAccount>();
            checAccounts.Add(new CheckingAccount());
            checAccounts.Add(new CheckingAccount("Larry2"));
            checAccounts.Add(new CheckingAccount("Moe2", 2000));
            checAccounts.Add(new CheckingAccount("Curly2", 5000));

            AccountUtil.DepositChecking(checAccounts, 1000);
            AccountUtil.WithdrawChecking(checAccounts, 2000);
            AccountUtil.WithdrawChecking(checAccounts, 2000);

            // Trust
            var trustAccounts = new List<TrustAccount>();
            trustAccounts.Add(new TrustAccount());
            trustAccounts.Add(new TrustAccount("Superman2"));
            trustAccounts.Add(new TrustAccount("Batman2", 2000));
            trustAccounts.Add(new TrustAccount("Wonderwoman2", 5000, 5.0));

            AccountUtil.DepositTrust(trustAccounts, 1000);
            AccountUtil.DepositTrust(trustAccounts, 6000);
            AccountUtil.WithdrawTrust(trustAccounts, 2000);
            AccountUtil.WithdrawTrust(trustAccounts, 3000);
            AccountUtil.WithdrawTrust(trustAccounts, 500);

            Console.WriteLine();
        }
    }
}
