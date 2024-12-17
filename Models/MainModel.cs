using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCar.Models
{
    internal static class MainModel
    {
        public static CarSpecifications playerCarSpecifications;
        public static CarSpecifications botCarSpecifications;

        public static Car playerCar;
        public static Car botCar;

        static MainModel()
        {
            playerCarSpecifications = new CarSpecifications(new EngineSpecifications(300, 7000));
            botCarSpecifications = new CarSpecifications(new EngineSpecifications(300, 7000));
            playerCar = new Car(playerCarSpecifications);
            botCar = new Car(botCarSpecifications);

        }


    }
}
