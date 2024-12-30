using Godot;
using NewCar.Models;
using System;

public partial class Garage : Control
{
    int numberCar = 0;
    Button nextCarButton;
    Button previousCarButton;

    ColorRect powerRect;
    Label powerLabel;
    ColorRect maxRmpRect;
    Label maxRmpLabel;
    ColorRect quantityTransmissionsRect;
    Label quantityTransmissionsLabel;

    RatiosContainer ratiosContainer;

    ColorRect ratiosRect;



    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        nextCarButton = GetNode<Button>("Rectangle/NextCarButton");
        nextCarButton.Pressed += NextCar;
        previousCarButton = GetNode<Button>("Rectangle/PreviousCarButton");
        previousCarButton.Pressed += PreviousCar;

        ratiosRect = GetNode<ColorRect>("Rectangle/RatiosRect");
        ratiosContainer = GetNode<RatiosContainer>("Rectangle/RatiosRect/RatiosContainer");

        RatiosRectSizeUpdate();

        powerRect = GetNode<ColorRect>
            ("Rectangle/CarSpecifications/SpecificationsContainer/PowerBackground/Power");
        powerLabel = GetNode<Label>
            ("Rectangle/CarSpecifications/SpecificationsContainer/PowerLabel");
        maxRmpRect = GetNode<ColorRect>
            ("Rectangle/CarSpecifications/SpecificationsContainer/MaxRpmBackground/MaxRpm");
        maxRmpLabel = GetNode<Label>
            ("Rectangle/CarSpecifications/SpecificationsContainer/MaxRpmLabel");
        quantityTransmissionsRect = GetNode<ColorRect>
            ("Rectangle/CarSpecifications/SpecificationsContainer/QuantityTransmissionsBackground/QuantityTransmissions");
        quantityTransmissionsLabel = GetNode<Label>
            ("Rectangle/CarSpecifications/SpecificationsContainer/QuantityTransmissionsLabel");
    }

    private void RatiosRectSizeUpdate()
    {
        if (MainModel.playerCarsSpecifications[numberCar].transmission.quantity == 5)
        {
            ratiosRect.Size = new Vector2(ratiosRect.Size.X, 280);
        }
        else
        {
            ratiosRect.Size = new Vector2(ratiosRect.Size.X, 320);
        }
    }

    private void NextCar()
    {
        if (numberCar == MainModel.playerCarsSpecifications.Count - 1)
            numberCar = 0;
        else
            numberCar += 1;
        MainModel.gameplayModel.playerCar =
            new Car(MainModel.playerCarsSpecifications[numberCar]);
        ratiosContainer.Update();

        RatiosRectSizeUpdate();
    }

    private void PreviousCar()
    {
        if (numberCar == 0)
            numberCar = MainModel.playerCarsSpecifications.Count - 1;
        else
            numberCar -= 1;
        MainModel.gameplayModel.playerCar = new Car(MainModel.playerCarsSpecifications[numberCar]);
        ratiosContainer.Update();
        RatiosRectSizeUpdate();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
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
