using NewCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetRacing.Models
{
    internal class GameplayModel
    {
        public bool timer;
        public bool isGameplay;
        public bool playerWin;
        public Car playerCar;
        public Car botCar;

        public GameplayModel(CarSpecifications playerCarSpectifications, CarSpecifications botCarSpecifications)
        {
            timer = false;
            isGameplay = true;
            playerCar = new Car(playerCarSpectifications);
            botCar = new Car(botCarSpecifications);
        }

        public void TimerStart()
        {
            Stop();
            isGameplay = false;
            timer = true;
        }

        public void PlayerWin()
        {
            playerWin = true;
            isGameplay = false;
            timer = false;
        }

        public void Start()
        {
            timer = false;
            isGameplay = true;
            playerWin = false;
            playerCar.Start();
            botCar.Start();
        }
        public void Stop()
        {
            playerWin = false;
            playerCar.Stop();
            botCar.Stop();
        }

    }
}
