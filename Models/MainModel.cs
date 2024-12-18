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
        public static CarSpecifications playerCarSpecifications;
        public static CarSpecifications botCarSpecifications;

        public static GameplayModel gameplayModel;

        static MainModel()
        {
            playerCarSpecifications = new CarSpecifications(new EngineSpecifications(300, 7000));
            botCarSpecifications = new CarSpecifications(new EngineSpecifications(300, 7000));
            gameplayModel = new GameplayModel(playerCarSpecifications, botCarSpecifications, 200);
        }


    }
}
