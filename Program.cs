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
                    Console.WriteLine($"Failed Deposit of {amount} to {acc}");
            }
        }

        public static void Withdraw(List<Account> accounts, double amount)
        {
            Console.WriteLine("\n=== Withdrawing from Accounts ==============================");
            foreach (var acc in accounts)
            {
                if (acc.Withdraw(amount))
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }

        // Helper functions for SavingsAccount
        public static void DepositSavings(List<SavingsAccount> accounts, double amount)
        {
            Console.WriteLine("\n=== Depositing to Savings Accounts =================================");
            foreach (var acc in accounts)
            {
                if (acc.Deposit(amount))
                    Console.WriteLine($"Deposited {amount} to {acc}");
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
                    Console.WriteLine($"Withdrew {amount} from {acc}");
                else
                    Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
            }
        }

        //// Helper functions for CheckingAccount
        //public static void DepositChecking(List<CheckingAccount> accounts, double amount)
        //{
        //    Console.WriteLine("\n=== Depositing to Checking Accounts =================================");
        //    foreach (var acc in accounts)
        //    {
        //        if (acc.Deposit(amount))
        //            Console.WriteLine($"Deposited {amount} to {acc}");
        //        else
        //            Console.WriteLine($"Failed Deposit of {amount} to {acc}");
        //    }
        //}

        //public static void WithdrawChecking(List<CheckingAccount> accounts, double amount)
        //{
        //    Console.WriteLine("\n=== Withdrawing from Checking Accounts ==============================");
        //    foreach (var acc in accounts)
        //    {
        //        if (acc.Withdraw(amount))
        //            Console.WriteLine($"Withdrew {amount} from {acc}");
        //        else
        //            Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
        //    }
        //}

        //// Helper functions for TrustAccount
        //public static void DepositTrust(List<TrustAccount> accounts, double amount)
        //{
        //    Console.WriteLine("\n=== Depositing to Trust Accounts =================================");
        //    foreach (var acc in accounts)
        //    {
        //        if (acc.Deposit(amount))
        //            Console.WriteLine($"Deposited {amount} to {acc}");
        //        else
        //            Console.WriteLine($"Failed Deposit of {amount} to {acc}");
        //    }
        //}

        //public static void WithdrawTrust(List<TrustAccount> accounts, double amount)
        //{
        //    Console.WriteLine("\n=== Withdrawing from Trust Accounts ==============================");
        //    foreach (var acc in accounts)
        //    {
        //        if (acc.Withdraw(amount))
        //            Console.WriteLine($"Withdrew {amount} from {acc}");
        //        else
        //            Console.WriteLine($"Failed Withdrawal of {amount} from {acc}");
        //    }
        //}
    }
    public class Account
    {
        public string Name {  get; set; }
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
    }
   public class SavingsAccount : Account
    {
        public SavingsAccount(string name = "Unnamed Account" , double balance = 0.0 , double rate = 0.2) : base(name , balance)
        {
            this.Rate = rate;
        }

        public double Rate { get; set; }


        public new bool Deposit(double amount)
        {
            if (amount <= 0)
            {
                return false;

            }
            //Balance = Balance + (amount * Balance);
            Console.WriteLine(amount * Balance);
            return true;

        }


    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //// Accounts
            //List<Account> accounts = new List<Account>();

            //accounts.Add(new Account());
            //accounts.Add(new Account("Larry"));
            //accounts.Add(new Account("Moe", 2000));
            //accounts.Add(new Account("Curly", 5000));

            //AccountUtil.Deposit(accounts, 1000);
            //AccountUtil.Withdraw(accounts, 2000);


            List<SavingsAccount> savAccounts = new List<SavingsAccount>();

            savAccounts.Add(new SavingsAccount());
            savAccounts.Add(new SavingsAccount("Superman"));
            savAccounts.Add(new SavingsAccount("Batman", 2000));
            savAccounts.Add(new SavingsAccount("Wonderwoman", 5000, 5.0));

            AccountUtil.DepositSavings(savAccounts, 1000);
            //AccountUtil.WithdrawSavings(savAccounts, 2000);

        }
    }
}
