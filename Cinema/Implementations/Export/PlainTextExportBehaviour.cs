using Cinema.Interfaces.Export;

namespace Cinema.Implementations.Export
{
    public class PlainTextExportBehaviour : IExportBehaviour
    {
        public void Export(Order order) => File.WriteAllText($"./Exports/order-{order.GetOrder()}-{DateTime.Now:dd-MM-yyyy}.txt", order.ToString());
    }
}
