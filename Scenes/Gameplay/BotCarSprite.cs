using Godot;
using NewCar.Models;
using StreetRacing;
using System;
using System.Runtime.ConstrainedExecution;

public partial class BotCarSprite : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = new Vector2(MainModel.gameplayModel.botCar.getPixelDistance() - MainModel.gameplayModel.playerCar.getPixelDistance() + 250, Position.Y);
		if (!MainModel.gameplayModel.isGameplay) return;

        if (!MainModel.gameplayModel.botCar.IsStarted) return;
		MainModel.gameplayModel.botCar.Next(delta);
        if (MainModel.gameplayModel.botCar.getRpm() > MainModel.gameplayModel.botCar.MaxRpm * 0.91)
        {
            MainModel.gameplayModel.botCar.TransmissionUp();
        }
    }
}
