using Cinema.Interfaces;

namespace Cinema.Adapters
{
    public class NotificationLibraryAdapter(INotificationLibrary notificationLibrary) : INotification
    {
        private readonly INotificationLibrary _notificationLibrary = notificationLibrary;

        public void SendNotification(string message) => _notificationLibrary.SendMessage(message);
    }
}