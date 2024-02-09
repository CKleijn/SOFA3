using Cinema.Models;
using Cinema.States.Interfaces;

namespace Cinema.States.Implementations
{
    public class EditState(Order context) : IOrderState
    {
        private readonly Order _context = context;

        public void SubmitOrder()
        {
            if(_context.GetTicketList().Count > 0)
                _context.SetState(new SubmittedState(_context));

            // throw error
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