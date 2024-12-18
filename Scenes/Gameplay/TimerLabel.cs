using Godot;
using NewCar.Models;
using System;

public partial class TimerLabel : Label
{
	double timer;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		timer = 0;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (timer >= 3.0)
		{
			MainModel.gameplayModel.Start();
			timer = 0;
		}
		if (MainModel.gameplayModel.timer)
		{
			Text = (3 - (int)timer).ToString();
			Visible = true;
			timer += delta;
		}
		else
		{
			Visible = false;
            timer = 0;
		}
	}
}
