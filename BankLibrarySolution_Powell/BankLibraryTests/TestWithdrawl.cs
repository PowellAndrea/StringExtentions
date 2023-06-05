/*
 * CC > 1
 * Bank(string,double)
 * Withdraw(double) : double
 * Deposit(double) : double
 */

using BankLibrary;

namespace BankLibraryTests
{
    [TestClass]
    public class TestWithdrawl
    {
        [TestMethod]
        public void Sucess()
        {
            Bank myBank = new Bank(TestConstants.CUSTOMER, 5000);
            myBank.Withdraw(300);
            Assert.IsTrue(myBank.Balance == 4700);
        }


        [TestMethod]
        public void WithdrawTooBig()
        {
            //(amount > 500)
            Bank myBank = new Bank(TestConstants.CUSTOMER, 5000);
            myBank.Withdraw(3000);
            Assert.IsTrue(myBank.Balance == 4500);

        }

        [TestMethod]
        public void WithdrawNegative()
        {
            // amount < 0
            Bank myBank = new Bank(TestConstants.CUSTOMER, 5000);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                { myBank.Withdraw(-30); });
        }

        [TestMethod]
        public void Withdraw0()
        {
            // amount <= 0
            Bank myBank = new Bank(TestConstants.CUSTOMER, 5000);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            { myBank.Withdraw(0); });
        }


        [TestMethod]
        public void Overdraw()
        {
            // amount > _balance
            Bank myBank = new Bank(TestConstants.CUSTOMER, 50);

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            { myBank.Withdraw(100); });
        }
    }
}