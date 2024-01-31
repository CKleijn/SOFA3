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

            //loop door tickets
            foreach(MovieTicket ticket in _ticketList)
            {

            }

            // 2de ticket gratis voor studenten (24/7)
            // 2de ticket is gratis voor iedereen (ma t/m do)

            // In weekend groepen NIET-studenten boven 6 personen krijgen 10% korting

            // Premium ticket studenten (2 eu + standaardprijs stoel)
            // Premium ticket niet-studenten (3eu + standaardprijs stoel)
            // ^^ worden in de kortingen verrekend (gratis ticket = ook geen extra kosten; bij 10% korting ook 10% van de extra kosten).

            // Studenten-order is volledig voor studenten (geen mix)


            return 0;
        }

        public void Export(TicketExportFormat exportFormat)
        {
            switch (exportFormat)
            {
                case TicketExportFormat.JSON:
                    string jsonString = JsonSerializer.Serialize(this.ToString());
                    File.WriteAllText($"./exports/order_{this._orderNr}_{DateTime.Now}.json", jsonString);
                    break;
                case TicketExportFormat.PLAINTEXT:
                    File.WriteAllText($"./exports/order_{this._orderNr}_{DateTime.Now}.txt", this.ToString());
                    break;
                default:
                    throw new ArgumentException("Unsupported serialization format");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Order: {this._orderNr}");
            sb.AppendLine($"Price: {this.CalculatePrice}");

            sb.AppendLine("Tickets:");

            foreach (var ticket in this._ticketList)
            {
                sb.AppendLine(ticket.ToString());
            }

            // Voeg overige functies toe

            return sb.ToString();
        }
    }
}
