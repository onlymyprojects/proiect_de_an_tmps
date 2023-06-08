﻿using Proiect_de_an.Common.Constants;
using Spectre.Console;

namespace Proiect_de_an.CarManagement.CarWithElectricEngine;

public class FordMotor : Car
{
    public FordMotor(int nrOfDoors,
               int nrOfSeats,
               string deliveryType) : base(nrOfDoors,
                                           nrOfSeats,
                                           ElectricEngineCarsPrices.FordMotor,
                                           deliveryType)
    { }

    public void AddFordCharacteristicsOnDisplay()
    {
        CharacteristicsOnDisplay.Add("Ford Logo");
        CharacteristicsOnDisplay.Add("Specific Ford Animations");
        CharacteristicsOnDisplay.Add("Specific Ford Functionalities");
        CharacteristicsOnDisplay.Add("Speed");
        CharacteristicsOnDisplay.Add("Battery Level");
        CharacteristicsOnDisplay.Add("Battery Health");
        CharacteristicsOnDisplay.Add("Power Consumption");
        CharacteristicsOnDisplay.Add("Regenerative Breaking");
    }

    public override void AddCharacteristicsOnDisplay()
    {
        AddFordCharacteristicsOnDisplay();
    }

    public override void BuildCar()
    {
        AnsiConsole.Progress()
            .Start(ctx =>
            {
                var task1 = ctx.AddTask("[yellow]Procesing information[/]");
                var task2 = ctx.AddTask("[yellow]Sending information to Ford Motor[/]");
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
