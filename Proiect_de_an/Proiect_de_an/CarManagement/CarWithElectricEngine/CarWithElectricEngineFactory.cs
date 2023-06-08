using Proiect_de_an.CarInteriorManagement;
using Proiect_de_an.CarInteriorManagement.CarInteriorOptions;
using Proiect_de_an.Common.Constants;
using Proiect_de_an.Common.Enums;
using Proiect_de_an.OrderManagement;
using Spectre.Console;

namespace Proiect_de_an.CarManagement.CarWithElectricEngine;

public class CarWithElectricEngineFactory : CarFactory
{
    public override Car CreateCar(string companyType,
                                      int nrOfDoors,
                                      int nrOfSeats,
                                      string interiorType,
                                      List<string> interiorOptions,
                                      string deliveryType)
    {
        Car car;

        if (companyType == ElectricEngineCarsCompanies.TESLA.ToString())
        {
            car = new Tesla(nrOfDoors, nrOfSeats, deliveryType);
        }
        else if (companyType == ElectricEngineCarsCompanies.GENERAL_MOTORS.ToString())
        {
            car = new GeneralMotors(nrOfDoors, nrOfSeats, deliveryType);
        }
        else if (companyType == ElectricEngineCarsCompanies.FORD_MOTOR.ToString())
        {
            car = new FordMotor(nrOfDoors, nrOfSeats, deliveryType);
        }
        else
        {
            throw new ArgumentException("No such car.");
        }

        if (interiorType == InteriorTypes.INTERIOR_WITH_LEFT_HAND_DRIVE.ToString())
        {
            car.CarInterior = new LeftHandDriveCarInterior();
        }
        else
        {
            car.CarInterior = new RightHandDriveCarInterior();
        }

        if (interiorOptions.Contains(InteriorOptions.COASTERS.ToString()))
        {
            car.CarInterior = new Coasters(car.CarInterior);
        }

        if (interiorOptions.Contains(InteriorOptions.AUDIO_SYSTEM.ToString()))
        {
            car.CarInterior = new AudioSystem(car.CarInterior);
        }

        if (interiorOptions.Contains(InteriorOptions.CLIMATE_CONTROL.ToString()))
        {
            car.CarInterior = new ClimateControl(car.CarInterior);
        }

        if (interiorOptions.Contains(InteriorOptions.REFRIGERATOR.ToString()))
        {
            car.CarInterior = new Refrigerator(car.CarInterior);
        }

        if (interiorOptions.Contains(InteriorOptions.WIRELESS_CHARGING.ToString()))
        {
            car.CarInterior = new WirelessCharging(car.CarInterior);
        }

        if (interiorOptions.Contains(InteriorOptions.MASSAGING_SEATS.ToString()))
        {
            car.CarInterior = new MassagingSeats(car.CarInterior);
        }

        car.TotalPrice = car.DefaultPrice +
                         car.CarInterior.Cost() +
                         nrOfDoors * CarPartsPrices.Door +
                         nrOfSeats * CarPartsPrices.Seat;

        car.AddCharacteristicsOnDisplay();
        car.BuildCar();

        if (car.OrderState.State.GetType() == typeof(OrderReadyState))
        {
            AnsiConsole.Write(new Markup($"[green]Your car is created[/]"));
            Console.WriteLine();
        }

        Console.WriteLine();

        return car;
    }
}