using Cinema.Models;
using Cinema.States.Interfaces;

namespace Cinema.States.Implementations
{
    public class SubmittedState(Order context) : IOrderState
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
        }

        public void ProvisionOrder()
        {
            DateTime screeningTime = _context.GetTicketList().First().GetScreeningTime();

            if (DateTime.Now >= screeningTime.AddHours(-24))
            {
                // send notification

                _context.SetState(new ProvisionalState(_context));
            }
        }

        public void PayOrder()
        {
            // alter state whenever use has paid the fee

            _context.SetState(new PaidState(_context));
        }

        public void FinalizeOrder()
        {
            // do nothing
        }
    }
}