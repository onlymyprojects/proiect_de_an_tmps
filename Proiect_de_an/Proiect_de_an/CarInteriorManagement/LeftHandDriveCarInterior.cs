using Proiect_de_an.Common.Constants;

namespace Proiect_de_an.CarInteriorManagement;

public class LeftHandDriveCarInterior : ICarInterior
{
    public string Description { get; set; } = "Interior with left hand drive";

    public int Cost()
    {
        return CarInteriorTypesPrices.INTERIOR_WITH_LEFT_HAND_DRIVE;
    }
}
