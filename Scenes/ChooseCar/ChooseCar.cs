using Godot;
using NewCar.Models;
using System;

public partial class ChooseCar : Control
{
	int numberCar;
	Button nextCarButton;
	Button previousCarButton;

	ColorRect powerRect;
	ColorRect maxRmpRect;

	public override void _Ready()
	{
		nextCarButton = GetNode<Button>("Rectangle/NextCarButton");
		nextCarButton.Pressed += NextCar;
        previousCarButton = GetNode<Button>("Rectangle/PreviousCarButton");
        previousCarButton.Pressed += PreviousCar;

        powerRect = GetNode<ColorRect>("Rectangle/CarSpecifications/VBoxContainer/PowerBackground/Power");
        maxRmpRect = GetNode<ColorRect>("Rectangle/CarSpecifications/VBoxContainer/MaxRpmBackground/MaxRpm");
		
		

    }

	private void NextCar()
	{
		if (numberCar == MainModel.playerCarsSpecifications.Count - 1)
			numberCar = 0;
		else
			numberCar += 1;
		MainModel.gameplayModel.playerCar = new Car(MainModel.playerCarsSpecifications[numberCar]);
	}

    private void PreviousCar()
    {
		if (numberCar == 0)
			numberCar = MainModel.playerCarsSpecifications.Count - 1;
		else
			numberCar -= 1;
        MainModel.gameplayModel.playerCar = new Car(MainModel.playerCarsSpecifications[numberCar]);
    }

    public override void _Process(double delta)
	{
		powerRect.Size = new Vector2(138 / 500f * MainModel.playerCarsSpecifications[numberCar].engineSpecifications.power, 18);
		maxRmpRect.Size = new Vector2(138 / 9000f * MainModel.playerCarsSpecifications[numberCar].engineSpecifications.maxRpm, 18);
	}
}
