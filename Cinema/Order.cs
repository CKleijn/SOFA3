using System.Text;
using Cinema.Interfaces.Export;
using Cinema.Interfaces.PriceRules;

namespace Cinema
{
    public class Order(int orderNr, bool isStudentOrder, IExportBehaviour exportBehaviour, ITicketPriceRuleBehaviour freeTicketRuleBehaviour, ITicketPriceRuleBehaviour premiumTicketFeeRuleBehaviour, ITicketPriceRuleBehaviour discountRuleBehaviour)
    {
        private readonly int _orderNr = orderNr;
        private readonly bool _isStudentOrder = isStudentOrder;
        private readonly List<MovieTicket> _ticketList = new();

        private IExportBehaviour _exportBehaviour = exportBehaviour;
        private ITicketPriceRuleBehaviour _freeTicketRuleBehaviour = freeTicketRuleBehaviour;
        private ITicketPriceRuleBehaviour _premiumTicketFeeRuleBehaviour = premiumTicketFeeRuleBehaviour;
        private ITicketPriceRuleBehaviour _discountRuleBehaviour = discountRuleBehaviour;

        public void SetExportBehaviour(IExportBehaviour behaviour) => _exportBehaviour = behaviour;
        public void SetFreeTicketRule(ITicketPriceRuleBehaviour behaviour) => _freeTicketRuleBehaviour = behaviour;
        public void SetPremiumTicketFeeRule(ITicketPriceRuleBehaviour behaviour) => _premiumTicketFeeRuleBehaviour = behaviour;
        public void SetDiscountRule(ITicketPriceRuleBehaviour behaviour) => _discountRuleBehaviour = behaviour;

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

                // Check free ticket
                if (_freeTicketRuleBehaviour.Calculate(this, ticket) == 0) continue;

                // Check premium ticket
                ticketPrice += _premiumTicketFeeRuleBehaviour.Calculate(this, ticket);

                // Check discount
                ticketPrice *= _discountRuleBehaviour.Calculate(this, ticket);

                totalPrice += ticketPrice;
            }

            return totalPrice;
        }

        public void Export() => _exportBehaviour.Export(this);

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
