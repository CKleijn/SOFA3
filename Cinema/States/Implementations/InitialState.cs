using Cinema.Interfaces;
using Cinema.Models;
using Cinema.States.Interfaces;

namespace Cinema.States.Implementations
{
    public class InitialState(Order context) : IOrderState, IObserver
    {
        private readonly Order _context = context;

        public void SubmitOrder()
        {
            if(_context.GetTicketList().Count > 0)
            {
                _context.NotifyObservers("Order is submitted!");
                _context.SetState(new SubmittedState(_context));
            }
        }

        public void EditOrder()
        {
            // do nothing
        }

        public void CancelOrder()
        {
            // do nothing
        }

        public void ProvisionOrder()
        {
            // do nothing
        }

        public void PayOrder()
        {
            // do nothing
        }

        public void FinalizeOrder()
        {
            // do nothing
        }
    }
}
