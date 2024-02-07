namespace Cinema.Interfaces.PriceRules
{
    public interface ITicketPriceRuleBehaviour
    {
        double Calculate(Order order, MovieTicket movieTicket);
    }
}
