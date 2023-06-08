using Proiect_de_an.CarManagement;
using Proiect_de_an.CarManagement.CarWithElectricEngine;
using Proiect_de_an.Common.Enums;
using Spectre.Console;

var orderedCars = new List<Car>();

var menuOptions = Enum.GetNames(typeof(MenuOptions)).ToList();
var electricEngineCarsCompanies = Enum.GetNames(typeof(ElectricEngineCarsCompanies)).ToList();
var internalCombustionEngineCarsCompanies = Enum.GetNames(typeof(InternalCombustionEngineCarsCompanies)).ToList();
var engineTypes = Enum.GetNames(typeof(EngineTypes)).ToList();
var interiorTypes = Enum.GetNames(typeof(InteriorTypes)).ToList();
var interiorOptions = Enum.GetNames(typeof(InteriorOptions)).ToList();
var deliveryTypes = Enum.GetNames(typeof(DeliveryTypes)).ToList();

var name = string.Empty;
var email = string.Empty;
var phone = string.Empty;
var address = string.Empty;

AnsiConsole.Write(
    new FigletText("Build your own car")
        .Color(Color.Red));

var exit = false;

while (!exit)
{
    var selectedMenuOption = AnsiConsole.Prompt(
      new SelectionPrompt<string>()
          .Title("Select [green]menu option[/]")
          .AddChoices(menuOptions));

    if (selectedMenuOption == MenuOptions.ORDER_A_CAR.ToString())
    {
        name = AnsiConsole.Ask<string>("What's your [green]name[/]?");
        email = AnsiConsole.Ask<string>("What's your [green]email[/]?");
        phone = AnsiConsole.Ask<string>("What's your [green]phone[/]?");
        address = AnsiConsole.Ask<string>("What's your [green]address[/]?");
        var nrOfDoors = AnsiConsole.Ask<string>("Choose [green]number of doors[/]:");
        var nrOfSeats = AnsiConsole.Ask<string>("Choose [green]number of seats[/]:");

        Console.WriteLine();

        var selectedEngineType = AnsiConsole.Prompt(
          new SelectionPrompt<string>()
              .Title("Select [green]engine type[/]")
              .AddChoices(engineTypes));

        var selectedInteriorType = AnsiConsole.Prompt(
          new SelectionPrompt<string>()
              .Title("Select [green]interior type[/]")
              .AddChoices(interiorTypes));

        var selectedInteriorOptions = AnsiConsole.Prompt(
            new MultiSelectionPrompt<string>()
                .Title("Select [green]interior options[/]")
                .NotRequired()
                .InstructionsText(
                    "[grey](Press [blue]<space>[/] to select an optioin, " +
                    "[green]<enter>[/] to accept)[/]")
                .AddChoices(interiorOptions));

        var selectedDeliveryType = AnsiConsole.Prompt(
          new SelectionPrompt<string>()
              .Title("Select [green]delivery type[/]")
              .AddChoices(deliveryTypes));

        Car car;

        if (selectedEngineType == EngineTypes.CAR_WITH_ELECTRIC_ENGINE.ToString())
        {
            var selectedCompanyOption = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select [green]company[/]")
                    .AddChoices(electricEngineCarsCompanies));

            CarFactory carFactory = new CarWithElectricEngineFactory();
            car = carFactory.CreateCar(selectedCompanyOption,
                                               Int32.Parse(nrOfDoors),
                                               Int32.Parse(nrOfSeats),
                                               selectedInteriorType,
                                               selectedInteriorOptions,
                                               selectedDeliveryType);
        }
        else
        {
            var selectedCompanyOption = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("Select [green]company[/]")
                    .AddChoices(internalCombustionEngineCarsCompanies));

            CarFactory carFactory = new CarWithInternalCombustionEngineFactory();
            car = carFactory.CreateCar(selectedCompanyOption,
                                               Int32.Parse(nrOfDoors),
                                               Int32.Parse(nrOfSeats),
                                               selectedInteriorType,
                                               selectedInteriorOptions,
                                               selectedDeliveryType);
        }

        car.DeliveryCar();

        orderedCars.Add(car);
    }
    else if (selectedMenuOption == MenuOptions.SHOW_ORDERS.ToString())
    {
        var table = new Table();

        table.AddColumn("Nr");
        table.AddColumn("Name");
        table.AddColumn("Email");
        table.AddColumn("Phone");
        table.AddColumn("Address");
        table.AddColumn("Number of doors");
        table.AddColumn("Number of seats");
        table.AddColumn("Interior");
        table.AddColumn("Display Characteristics");
        table.AddColumn("Price");
        table.AddColumn("Delivery");
        table.AddColumn("Company");

        for (int i = 0; i < orderedCars.Count; i++)
        {
            table.AddRow(new Markup((i + 1).ToString()),
                         new Markup(name),
                         new Markup(email),
                         new Markup(phone),
                         new Markup(address),
                         new Markup(orderedCars[i].NrOfDoors.ToString()),
                         new Markup(orderedCars[i].NrOfSeats.ToString()),
                         new Markup(orderedCars[i].CarInterior.Description),
                         new Panel(string.Join("\n", orderedCars[i].CharacteristicsOnDisplay)),
                         new Markup(orderedCars[i].TotalPrice.ToString() + "$"),
                         new Markup(orderedCars[i].DeliveryDuration.ToString() + " days"),
                         new Markup(orderedCars[i].GetType().Name));
        }

        AnsiConsole.Write(table);
    }
    else
    {
        exit = true;
    }
}