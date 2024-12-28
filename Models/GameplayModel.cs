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
        public bool botWin;
        public Car playerCar;
        public Car botCar;

        public int needDistance;

        public GameplayModel(CarSpecifications playerCarSpectifications, CarSpecifications botCarSpecifications, int needDistance)
        {
            this.needDistance = needDistance;

            botWin = false;
            playerWin = false;

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

        public void BotWin()
        {
            botWin = true;
            isGameplay = false;
            timer = false;
        }

        public void Start()
        {
            timer = false;
            isGameplay = true;
            playerWin = false;
            botWin = false;
            playerCar.Start();
            botCar.Start();
        }
        public void Stop()
        {
            playerWin = false;
            botWin = false;
            playerCar.Stop();
            botCar.Stop();
        }

    }
}
