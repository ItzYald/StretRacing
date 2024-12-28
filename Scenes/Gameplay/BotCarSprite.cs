using Godot;
using NewCar.Models;
using StreetRacing;
using System;
using System.Runtime.ConstrainedExecution;

public partial class BotCarSprite : Sprite2D
{
    Car botCar;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        botCar = MainModel.gameplayModel.botCar;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = new Vector2(botCar.getPixelDistance() - MainModel.gameplayModel.playerCar.getPixelDistance() + 250, Position.Y);
		if (!MainModel.gameplayModel.isGameplay) return;

        if (botCar.getRealDistance() >= MainModel.gameplayModel.needDistance)
        {
            MainModel.gameplayModel.BotWin();
        }

        if (!botCar.IsStarted) return;
		botCar.Next(delta);
        if (botCar.getRpm() > botCar.MaxRpm * 0.91)
        {
            botCar.TransmissionUp();
        }
    }
}
