using Godot;
using NewCar.Models;
using System;

public partial class LoseGui : ColorRect
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        if (MainModel.gameplayModel.botWin)
        {
            Visible = true;
        }
        else
        {
            Visible = false;
        }
    }
}
