﻿using Proiect_de_an.Common.Constants;
using Spectre.Console;

namespace Proiect_de_an.CarManagement.CarWithElectricEngine;

public class Volvo : Car
{
    public Volvo(int nrOfDoors,
               int nrOfSeats,
               string deliveryType) : base(nrOfDoors,
                                           nrOfSeats,
                                           InternalCombustionEngineCarsPrices.Volvo,
                                           deliveryType)
    { }

    public void AddVolvoCharacteristicsOnDisplay()
    {
        CharacteristicsOnDisplay.Add("Volvo Logo");
        CharacteristicsOnDisplay.Add("Specific Volvo Animations");
        CharacteristicsOnDisplay.Add("Specific Volvo Functionalities");
        CharacteristicsOnDisplay.Add("Speed");
        CharacteristicsOnDisplay.Add("Rotation Speed");
        CharacteristicsOnDisplay.Add("Fuel Gauge");
        CharacteristicsOnDisplay.Add("Engine Temperature");
        CharacteristicsOnDisplay.Add("Warning Lights");
    }

    public override void AddCharacteristicsOnDisplay()
    {
        AddVolvoCharacteristicsOnDisplay();
    }

    public override void BuildCar()
    {
        AnsiConsole.Progress()
            .Columns(new ProgressColumn[]
            {
                new TaskDescriptionColumn(),
                new ProgressBarColumn(),
                new PercentageColumn(),
                new SpinnerColumn()
            })
            .Start(ctx =>
            {
                var task1 = ctx.AddTask("[yellow]Procesing information[/]");
                var task2 = ctx.AddTask("[yellow]Sending information to Volvo[/]");
                var task3 = ctx.AddTask("[yellow]Analyzing car model options and availability[/]");
                var task4 = ctx.AddTask("[yellow]Retrieving customization options and necesary parts for the selected car model[/]");
                var task5 = ctx.AddTask("[yellow]Building car[/]");
                var task6 = ctx.AddTask("[yellow]Calculating price[/]");
                var task7 = ctx.AddTask("[yellow]Building complete[/]");

                while (!ctx.IsFinished)
                {
                    task1.Increment(6.5);
                    task2.Increment(5.5);
                    task3.Increment(4.5);
                    task4.Increment(3.5);
                    task5.Increment(2.5);
                    task6.Increment(1.5);
                    task7.Increment(0.5);
                }
            });

        OrderState.ReadyOrNotReady();
    }
}
