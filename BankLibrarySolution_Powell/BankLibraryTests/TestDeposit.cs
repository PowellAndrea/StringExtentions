/*
 * Deposit(double) : double
 */

using BankLibrary;


namespace BankLibraryTests
{
    [TestClass]
    public class TestDeposit
    {
        [TestMethod]
        public void Sucess()
        {
            Bank myBank = new Bank(TestConstants.CUSTOMER, 500);
            Assert.IsTrue(myBank.Deposit(200) == 700);
        }

        [TestMethod]
        public void ZeroDeposit()
        {
            Bank myBank = new Bank(TestConstants.CUSTOMER, 500);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
            { myBank.Deposit(0); });
        }

    }
}