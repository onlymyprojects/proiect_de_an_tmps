namespace Proiect_de_an.OrderManagement;

public class OrderNotReadyState : IOrderState
{
    public void Handle(Order order)
    {
        order.State = new OrderReadyState();
    }
}
