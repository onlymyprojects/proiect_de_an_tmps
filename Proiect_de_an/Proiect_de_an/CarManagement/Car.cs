using Proiect_de_an.CarInteriorManagement;
using Proiect_de_an.Common.Enums;
using Proiect_de_an.DeliveryManagement;
using Proiect_de_an.OrderManagement;

namespace Proiect_de_an.CarManagement;

public abstract class Car
{
    public int NrOfDoors { get; set; }
    public int NrOfSeats { get; set; }
    public List<string> CharacteristicsOnDisplay { get; set; } = new List<string>();
    public int DefaultPrice { get; }
    public ICarInterior CarInterior { get; set; }
    public int TotalPrice { get; set; }
    public Order OrderState { get; set; } = new Order(new OrderNotReadyState());
    public IDeliveryStrategy DeliveryStrategy { get; set; }
    public int DeliveryDuration { get; set; }

    public virtual void AddCharacteristicsOnDisplay()
    {
        CharacteristicsOnDisplay.Add("Characteristics not added");
    }

    public abstract void BuildCar();

    public Car(int nrOfDoors, int nrOfSeats, int defaultPrice, string deliveryStrategy)
    {
        NrOfDoors = nrOfDoors;
        NrOfSeats = nrOfSeats;
        DefaultPrice = defaultPrice;

        if (deliveryStrategy == DeliveryTypes.STANDART_DELIVERY.ToString())
        {
            DeliveryStrategy = new StandartDeliveryStrategy();
        }
        else
        {
            DeliveryStrategy = new ExpressDeliveryStrategy();
        }
    }

    public void DeliveryCar()
    {
        DeliveryDuration = DeliveryStrategy.StartDelivery();
    }
}
