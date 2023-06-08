namespace Proiect_de_an.OrderManagement;

public class Order
{
    IOrderState orderState;

    public Order(IOrderState orderState)
    {
        this.orderState = orderState;
    }

    public IOrderState State
    {
        get { return orderState; }
        set
        {
            orderState = value;
        }
    }

    public void ReadyOrNotReady()
    {
        orderState.Handle(this);
    }
}
