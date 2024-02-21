using Cinema.Interfaces;

namespace Cinema.Libraries
{
    public class WhatsApp : INotificationLibrary
    {
        public void SendMessage(string message) => Console.WriteLine($"Type: WhatsApp, Content: {message}");
    }
}
