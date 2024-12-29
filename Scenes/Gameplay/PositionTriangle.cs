using Godot;
using NewCar.Models;
using System;

public partial class PositionTriangle : Sprite2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Position = new Vector2(
			400.0f / (float)MainModel.gameplayModel.needDistance * MainModel.gameplayModel.playerCar.getRealDistance(),
			Position.Y);
	}
}
