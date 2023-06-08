using Proiect_de_an.Common.Constants;

namespace Proiect_de_an.CarInteriorManagement.CarInteriorOptions;

public class AudioSystem : CarInteriorDecorator
{
    public AudioSystem(ICarInterior carInterior) : base(carInterior) { }

    public override string Description { get => base.Description + ", audio system"; }

    public override int Cost()
    {
        return base.Cost() + CarInteriorOptionsPrices.AUDIO_SYSTEM;
    }
}
