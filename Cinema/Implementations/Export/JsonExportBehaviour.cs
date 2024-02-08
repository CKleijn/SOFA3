using System.Text.Json;
using Cinema.Interfaces.Export;
using Cinema.Models;

namespace Cinema.Implementations.Export
{
    public class JsonExportBehaviour : IExportBehaviour
    {
        public void Export(Order order)
        {
            var JsonObject = new
            {
                orderNr = order.GetOrder(),
                isStudentOrder = order.GetIsStudentOrder(),
                price = order.CalculatePrice().ToString("C2"),
                ticketAmount = order.GetTicketList().Count
            };

            string jsonString = JsonSerializer.Serialize(JsonObject);

            File.WriteAllText($"./Exports/order_{order.GetOrder()}_{DateTime.Now:dd_MM_yyyy}.json", jsonString);
        }
    }
}
