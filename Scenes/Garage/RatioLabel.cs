using Godot;
using NewCar.Models;
using StreetRacing.Models;
using System;

public partial class RatioLabel : Label
{
	HSlider slider;
	int number;
	Transmission playerTransmission;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		playerTransmission = MainModel.gameplayModel.playerCar.specifications.transmission;
        slider = GetNode<HSlider>("RatioSlider");
        slider.Value = 100 / 4f * playerTransmission.ratios[number];
    }

	public void SetNumber(int number)
	{
		this.number = number;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		Text = (number + 1).ToString() + " - " + playerTransmission.ratios[number];
        playerTransmission.ratios[number] = (float)slider.Value * 4f / 100f;

		if (number != 0)
			if (playerTransmission.ratios[number]
				>= playerTransmission.ratios[number - 1])
			{
				playerTransmission.ratios[number] = playerTransmission.ratios[number - 1];
			    slider.Value = 100 / 4f * playerTransmission.ratios[number];
			}

		if (number != playerTransmission.ratios.Count - 1)
			if (playerTransmission.ratios[number]
			    <= playerTransmission.ratios[number + 1])
			{
			    playerTransmission.ratios[number] = playerTransmission.ratios[number + 1];
			    slider.Value = 100 / 4f * playerTransmission.ratios[number];
			}

    }
}
