using Godot;
using NewCar.Models;
using System;
using System.Text.Json.Serialization.Metadata;

public partial class RestartButton : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Pressed += () =>
		{
			MainModel.gameplayModel.TimerStart();
		};
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

}
