using Godot;
using NewCar.Models;
using System;
using System.Collections.Generic;

public partial class RatiosContainer : VBoxContainer
{
	List<RatioLabel> ratiosLabels;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        ratiosLabels = new List<RatioLabel>();

        Update();
    }

	public void Update()
	{
		ratiosLabels.Clear();

        for (int i = 1; i < GetChildren().Count; i++)
        {
            GetChild(i).QueueFree();
        }

        ratiosLabels.Add(GetNode<RatioLabel>("RatioLabel"));
        ratiosLabels[0].SetNumber(0);

        for (int i = 1; i < MainModel.gameplayModel.playerCar.specifications.transmission.ratios.Count; i++)
        {
            ratiosLabels.Add((RatioLabel)ratiosLabels[0].Duplicate());
            ratiosLabels[i].SetNumber(i);
            AddChild(ratiosLabels[i]);
        }
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
