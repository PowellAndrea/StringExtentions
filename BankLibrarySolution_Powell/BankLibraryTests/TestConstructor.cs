/*
 * CC > 1
 * Bank(string,double)
 * Withdraw(double) : double
 * Deposit(double) : double
 * 
 */

using BankLibrary;

namespace BankLibraryTests
{
    [TestClass]
    public class TestConstructor
    {

        [TestMethod]
        public void EmptyCustomer()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            { new Bank("", 10.00); });
        }

        [TestMethod]
        public void BalanceNegative()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => 
            { new Bank(TestConstants.CUSTOMER, -10.00);});
        }

        [TestMethod]
        public void BalanceTooBig()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => 
                { new Bank(TestConstants.CUSTOMER, 400000.00); });
        }

        [TestMethod]
        public void Balance0()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            { new Bank(TestConstants.CUSTOMER, 0.00); });
        }

        [TestMethod]
        public void BalanceGood()
        {
            Bank test = new Bank(TestConstants.CUSTOMER, 500.00);
            Assert.AreEqual(500.00, test.Balance);
            Assert.AreEqual(TestConstants.CUSTOMER, test.Customer);
        }


    }
}