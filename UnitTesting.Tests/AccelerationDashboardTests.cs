using Moq;
using NUnit.Framework;

namespace UnitTesting.Tests
{
    [TestFixture]
    public class AccelerationDashboardTests
    {
        private Mock<IAccelerationSensor> m_AccelerationSensorMock;
        private AccelerationDashboard m_AccelerationDashboard;

        [SetUp]
        public void SetUp()
        {
            m_AccelerationSensorMock = new Mock<IAccelerationSensor>();
            m_AccelerationDashboard = new AccelerationDashboard(m_AccelerationSensorMock.Object);
        }

        [TearDown]
        public void TearDown()
        {
            m_AccelerationDashboard = null;
            m_AccelerationSensorMock = null;
        }

        [Test]
        public void EventBindingTest()
        {
            // Act
            m_AccelerationSensorMock.Raise(m => m.AccelerationChanged += null, this, 10.0);

            // Assert
            Assert.AreEqual(10.0, m_AccelerationDashboard.Acceleration);
        }
    }
}