using System;
using System.IO;
using System.Xml.Serialization;
using System.Text.Json;
using System.Text;

namespace Cinema
{
    public class Order
    {
        private int _orderNr;
        private bool _isStudentOrder;
        private IList<MovieTicket> _ticketList;

        public Order(int orderNr, bool isStudentOrder)
        {
            _orderNr = orderNr;
            _isStudentOrder = isStudentOrder;
            _ticketList = new List<MovieTicket>();
        }

        public int GetOrder() => this._orderNr;

        public void AddSeatReservation(MovieTicket ticket) => this._ticketList.Add(ticket);

        public double CalculatePrice()
        {
            double price = 0;
            bool weekendOrder = false;
            
            for(var i = 0; i < _ticketList.Count; i++)
            {
                MovieTicket ticket = _ticketList[i];
                int dayOfWeek = (int)ticket.GetScreeningTime().DayOfWeek;
                double baseTicketPrice = ticket.GetPrice();
                
                if((i + 1) % 2 == 0 && (_isStudentOrder || dayOfWeek >= 1 && dayOfWeek <= 4))
                    continue;
                
                if(dayOfWeek == 0 || dayOfWeek >= 5)
                    weekendOrder = true;

                price += ticket.IsPremiumTicket() ? ( _isStudentOrder ? (baseTicketPrice += 2) : (baseTicketPrice += 3) ) : baseTicketPrice;
            }
            
            return _ticketList.Count >= 6 && weekendOrder && !_isStudentOrder ? price *= 0.9 : price;
        }

        public void Export(TicketExportFormat exportFormat)
        {
            switch (exportFormat)
            {
                case TicketExportFormat.JSON:
                    string jsonString = JsonSerializer.Serialize(ToString());
                    File.WriteAllText($"./exports/order_{_orderNr}_{DateTime.Now:dd/MM/yyyy}.json", jsonString);
                    break;
                case TicketExportFormat.PLAINTEXT:
                    File.WriteAllText($"./exports/order-{_orderNr}-{DateTime.Now:dd/MM/yyyy}.txt", ToString());
                    break;
                default:
                    throw new ArgumentException("Unsupported serialization format");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Order: {_orderNr}");
            sb.AppendLine($"Price: {this.CalculatePrice().ToString("C2")}\n");

            sb.AppendLine("Tickets:\n");

            for (var i = 0; i < _ticketList.Count; i++)
            {
                sb.AppendLine($"Ticket {i + 1}:");
                sb.AppendLine(_ticketList[i].ToString());
            }

            return sb.ToString();
        }
    }
}
