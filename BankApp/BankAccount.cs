namespace BankApp
{
    using System;

    public class BankAccount
    {
        decimal _amount;

        public BankAccount(decimal initAmount)
        {
            this.Amount = initAmount;
        }

        public decimal Amount
        {
            get
            {
                return this._amount;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Amount can not be negative!");
                }
                else
                {
                    this._amount = value;
                }
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new ArgumentException("Deposit can not be negative!");
            }
            this.Amount += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 1000)
            {
                amount += (amount * 0.05m);
                this.Amount -= amount;
            }
            else
            {
                amount += (amount * 0.02m);
                this.Amount -= amount;
            }
        }
    }
}
