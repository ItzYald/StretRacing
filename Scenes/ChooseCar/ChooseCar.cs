using Godot;
using NewCar.Models;
using System;

public partial class ChooseCar : Control
{
	int numberCar;
	Button nextCarButton;
	Button previousCarButton;

	ColorRect powerRect;
	Label powerLabel;
	ColorRect maxRmpRect;
	Label maxRmpLabel;
	ColorRect quantityTransmissionsRect;
	Label quantityTransmissionsLabel;

	public override void _Ready()
	{
		nextCarButton = GetNode<Button>("Rectangle/NextCarButton");
		nextCarButton.Pressed += NextCar;
        previousCarButton = GetNode<Button>("Rectangle/PreviousCarButton");
        previousCarButton.Pressed += PreviousCar;

        powerRect = GetNode<ColorRect>
			("Rectangle/CarSpecifications/VBoxContainer/PowerBackground/Power");
        powerLabel = GetNode<Label>
            ("Rectangle/CarSpecifications/VBoxContainer/PowerLabel");
        maxRmpRect = GetNode<ColorRect>
			("Rectangle/CarSpecifications/VBoxContainer/MaxRpmBackground/MaxRpm");
        maxRmpLabel = GetNode<Label>
            ("Rectangle/CarSpecifications/VBoxContainer/MaxRpmLabel");
        quantityTransmissionsRect = GetNode<ColorRect>
			("Rectangle/CarSpecifications/VBoxContainer/QuantityTransmissionsBackground/QuantityTransmissions");
        quantityTransmissionsLabel = GetNode<Label>
            ("Rectangle/CarSpecifications/VBoxContainer/QuantityTransmissionsLabel");

    }

	private void NextCar()
	{
		if (numberCar == MainModel.playerCarsSpecifications.Count - 1)
			numberCar = 0;
		else
			numberCar += 1;
		MainModel.gameplayModel.playerCar =
			new Car((CarSpecifications)MainModel.playerCarsSpecifications[numberCar].Clone());
	}

    private void PreviousCar()
    {
		if (numberCar == 0)
			numberCar = MainModel.playerCarsSpecifications.Count - 1;
		else
			numberCar -= 1;
        MainModel.gameplayModel.playerCar = new Car((CarSpecifications)MainModel.playerCarsSpecifications[numberCar].Clone());
    }

    public override void _Process(double delta)
	{
		powerRect.Size = new Vector2(158 / 500f * MainModel.playerCarsSpecifications[numberCar].engineSpecifications.power, 18);
        powerLabel.Text = "MaxRpm: " + MainModel.playerCarsSpecifications[numberCar].engineSpecifications.power;

        maxRmpRect.Size = new Vector2(158 / 9000f * MainModel.playerCarsSpecifications[numberCar].engineSpecifications.maxRpm, 18);
		maxRmpLabel.Text = "MaxRpm: " + MainModel.playerCarsSpecifications[numberCar].engineSpecifications.maxRpm;


        quantityTransmissionsRect.Size = new Vector2(158 / 7f * MainModel.playerCarsSpecifications[numberCar].transmission.quantity, 18);
        quantityTransmissionsLabel.Text = "Transmissions: " + MainModel.playerCarsSpecifications[numberCar].transmission.quantity;



    }
}
