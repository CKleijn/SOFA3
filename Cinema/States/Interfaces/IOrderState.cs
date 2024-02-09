using Cinema.Models;

namespace Cinema.States.Interfaces
{
    public interface IOrderState
    {
        void SubmitOrder();
        void EditOrder();
        void CancelOrder();
        void ProvisionOrder();
        void PayOrder();
        void FinalizeOrder();
    }
}