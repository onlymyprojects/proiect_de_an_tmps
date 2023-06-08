namespace Proiect_de_an.OrderManagement;

public class OrderReadyState : IOrderState
{
    public void Handle(Order order)
    {
        order.State = new OrderNotReadyState();
    }
}
