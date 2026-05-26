namespace SuperBank.Business.Tests
{
    [TestClass]
    public sealed class AccountTest
    {
        private Account target = null;

        [TestInitialize]
        public void TestInitialize()
        {
            target = new Account();
            target.AccountNo = "1234567890";
            target.Balance = 1000.00;
            target.Pin = 1234;
            target.IsActive = true;
        }
        [TestCleanup]
        public void Cleanup() 
        {
            target = null;
        }

        [TestMethod]
        public void DepositTest_WithValidInput_ShouldReturnTrue()
        {
            bool actual = target.Deposit(500.00);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void DepositTest_WithValidInput_ShouldUpdateBalance()
        {
            target.Deposit(500.00);
            Assert.AreEqual(1500.00, target.Balance);
        }

        [TestMethod]
        public void DepositTest_WithInactiveAccount_ShouldThrowException()
        {
            target.IsActive = false;
            Assert.Throws<InactiveAccountException>(() => target.Deposit(500.00));
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-100)]
        public void DepositTest_WithInvalidAmount_ShouldThrowException(double amount)
        {
            Assert.Throws<InvalidAmountException>(() => target.Deposit(amount));
        }

    }
}
