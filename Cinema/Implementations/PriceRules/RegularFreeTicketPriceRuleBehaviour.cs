using Cinema.Interfaces.PriceRules;
using Cinema.Utils;

namespace Cinema.Implementations.PriceRules
{
    public class FreeTicketPriceRuleBehaviour : ITicketPriceRuleBehaviour
    {
        public double Calculate(Order order, MovieTicket movieTicket)
        {
            bool isWeekend = Helpers.IsWeekend(movieTicket);

            int ticketIndex = order.GetTicketList().IndexOf(movieTicket) + 1;

            if (ticketIndex % 2 == 0 && (order.GetIsStudentOrder() || !isWeekend))
            {
                return 0;
            }

            return movieTicket.GetPrice();
        }
    }
}
