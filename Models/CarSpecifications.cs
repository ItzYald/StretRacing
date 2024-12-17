using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCar.Models
{
    internal struct CarSpecifications
    {
        public EngineSpecifications engineSpecifications;

        public CarSpecifications(EngineSpecifications engineSpecifications)
        {
            this.engineSpecifications = engineSpecifications;
        }

    }
}
