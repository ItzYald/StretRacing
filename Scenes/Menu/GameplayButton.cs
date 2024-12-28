using Godot;
using System;

public partial class GameplayButton : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        Pressed += () =>
        {
            GetTree().ChangeSceneToFile("res://Scenes/ChooseCar/choose_car.tscn");
        };
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        
    }
}
