using Proiect_de_an.Common.Constants;

namespace Proiect_de_an.CarInteriorManagement.CarInteriorOptions;

public class MassagingSeats : CarInteriorDecorator
{
    public MassagingSeats(ICarInterior carInterior) : base(carInterior) { }

    public override string Description { get => base.Description + ", massaging seats"; }

    public override int Cost()
    {
        return base.Cost() + CarInteriorOptionsPrices.MASSAGING_SEATS;
    }
}
