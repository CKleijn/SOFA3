using System.Text.Json;
using System.Text;

namespace Cinema
{
    public class Order(int orderNr, bool isStudentOrder)
    {
        private readonly int _orderNr = orderNr;
        private readonly bool _isStudentOrder = isStudentOrder;
        private readonly List<MovieTicket> _ticketList = [];

        public int GetOrder() => _orderNr;

        public void AddSeatReservation(MovieTicket ticket) => _ticketList.Add(ticket);

        public double CalculatePrice()
        {
            double totalPrice = 0;
            bool isWeekend = false;

            for (var i = 0; i < _ticketList.Count; i++)
            {
                MovieTicket ticket = _ticketList[i];
                int ticketNumber = i + 1;
                var dayOfWeek = ticket.GetScreeningTime().DayOfWeek;
                isWeekend = (dayOfWeek == DayOfWeek.Friday || dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday);
                double ticketPrice = ticket.GetPrice();

                if (ticketNumber % 2 == 0 && (_isStudentOrder || !isWeekend))
                    continue;

                if (ticket.IsPremiumTicket())
                    ticketPrice += _isStudentOrder ? 2 : 3;

                totalPrice += ticketPrice;
            }

            return (_ticketList.Count >= 6 && isWeekend && !_isStudentOrder) ? totalPrice * 0.9 : totalPrice;
        }

        public void Export(TicketExportFormat exportFormat)
        {
            switch (exportFormat)
            {
                case TicketExportFormat.JSON:
                    ExportJson();
                    break;
                case TicketExportFormat.PLAINTEXT:
                    ExportPlainText();
                    break;
                default:
                    throw new ArgumentException("Unsupported serialization format");
            }
        }

        private void ExportPlainText() => File.WriteAllText($"./exports/order-{_orderNr}-{DateTime.Now:dd-MM-yyyy}.txt", ToString());

        private void ExportJson()
        {
            var JsonObject = new
            {
                orderNr = _orderNr,
                isStudentOrder = _isStudentOrder,
                price = CalculatePrice().ToString("C2"),
                ticketAmount = _ticketList.Count
            };

            string jsonString = JsonSerializer.Serialize(JsonObject);

            File.WriteAllText($"./exports/order_{_orderNr}_{DateTime.Now:dd_MM_yyyy}.json", jsonString);
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.AppendLine($"Order: {_orderNr}");
            sb.AppendLine($"Student order: {_isStudentOrder}");
            sb.AppendLine($"Price: {CalculatePrice().ToString("C2")}");
            sb.AppendLine($"Ticket amount: {_ticketList.Count}");

            return sb.ToString();
        }
    }
}
