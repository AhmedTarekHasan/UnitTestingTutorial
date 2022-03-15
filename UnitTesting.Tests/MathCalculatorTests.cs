using NUnit.Framework;

namespace UnitTesting.Tests
{
    [TestFixture]
    public class MathCalculatorTests
    {
        private MathCalculator m_Calculator;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
        }

        [SetUp]
        public void SetUp()
        {
            m_Calculator = new MathCalculator();
        }

        [TearDown]
        public void TearDown()
        {
            m_Calculator = null;
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
        }

        [Test]
        public void AddTest1()
        {
            // Arrange
            var inputA = 1;
            var inputB = 1;
            var expected = 2;

            // Act
            var actual = m_Calculator.Add(inputA, inputB);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1, 2, TestName = "Adding 1 and 1 should return 2")]
        [TestCase(-1, 2, 1, TestName = "Adding -1 and 2 should return 1")]
        [TestCase(1, -2, -1, TestName = "Adding 1 and -2 should return -1")]
        [TestCase(-1, -2, -3, TestName = "Adding -1 and -2 should return -3")]
        public void AddTest2(int inputA, int inputB, int expected)
        {
            // Act
            var actual = m_Calculator.Add(inputA, inputB);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 1, ExpectedResult = 2, TestName = "Adding 1 and 1 should return 2")]
        [TestCase(-1, 2, ExpectedResult = 1, TestName = "Adding -1 and 2 should return 1")]
        [TestCase(1, -2, ExpectedResult = -1, TestName = "Adding 1 and -2 should return -1")]
        [TestCase(-1, -2, ExpectedResult = -3, TestName = "Adding -1 and -2 should return -3")]
        public int AddTest3(int inputA, int inputB)
        {
            return m_Calculator.Add(inputA, inputB);
        }

        [TestCaseSource(nameof(AdditionTestCases))]
        public void AddTest4(int inputA, int inputB, int expected)
        {
            // Act
            var actual = m_Calculator.Add(inputA, inputB);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        private static object[] AdditionTestCases =
        {
            new object[] { 1, 1, 2 },
            new object[] { -1, 2, 1 },
            new object[] { 1, -2, -1 },
            new object[] { -1, -2, -3 }
        };
    }
}