using Proiect_de_an.Common.Constants;

namespace Proiect_de_an.DeliveryManagement;

public class ExpressDeliveryStrategy : IDeliveryStrategy
{
    public int StartDelivery()
    {
        return DeliveryDurations.ExpressDelivery;
    }
}
