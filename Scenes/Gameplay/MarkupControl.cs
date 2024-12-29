using Godot;
using NewCar.Models;
using System;
using System.Collections.Generic;

public partial class MarkupControl : Node2D
{
    Sprite2D sampleMarkup;

    List<Sprite2D> markups;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        sampleMarkup = GetNode<Sprite2D>("SampleMarkup");
        markups = new List<Sprite2D>();
        for (int i = 0; i < 10; i++)
        {
            markups.Add((Sprite2D)sampleMarkup.Duplicate());
            markups[i].Position = new Vector2(i * 128, 250);
            AddChild(markups[i]);
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        for (int i = 0; i < markups.Count; i++)
        {
            markups[i].Position = new Vector2(
                1280 - (MainModel.gameplayModel.playerCar.getPixelDistance() + i * 128) % 1280 - 10,
                250);
        }

    }
}
