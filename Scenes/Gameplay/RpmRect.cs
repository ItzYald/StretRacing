using Godot;
using NewCar.Models;
using System;

public partial class RpmRect : ColorRect
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        //Size = new Vector2(250f * (MainModel.gameplayModel.playerCar.getRpm() / (float)MainModel.gameplayModel.playerCar.MaxRpm / 1.1f), Size.Y);
        RotationDegrees = MainModel.gameplayModel.playerCar.getRpm() / 40f + 170;
    }
}
