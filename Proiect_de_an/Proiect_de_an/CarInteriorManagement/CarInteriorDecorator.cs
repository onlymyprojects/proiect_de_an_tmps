namespace Proiect_de_an.CarInteriorManagement;

public class CarInteriorDecorator : ICarInterior
{
    private readonly ICarInterior _carInterior;

    public CarInteriorDecorator(ICarInterior carInterior)
    {
        _carInterior = carInterior;
    }

    public virtual string Description { get => _carInterior.Description; set => _carInterior.Description = value; }

    public virtual int Cost()
    {
        return _carInterior.Cost();
    }
}
