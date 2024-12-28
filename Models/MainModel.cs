using StreetRacing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCar.Models
{
    internal static class MainModel
    {
        public static List<CarSpecifications> playerCarsSpecifications;

        public static CarSpecifications playerCarSpecifications;
        public static CarSpecifications botCarSpecifications;

        public static GameplayModel gameplayModel;

        static MainModel()
        {
            playerCarsSpecifications = new List<CarSpecifications>();

            playerCarsSpecifications.Add(new CarSpecifications(new EngineSpecifications(200, 6500)));
            playerCarsSpecifications.Add(new CarSpecifications(new EngineSpecifications(300, 7000)));
            playerCarsSpecifications.Add(new CarSpecifications(new EngineSpecifications(300, 8000)));

            playerCarSpecifications = new CarSpecifications(new EngineSpecifications(300, 7000));
            botCarSpecifications = new CarSpecifications(new EngineSpecifications(300, 7000));
            gameplayModel = new GameplayModel(playerCarsSpecifications[0], botCarSpecifications, 500);
        }


    }
}
