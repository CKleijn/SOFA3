using Cinema.Interfaces.PriceRules;

namespace Cinema.Implementations.PriceRules
{
    public class RegularPremiumFeePriceRuleBehaviour : ITicketPriceRuleBehaviour
    {
        public double Calculate(Order order, MovieTicket movieTicket)
        {
            if (movieTicket.IsPremiumTicket())
            {
                return order.GetIsStudentOrder() ? 2 : 3;
            }

            return 0;
        }
    }
}
