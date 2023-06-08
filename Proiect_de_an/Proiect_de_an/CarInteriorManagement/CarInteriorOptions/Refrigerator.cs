using Proiect_de_an.Common.Constants;

namespace Proiect_de_an.CarInteriorManagement.CarInteriorOptions;

public class Refrigerator : CarInteriorDecorator
{
    public Refrigerator(ICarInterior carInterior) : base(carInterior) { }

    public override string Description { get => base.Description + ", refrigerator"; }

    public override int Cost()
    {
        return base.Cost() + CarInteriorOptionsPrices.REFRIGERATOR;
    }
}
