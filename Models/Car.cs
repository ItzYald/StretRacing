using StreetRacing;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace NewCar.Models
{
    internal class Car : Nextable
    {
        Engine engine;

        CarSpecifications specifications;

        float distance;
        float speed;

        float[] numbersOfTransmission;

        int transmissionNumber;

        bool isStarted;

        public bool IsStarted { get { return isStarted; } }

        public int MaxRpm { get { return engine.MaxRpm; } }

        const float powerK = 6666666.6f;

        public Car(CarSpecifications specifications)
        {
            distance = 0;
            speed = 0;

            this.specifications = specifications;

            engine = new Engine(this.specifications.engineSpecifications, getTransmission);

            numbersOfTransmission = new float[] {3.8f, 2.2f, 1.3f, 0.9f, 0.5f};
            transmissionNumber = 0;

            isStarted = false;
        }

        public float getPixelDistance() => (distance / 60f * 23f);
        public float getRealDistance() => (distance * 0.0046296f);
        public float getDistance() => distance;
        public int getSpeed() => (int)speed;
        public float getRpm() => engine.rpm;
        public int getTransmissionNumber() => transmissionNumber + 1;
        public float getTransmission() => numbersOfTransmission[transmissionNumber];
        public void Start()
        {
            speed = 0;
            transmissionNumber = 0;
            distance = 0;
            engine.Start();
            isStarted = true;
        }

        public void Stop()
        {
            distance = 0;
            speed = 0;
            transmissionNumber = 0;
            isStarted = false;
            engine.Stop();
        }

        public void TransmissionUp()
        {
            if (transmissionNumber + 1 < numbersOfTransmission.Count())
            {
                transmissionNumber += 1;
                engine.rpm = (int)(engine.rpm * (numbersOfTransmission[transmissionNumber] / numbersOfTransmission[transmissionNumber - 1]));
            }
        }

        public void TransmissionDown()
        {
            if (transmissionNumber > 0)
            {
                transmissionNumber -= 1;
            }
        }
        public void Accel(double delta)
        {
            engine.rpm +=
                (float)delta * (-1 * engine.rpm * engine.rpm + 2 * engine.MaxRpm * engine.rpm)
                / powerK * engine.Power * numbersOfTransmission[transmissionNumber];
        }

        public void Move(double delta)
        {
            Accel(delta);
            if (engine.rpm < 500)
            {
                engine.isStart = false;
                engine.rpm -= 10;
            }

            if (engine.isStart)
            {
                if (engine.rpm > engine.MaxRpm * 1.05f)
                {
                    engine.rpm -= (float)(300 * numbersOfTransmission[transmissionNumber] * Math.Pow(engine.rpm - engine.MaxRpm, 0.89) / (engine.MaxRpm * 1.05f - engine.MaxRpm));
                }
                engine.rpm += (0.5f * numbersOfTransmission[transmissionNumber]);
            }

            engine.rpm -= (speed * Constants.airResistance * numbersOfTransmission[transmissionNumber]);

            if (engine.rpm < 0)
            {
                engine.rpm = 0;
            }

            speed = engine.rpm / numbersOfTransmission[transmissionNumber] * (float)delta;

            distance += (float)(speed * delta * 60);
        }

        public void Next(double delta)
        {
            if (!isStarted) return;
            Move(delta);
        }

    }
}
