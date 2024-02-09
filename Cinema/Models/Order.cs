using System.Text.Json;
using System.Text;
using Cinema.Enums;
using Cinema.States.Interfaces;
using Cinema.States.Implementations;

namespace Cinema.Models
{
    public class Order
    {
        private readonly int _orderNr;
        private readonly bool _isStudentOrder;
        private readonly List<MovieTicket> _ticketList;
        private IOrderState _state;

        public Order(int orderNr, bool isStudentOrder)
        {
            _orderNr = orderNr;
            _isStudentOrder = isStudentOrder;
            _ticketList = new();
            _state = new InitialState(this);
        }

        public IOrderState GetState() => _state;

        public IOrderState SetState(IOrderState state) => _state = state;

        public int GetOrder() => _orderNr;

        public List<MovieTicket> GetTicketList() => _ticketList;

        public void AddSeatReservation(MovieTicket ticket) => _ticketList.Add(ticket);

        public void SubmitOrder() => _state.SubmitOrder();

        public void EditOrder() => _state.EditOrder();

        public void CancelOrder() => _state.CancelOrder();

        public void ProvisionOrder() => _state.ProvisionOrder();

        public void PayOrder() => _state.PayOrder();

        public void FinalizeOrder() => _state.FinalizeOrder();

        public double CalculatePrice()
        {
            double totalPrice = 0;
            bool isWeekend = false;

            for (var i = 0; i < _ticketList.Count; i++)
            {
                MovieTicket ticket = _ticketList[i];
                int ticketNumber = i + 1;
                var dayOfWeek = ticket.GetScreeningTime().DayOfWeek;
                isWeekend = dayOfWeek == DayOfWeek.Friday || dayOfWeek == DayOfWeek.Saturday || dayOfWeek == DayOfWeek.Sunday;
                double ticketPrice = ticket.GetPrice();

                if (ticketNumber % 2 == 0 && (_isStudentOrder || !isWeekend))
                    continue;

                if (ticket.IsPremiumTicket())
                    ticketPrice += _isStudentOrder ? 2 : 3;

                totalPrice += ticketPrice;
            }

            return _ticketList.Count >= 6 && isWeekend && !_isStudentOrder ? totalPrice * 0.9 : totalPrice;
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

        private void ExportPlainText() => File.WriteAllText($"./Exports/order-{_orderNr}-{DateTime.Now:dd-MM-yyyy}.txt", ToString());

        private void ExportJson()
        {
            var jsonObject = new
            {
                orderNr = _orderNr,
                isStudentOrder = _isStudentOrder,
                price = CalculatePrice().ToString("C2"),
                ticketAmount = _ticketList.Count
            };

            File.WriteAllText($"./Exports/order_{_orderNr}_{DateTime.Now:dd_MM_yyyy}.json", JsonSerializer.Serialize(jsonObject));
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
