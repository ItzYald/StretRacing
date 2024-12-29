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

            playerCarsSpecifications.Add(new CarSpecifications(new EngineSpecifications(200, 6500), 5));
            playerCarsSpecifications.Add(new CarSpecifications(new EngineSpecifications(300, 7000), 6));
            playerCarsSpecifications.Add(new CarSpecifications(new EngineSpecifications(300, 8000), 5));

            playerCarSpecifications = (CarSpecifications)playerCarsSpecifications[0].Clone();
            botCarSpecifications = (CarSpecifications)playerCarsSpecifications[1].Clone();
            gameplayModel = new GameplayModel(playerCarSpecifications, botCarSpecifications, 500);
        }


    }
}
