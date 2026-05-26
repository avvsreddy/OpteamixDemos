namespace SuperCalculator.Business.Tests
{
    [TestClass]
    public sealed class CalculatorTest
    {

        private Calculator target = null;

        [TestInitialize] // Executes automatically before each test case method
        public void Initialize() 
        {
            target = new Calculator();
        }

        [TestCleanup]
        public void Cleanup() // Executes automatically after each test case
        {
            target = null;
        }

        [TestMethod]
        [DataRow(10, 20, 30)] // Data Driven Testing : Multiple Test Cases for the same test method
        [DataRow(2, 2, 4)]
        [DataRow(10, 10, 20)]
        public void SumTest_WithValidInput_ShouldGiveValidResult(int fno, int sno, int expected) // Test Case : +ve and -ve test cases for Add method
        {

            // DO NOT
            // NO Conditional Statements in Unit Tests
            // NO Loops in Unit Tests
            // No Try...Catch in Unit Tests

            // Use only simple code in Unit Tests

            // AAA - Arrange, Act, Assert
            // Arrange : Prepare the data and objects for testing
            //Calculator target = new Calculator();
            //int fno = 10;
            //int sno = 20;
            //int expected = 30;


            // Act : Call the method under test with the arranged data
            int actual = target.Add(fno, sno);

            // Assert : Verify that the result is as expected
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        [DataRow(-1, -1)]
        [DataRow(-1, 2)]
        [DataRow(1, -1)]
        //[ExpectedException(typeof(NegativeInputException))] // Expected Exception Testing : To verify that the method throws the expected exception for invalid input
        public void SumTest_WithNegativeInput_ShouldThrowNegativeInputException(int fno, int sno)
        {
            // Arrange
            //Calculator target = new Calculator();
            //int fno = -10;
            //int sno = 20;
            // Act and Assert
            Assert.Throws<NegativeInputException>(() => target.Add(fno, sno)); // Lambda Expression : To pass the method call as a delegate to the Assert.ThrowsException method

        }

        [TestMethod]
        [DataRow(0, 0)]
        [DataRow(0, 1)]
        [DataRow(1, 0)]
        public void SumTest_WithZeroInput_ShouldThrowZeroInputException(int fno, int sno)
        {
            // Arrange
            //Calculator target = new Calculator();
            //int fno = 0;
            //int sno = 20;
            // Act and Assert
            Assert.Throws<ZeroInputException>(() => target.Add(fno, sno));

        }

        [TestMethod]
        [DataRow(1, 2)]
        [DataRow(2, 1)]
        [DataRow(1, 1)]
        public void SumTest_WithOddInput_ShouldThrowOddInputException(int fno, int sno)
        {
            // Arrange
            //Calculator target = new Calculator();
            //int fno = 1;
            //int sno = 2;
            // Act and Assert
            Assert.Throws<OddInputException>(() => target.Add(fno, sno));
        }
    }
}
