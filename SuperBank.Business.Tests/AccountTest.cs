using Moq;
namespace SuperBank.Business.Tests
{

    //class MockNotificationService : INotificationService
    //{
    //    public void Notify(string message)
    //    {
    //        // Mock implementation of the Notify method for testing purposes
    //    }
    //}





    [TestClass]
    public sealed class AccountTest
    {
        private Account target = null;
        private Mock<INotificationService> mockNotificationService = null;

        [TestInitialize]
        public void TestInitialize()
        {
            mockNotificationService = new Mock<INotificationService>();
            mockNotificationService.Setup(service => service.Notify(""));


            target = new Account(mockNotificationService.Object);
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

        // Mock Frameworks
        // 1. Moq
        // 2. NSubstitute
        // 3. FakeItEasy
        // 4. Rhino Mocks
        // 5. JustMock
        // 6. Typemock Isolator
        // 7. Microsoft Fakes
        // 8. AutoFixture



        [TestMethod]
        public void DepositTest_WithValidInput_ShouldCallSendNotify()
        {
            double amount = 500.00;
            target.Deposit(amount);
            string input = $"Deposit of {amount} was successful. Your new balance is {target.Balance}";
           mockNotificationService.Verify(service => service.Notify(input), Times.Once);
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

        [TestMethod]
        public void WithdrawTest_WithValidInput_ShouldReturnTrue()
        {
            bool actual = target.Withdraw(500.00, 1234);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void WithdrawTest_WithValidInput_ShouldUpdateBalance()
        {
            target.Withdraw(500.00, 1234);
            Assert.AreEqual(500.00, target.Balance);
        }

        [TestMethod]
        public void WithdrawTest_WithInactiveAccount_ShouldThrowException()
        {
            target.IsActive = false;
            Assert.Throws<InactiveAccountException>(() => target.Withdraw(500.00, 1234));
        }
        [TestMethod]
        [DataRow(0)]
        [DataRow(-100)]
        [DataRow(1500)]
        public void WithdrawTest_WithInvalidAmount_ShouldThrowException(double amount)
        {
            Assert.Throws<InvalidAmountException>(() => target.Withdraw(amount, 1234));
            //Assert.Throws<InvalidAmountException>(() => target.Withdraw(-100, 1234));
            //Assert.Throws<InvalidAmountException>(() => target.Withdraw(1500.00, 1234));
        }

        [TestMethod]
        public void WithdrawTest_WithIncorrectPin_ShouldThrowException()
        {
            Assert.Throws<InvalidPinException>(() => target.Withdraw(500.00, 9999));
        }

        [TestMethod]
        public void TransferTest_WithValidInput_ShouldReturnTrue()
        {
            Account target2 = new Account(mockNotificationService.Object);
            target2.AccountNo = "0987654321";
            target2.Balance = 500.00;
            target2.Pin = 4321;
            target2.IsActive = true;
            bool actual = target.Transfer(target2, 200.00, 1234);
            Assert.IsTrue(actual);
        }

    }
}
