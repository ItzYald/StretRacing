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
        public static List<CarSpecifications> botCarsSpecifications;

        public static CarSpecifications playerCarSpecifications;
        public static CarSpecifications botCarSpecifications;

        public static GameplayModel gameplayModel;

        static MainModel()
        {
            playerCarsSpecifications = new List<CarSpecifications>
            {
                new CarSpecifications(new EngineSpecifications(200, 6500), 5),
                new CarSpecifications(new EngineSpecifications(300, 7000), 6),
                new CarSpecifications(new EngineSpecifications(300, 8000), 5)
            };

            botCarsSpecifications = new List<CarSpecifications>
            {
                new CarSpecifications(new EngineSpecifications(200, 6500), 5),
                new CarSpecifications(new EngineSpecifications(300, 7000), 6),
                new CarSpecifications(new EngineSpecifications(300, 8000), 5)
            };

            playerCarSpecifications = playerCarsSpecifications[0];
            botCarSpecifications = botCarsSpecifications[1];
            gameplayModel = new GameplayModel(playerCarSpecifications, botCarSpecifications, 500);
        }


    }
}
