using Godot;
using NewCar.Models;
using StreetRacing;
using System;
using System.Collections.Generic;

public partial class PlayerCarSprite : Sprite2D
{
    Car playerCar;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        playerCar = MainModel.gameplayModel.playerCar;
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if (!MainModel.gameplayModel.isGameplay) return;

        if (playerCar.getRealDistance() >= MainModel.gameplayModel.thisDistance)
        {
            MainModel.gameplayModel.PlayerWin();
        }

        playerCar.Next(delta);

        if (Input.IsActionJustReleased("Start"))
        {
            MainModel.gameplayModel.TimerStart();
        }
        if (Input.IsActionJustReleased("Stop"))
        {
            MainModel.gameplayModel.Stop();
        }

        if (Input.IsActionJustReleased("TransmissionUp"))
		{
			playerCar.TransmissionUp();
		}
        if (Input.IsActionJustReleased("TransmissionDown"))
        {
            playerCar.TransmissionDown();
        }
    }
}
