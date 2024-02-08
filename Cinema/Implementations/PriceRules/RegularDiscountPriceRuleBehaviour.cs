using Cinema.Interfaces.PriceRules;
using Cinema.Models;
using Cinema.Utils;

namespace Cinema.Implementations.PriceRules
{
    public class RegularDiscountPriceRuleBehaviour : ITicketPriceRuleBehaviour
    {
        public double Calculate(Order order, MovieTicket movieTicket, double ticketPrice)
        {
            bool isWeekend = Helpers.IsWeekend(movieTicket.GetScreeningTime().DayOfWeek);

            if (order.GetTicketList().Count >= 6 && isWeekend && !order.GetIsStudentOrder())
                return ticketPrice * 0.9;

            return ticketPrice;
        }
    }
}
