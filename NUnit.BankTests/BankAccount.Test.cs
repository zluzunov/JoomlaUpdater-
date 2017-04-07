namespace NUnit.BankTests
{
    using Framework;
    using System;
    using BankApp;

    [TestFixture]
    public class BankAccountTests
    {
        [Test]
        public void BankAccountDoesNotAllowNegativeInit()
        {
            Assert.Throws<ArgumentException>(() => new BankAccount(-320m));
        }

        [Test]
        public void BankAccountWidrawThousandLess()
        {
            BankAccount withrawAccount = new BankAccount(10000);
            withrawAccount.Withdraw(100);
            Assert.AreEqual(10000m-102m,withrawAccount.Amount);
        }

        [Test]
        public void BankAccountWidrawThousandMore()
        {
            BankAccount withrawAccount = new BankAccount(10000);
            withrawAccount.Withdraw(2000);
            Assert.AreEqual(10000m - 2100m, withrawAccount.Amount);
        }

        // Test 1
        [Test]
        [Author("Jane Doe", "jane.doe@example.com")]
        public void BankAccountNegativeDeposit()
        {
            BankAccount withrawAccount = new BankAccount(10000);
            Assert.Throws<ArgumentException>(() => withrawAccount.Deposit(-100));
        }

        // Test 2
        [Test]
        [Author("Jane Doe", "jane.doe@example.com")]
        public void BankAccountDepositWorks()
        {
            BankAccount account = new BankAccount(10000);
            Assert.DoesNotThrow(() => account.Deposit(100));
            Assert.AreEqual(10100,account.Amount);
        }

        // Test 3
        [Test]
        [Author("Jane Doe", "jane.doe@example.com")]
        public void BankAccountDepositAssert()
        {
            BankAccount account = new BankAccount(10000);
            Assert.DoesNotThrow(() => account.Deposit(100));
            Assert.AreEqual(10100, account.Amount);
        }

        // Test 4
        [Test]
        [Author("Jane Doe", "jane.doe@example.com")]
        public void BankAccountAmountNull()
        {
            BankAccount account = new BankAccount(10000);
            Assert.NotNull(account.Amount);
        }

        // Test 5
        [Test]
        [Author("Jane Doe", "jane.doe@example.com")]
        public void BankAccountTest4()
        {
            BankAccount account = new BankAccount(10000);
            Assert.IsInstanceOf<Decimal>(account.Amount);
        }
    }
}
