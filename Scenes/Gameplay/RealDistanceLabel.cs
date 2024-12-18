using Godot;
using NewCar.Models;
using System;

public partial class RealDistanceLabel : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Text = ((int)(MainModel.gameplayModel.playerCar.getRealDistance())).ToString();
	}
}