using Cinema.Interfaces.PriceRules;
using Cinema.Models;

namespace Cinema.Implementations.PriceRules
{
    public class RegularPremiumFeePriceRuleBehaviour : ITicketPriceRuleBehaviour
    {
        public double Calculate(Order order, MovieTicket movieTicket, double ticketPrice)
        {
            if (movieTicket.IsPremiumTicket())
                return ticketPrice + (order.GetIsStudentOrder() ? 2 : 3);

            return ticketPrice;
        }
    }
}
