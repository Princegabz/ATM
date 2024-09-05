namespace ATM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ATMS a = new ATMS();
            a.Withdraw();
            a.Deposit();
            a.CheckBalance();
            a.CheckBalance();

            Console.ReadLine();
        }

        interface iATM
        {
            void Withdraw(ATMS a);
            void Deposit(ATMS a);
            void CheckBalance(ATMS a);
        }

        class ATMS
        {
            private iATM ia { get; set; }

            public ATMS()
            {
                ia = new CheckBalanceState(); // Default state
            }

            public void ChangeState(iATM newState)
            {
                ia = newState;
            }

            public void Withdraw()
            {
                ia.Withdraw(this);
            }

            public void CheckBalance()
            {
                ia.CheckBalance(this);
            }

            public void Deposit()
            {
                ia.Deposit(this);
            }
        }

        class CheckBalanceState : iATM
        {
            public void CheckBalance(ATMS a)
            {
                Console.WriteLine("You HAVE ALREADY Checked Balance");
            }

            public void Deposit(ATMS a)
            {
                Console.WriteLine("You are Depositing");
                a.ChangeState(new DepositState()); // Change to Deposit State
            }

            public void Withdraw(ATMS a)
            {
                Console.WriteLine("You are Withdrawing");
                a.ChangeState(new WithdrawState()); // Change to Withdraw State
            }
        }

        class DepositState : iATM
        {
            public void CheckBalance(ATMS a)
            {
                Console.WriteLine("You are Checking Balance");
                a.ChangeState(new CheckBalanceState()); // Change to Check Balance State
            }

            public void Deposit(ATMS a)
            {
                Console.WriteLine("You HAVE ALREADY Deposited");
            }

            public void Withdraw(ATMS a)
            {
                Console.WriteLine("You are Withdrawing");
                a.ChangeState(new WithdrawState()); // Change to Withdraw State
            }
        }

        class WithdrawState : iATM
        {
            public void CheckBalance(ATMS a)
            {
                Console.WriteLine("You are Checking Balance");
                a.ChangeState(new CheckBalanceState()); // Change to Check Balance State
            }

            public void Deposit(ATMS a)
            {
                Console.WriteLine("You are Depositing");
                a.ChangeState(new DepositState()); // Change to Deposit State
            }

            public void Withdraw(ATMS a)
            {
                Console.WriteLine("You HAVE ALREADY Withdrawn");
            }
        }
    }
}
