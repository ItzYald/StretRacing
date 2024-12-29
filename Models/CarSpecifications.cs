using StreetRacing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCar.Models
{
    internal struct CarSpecifications : ICloneable
    {
        public EngineSpecifications engineSpecifications;
        public Transmission transmission;

        public CarSpecifications(EngineSpecifications engineSpecifications, int quantityTransmissions)
        {
            this.engineSpecifications = engineSpecifications;
            transmission = new Transmission(quantityTransmissions);
        }

        public object Clone()
        {
            return new CarSpecifications(engineSpecifications, transmission.quantity);
        }
    }
}
