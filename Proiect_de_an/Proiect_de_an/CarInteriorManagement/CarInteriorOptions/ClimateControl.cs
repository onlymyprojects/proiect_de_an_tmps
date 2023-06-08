using Proiect_de_an.Common.Constants;

namespace Proiect_de_an.CarInteriorManagement.CarInteriorOptions;

public class ClimateControl : CarInteriorDecorator
{
    public ClimateControl(ICarInterior carInterior) : base(carInterior) { }

    public override string Description { get => base.Description + ", climate control"; }

    public override int Cost()
    {
        return base.Cost() + CarInteriorOptionsPrices.CLIMATE_CONTROL;
    }
}
