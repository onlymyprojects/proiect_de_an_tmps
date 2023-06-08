namespace Proiect_de_an.CarManagement;

public abstract class CarFactory
{
    public abstract Car CreateCar(string type,
                                      int nrOfDoors,
                                      int nrOfSeats,
                                      string interiorType,
                                      List<string> interiorOptions,
                                      string deliveryType);
}
