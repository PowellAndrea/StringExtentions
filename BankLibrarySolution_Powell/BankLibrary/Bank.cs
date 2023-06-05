/*
 * Updated result calculation on line 50.  Good thing that guy got fired, I think I deserve at least half of his old salary.
 * Review change on line 47 - remove when all modules have been tested
 */
using System;

namespace BankLibrary
{
    public class Bank
    {
        private readonly string _customer;
        private double _balance;

        private Bank() { }

        public Bank(string customer, double balance)
        {
            if (balance > 10000 || balance <= 0)
                throw new ArgumentOutOfRangeException("Invalid starting balance");
            if (string.IsNullOrEmpty(customer))
                throw new ArgumentOutOfRangeException("Customer Required");
            _customer = customer;
            _balance = balance;
        }

        public string Customer
        {
            get { return _customer; }
        }

        public double Balance
        {
            get { return _balance; }
        }

        public double Withdraw(double amount)
        {
            if (amount > 500)
                amount = 500;

            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Amount must be at least .01");
            }

            if (amount > _balance)
            {
                throw new ArgumentOutOfRangeException("Overdraft");
            }

            // This is not needed, condition tested above
            //if (amount < 0)
            //{
            //    throw new ArgumentOutOfRangeException("Negative amount entered");
            //}

            // Updated this line - hooray unit testing works -AP
            _balance -= amount;
            return _balance;
        }

        public double Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException("Amount must be greater than .01");
            }
            _balance += amount;
            return _balance;
        }
    }
}