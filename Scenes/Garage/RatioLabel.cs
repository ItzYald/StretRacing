using Godot;
using NewCar.Models;
using System;

public partial class RatioLabel : Label
{
	HSlider slider;
	int number;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		slider = GetNode<HSlider>("RatioSlider");
        slider.Value = 100 / 4f * MainModel.gameplayModel.playerCar.specifications.transmission.ratios[number];
    }

	public void SetNumber(int number)
	{
		this.number = number;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Text = (number + 1).ToString() + " - " + MainModel.gameplayModel.playerCar.specifications.transmission.ratios[number];
		MainModel.gameplayModel.playerCar.specifications.transmission.ratios[number] = (float)slider.Value * 4f / 100f;

    }
}
