using Godot;
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

        public CarSpecifications specifications;

        float distance;
        float speed;

        bool isStarted;

        public bool IsStarted { get { return isStarted; } }

        public int MaxRpm { get { return engine.MaxRpm; } }

        const float powerK = 6666666.6f;

        public Car(CarSpecifications specifications)
        {
            distance = 0;
            speed = 0;

            this.specifications = (CarSpecifications)specifications;

            engine = new Engine(this.specifications.engineSpecifications, getTransmission);

            isStarted = false;
        }

        public float getPixelDistance() => (distance / 60f * 23f);
        public float getRealDistance() => (distance * 0.0046296f);
        public float getDistance() => distance;
        public int getSpeed() => (int)speed;
        public float getRpm() => engine.rpm;
        public int getTransmissionNumber() => specifications.transmission.number + 1;
        public float getTransmission() => specifications.transmission.ratios[specifications.transmission.number];

        public void Start()
        {
            //GD.Print(specifications.transmission.quantity);
            //GD.Print(specifications.transmission.ratios.Count());
            //GD.Print(" ");
            speed = 0;
            specifications.transmission.number = 0;
            distance = 0;
            engine.Start();
            isStarted = true;
        }

        public void Stop()
        {
            distance = 0;
            speed = 0;
            specifications.transmission.number = 0;
            isStarted = false;
            engine.Stop();
        }

        public void TransmissionUp()
        {
            if (specifications.transmission.number + 1 < specifications.transmission.ratios.Count())
            {
                specifications.transmission.number += 1;
                engine.rpm = (int)(engine.rpm * 
                    (specifications.transmission.ratios[specifications.transmission.number]
                    / specifications.transmission.ratios[specifications.transmission.number - 1]));
            }
        }

        public void TransmissionDown()
        {
            if (specifications.transmission.number > 0)
            {
                specifications.transmission.number -= 1;
            }
        }
        public void Accel(double delta)
        {
            engine.rpm +=
                (float)delta * (-1 * engine.rpm * engine.rpm + 2 * engine.MaxRpm * engine.rpm)
                / powerK * engine.Power * specifications.transmission.ratios[specifications.transmission.number];
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
                    engine.rpm -= (float)
                        (300 * specifications.transmission.ratios[specifications.transmission.number] *
                        Math.Pow(engine.rpm - engine.MaxRpm, 0.89) / (engine.MaxRpm * 1.05f - engine.MaxRpm));
                }
                engine.rpm += (0.5f * specifications.transmission.ratios[specifications.transmission.number]);
            }

            engine.rpm -= (speed * Constants.airResistance * specifications.transmission.ratios[specifications.transmission.number]);

            if (engine.rpm < 0)
            {
                engine.rpm = 0;
            }

            speed = engine.rpm / specifications.transmission.ratios[specifications.transmission.number] * (float)delta;

            distance += (float)(speed * delta * 60);
        }

        public void Next(double delta)
        {
            if (!isStarted) return;
            Move(delta);
        }

    }
}
