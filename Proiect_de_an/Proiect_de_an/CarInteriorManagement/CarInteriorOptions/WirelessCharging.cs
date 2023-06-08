using Proiect_de_an.Common.Constants;

namespace Proiect_de_an.CarInteriorManagement.CarInteriorOptions;

public class WirelessCharging : CarInteriorDecorator
{
    public WirelessCharging(ICarInterior carInterior) : base(carInterior) { }

    public override string Description { get => base.Description + ", wireless charging"; }

    public override int Cost()
    {
        return base.Cost() + CarInteriorOptionsPrices.WIRELESS_CHARGING;
    }
}
