using Godot;
using NewCar.Models;
using StreetRacing;
using System;
using System.Collections.Generic;

public partial class PlayerCarSprite : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		MainModel.playerCar.Start();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        MainModel.playerCar.Next();


        if (Input.IsActionJustReleased("TransmissionUp"))
		{
			MainModel.playerCar.TransmissionUp();
		}
        if (Input.IsActionJustReleased("TransmissionDown"))
        {
            MainModel.playerCar.TransmissionDown();
        }
    }
}
