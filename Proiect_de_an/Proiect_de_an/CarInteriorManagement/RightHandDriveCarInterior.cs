using Proiect_de_an.Common.Constants;

namespace Proiect_de_an.CarInteriorManagement;

public class RightHandDriveCarInterior : ICarInterior
{
    public string Description { get; set; } = "Interior with right hand drive";

    public int Cost()
    {
        return CarInteriorTypesPrices.INTERIOR_WITH_RIGHT_HAND_DRIVE;
    }
}
