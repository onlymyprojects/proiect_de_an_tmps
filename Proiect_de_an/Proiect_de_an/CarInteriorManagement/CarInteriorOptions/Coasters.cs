using Proiect_de_an.Common.Constants;

namespace Proiect_de_an.CarInteriorManagement.CarInteriorOptions;

public class Coasters : CarInteriorDecorator
{
    public Coasters(ICarInterior carInterior) : base(carInterior) { }

    public override string Description { get => base.Description + ", coasters"; }

    public override int Cost()
    {
        return base.Cost() + CarInteriorOptionsPrices.COASTERS;
    }
}
