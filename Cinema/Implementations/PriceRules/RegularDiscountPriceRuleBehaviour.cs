using Cinema.Interfaces.PriceRules;
using Cinema.Utils;

namespace Cinema.Implementations.PriceRules
{
    public class RegularDiscountPriceRuleBehaviour : ITicketPriceRuleBehaviour
    {
        public double Calculate(Order order, MovieTicket movieTicket)
        {
            bool isWeekend = Helpers.IsWeekend(movieTicket);

            if (order.GetTicketList().Count >= 6 && isWeekend && !order.GetIsStudentOrder())
            {
                return 0.9;
            }

            return 1;
        }
    }
}
