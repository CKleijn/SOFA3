using System.Text;
using Cinema.Interfaces.Export;
using Cinema.Interfaces.PriceRules;

namespace Cinema.Models
{
    public class Order(int orderNr, bool isStudentOrder)
    {
        private readonly int _orderNr = orderNr;
        private readonly bool _isStudentOrder = isStudentOrder;
        private readonly List<MovieTicket> _ticketList = new();

        private readonly List<ITicketPriceRuleBehaviour> _priceRulesBehaviours = new();
        private readonly List<IExportBehaviour> _exportBehaviours = new();

        public void AddPriceRule(ITicketPriceRuleBehaviour behaviour) => _priceRulesBehaviours.Add(behaviour);

        public void AddExportType(IExportBehaviour behaviour) => _exportBehaviours.Add(behaviour);

        public int GetOrder() => _orderNr;

        public bool GetIsStudentOrder() => _isStudentOrder;

        public List<MovieTicket> GetTicketList() => _ticketList;

        public void AddSeatReservation(MovieTicket ticket) => _ticketList.Add(ticket);

        public double CalculatePrice()
        {
            double totalPrice = 0;

            for (var i = 0; i < _ticketList.Count; i++)
            {
                MovieTicket ticket = _ticketList[i];
                double ticketPrice = ticket.GetPrice();

                foreach (ITicketPriceRuleBehaviour priceRule in _priceRulesBehaviours)
                    if (ticketPrice > 0)
                        ticketPrice = priceRule.Calculate(this, ticket, ticketPrice);

                totalPrice += ticketPrice;
            }

            return totalPrice;
        }

        public void Export()
        {
            foreach (IExportBehaviour exportType in _exportBehaviours)
                exportType.Export(this);
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
