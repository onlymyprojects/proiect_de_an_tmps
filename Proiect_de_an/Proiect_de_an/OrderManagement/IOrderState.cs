namespace Proiect_de_an.OrderManagement;

public interface IOrderState
{
    void Handle(Order order);
}
