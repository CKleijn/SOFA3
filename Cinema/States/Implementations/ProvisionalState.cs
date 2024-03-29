﻿using Cinema.Models;
using Cinema.States.Interfaces;

namespace Cinema.States.Implementations
{
    public class ProvisionalState(Order context) : IOrderState
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
            // cancel order - remove order incl. tickets

            _context.SetState(new CancelledState(_context));
        }

        public void ProvisionOrder()
        {
            DateTime screeningTime = _context.GetTicketList().ElementAt(0).GetScreeningTime();

            if (DateTime.Now >= screeningTime.AddHours(-12))
                CancelOrder();
        }

        public void PayOrder()
        {
            // alter state

            _context.SetState(new PaidState(_context));
        }

        public void FinalizeOrder()
        {
            // do nothing
        }
    }
}