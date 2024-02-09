using Cinema.Models;
using Cinema.States.Interfaces;

namespace Cinema.States.Implementations
{
    public class PaidState(Order context) : IOrderState
    {
        private readonly Order _context = context;

        public void SubmitOrder()
        {
            // do nothing
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
            // send tickets and set ticket status on completed

            _context.SetState(new FinalizedState(_context));
        }
    }
}