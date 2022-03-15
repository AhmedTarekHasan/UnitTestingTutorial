using System;

namespace UnitTesting
{
    public delegate void AccelerationChangedEventHandler(object sender, double acceleration);

    public interface IAccelerationSensor
    {
        event AccelerationChangedEventHandler AccelerationChanged;
    }

    public class AccelerationSensor : IAccelerationSensor
    {
        public event AccelerationChangedEventHandler AccelerationChanged;

        protected virtual void OnAccelerationChanged(double acceleration)
        {
            AccelerationChanged?.Invoke(this, acceleration);
        }
    }

    public class AccelerationDashboard : IDisposable
    {
        private readonly IAccelerationSensor m_AccelerationSensor;

        public double Acceleration { get; private set; }

        public AccelerationDashboard(IAccelerationSensor accelerationSensor)
        {
            m_AccelerationSensor = accelerationSensor;
            m_AccelerationSensor.AccelerationChanged += AccelerationSensorOnAccelerationChanged;
        }

        public void Dispose()
        {
            m_AccelerationSensor.AccelerationChanged -= AccelerationSensorOnAccelerationChanged;
        }

        private void AccelerationSensorOnAccelerationChanged(object sender, double acceleration)
        {
            Acceleration = acceleration;
        }
    }
}