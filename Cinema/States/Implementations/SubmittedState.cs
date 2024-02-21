using Cinema.Interfaces;
using Cinema.Models;
using Cinema.States.Interfaces;

namespace Cinema.States.Implementations
{
    public class SubmittedState(Order context) : IOrderState, IObserver
    {
        private readonly Order _context = context;

        public void SubmitOrder()
        {
            // do nothing
        }

        public void EditOrder()
        {
            _context.SetState(new EditState(_context));
        }

        public void CancelOrder()
        {
            // cancel order - remove order incl. tickets

            _context.SetState(new CancelledState(_context));
            _context.NotifyObservers("Order is cancelled!");
        }

        public void ProvisionOrder()
        {
            DateTime screeningTime = _context.GetTicketList().ElementAt(0).GetScreeningTime();

            if (DateTime.Now >= screeningTime.AddHours(-24))
            {
                // send notification
                _context.NotifyObservers("You still need to pay ur order!");
                _context.SetState(new ProvisionalState(_context));
            }
        }

        public void PayOrder()
        {
            // alter state whenever use has paid the fee
            _context.NotifyObservers("Order is paid!");
            _context.SetState(new PaidState(_context));
        }

        public void FinalizeOrder()
        {
            // do nothing
        }
    }
}