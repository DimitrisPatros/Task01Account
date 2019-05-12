using System;

namespace classProgramm
{
    class Program
    {
        static void Main(string[] args)
        {
            bool doContinue;
           
            do
            {
                doSmthg();
                Console.WriteLine("Do you want to do another job (y/n)");
                char response = char.Parse(Console.ReadLine());
                if (response == 'y')
                {
                    doContinue = true;
                }
                else
                {
                    doContinue = false;
                    Console.WriteLine("Goodbye");
                }

            } while (doContinue);           
        }

        static void doSmthg()
        {
            double amound;
            Account customer = new Account("Dimitris", 400, 1);
            

            Console.WriteLine("press 'w' for withdraw  or 'd' for deposite");
            char action;
            action = char.Parse(Console.ReadLine());
            if (action == 'w')
            {                
                Console.WriteLine("type the amount");
                amound = double.Parse(Console.ReadLine());
                bool success = customer.withdraw(amound);
                if (success) Console.WriteLine("Withdrawal successfull :)");
                else Console.WriteLine("Withdrawal unsuccessfull :(");               
            }
            else if (action == 'd')
            {                
                Console.WriteLine("Type the amount");
                amound = double.Parse(Console.ReadLine());
                bool success = customer.deposit(amound);
                if (success) Console.WriteLine("Deposite successfull :)");
                else Console.WriteLine("Deposite unsuccessfull :(");
            }
            else
            {
                Console.WriteLine("Wrong answer");
            }            
            Console.WriteLine(customer.ToString());
        }

    }//End of Class Program

    class Account
    {
        //fields
        const double _depositeLimit = 5000;
        string _owner;
        double _balance;
        int _numberOfTransaction;                     

        //method for withdraw
        public bool withdraw(double amound)
        {
            _numberOfTransaction++;
            if (_balance < amound) return false;
            _balance -= amound;
            return true;

        }

        //method for deposit
        public bool deposit(double amound)
        {
            _numberOfTransaction++;
            if (amound > _depositeLimit) return false;
            _balance += amound;
            return true;

        }
        //empty constructor
        public Account()
        {
        }

        //main constructor
        public Account(string owner, double balance, int numberOfTransaction)
        {
            _owner = owner;
            _balance = balance;
            _numberOfTransaction = numberOfTransaction;
        }

        //ToString 
        public override string ToString()
        {
            return "Owner:                 " + _owner +
                   "\nBalance:               " + _balance +
                   "\nNumber of Transaction: " + _numberOfTransaction;
        }

    }//End of Class Account 
}

