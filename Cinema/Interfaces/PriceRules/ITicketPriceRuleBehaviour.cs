using Cinema.Models;

namespace Cinema.Interfaces.PriceRules
{
    public interface ITicketPriceRuleBehaviour
    {
        double Calculate(Order order, MovieTicket movieTicket, double ticketPrice);
    }
}
