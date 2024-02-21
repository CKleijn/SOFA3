using Cinema.Interfaces;

namespace Cinema.Libraries
{
    public class Sms : INotificationLibrary
    {
        public void SendMessage(string message) => Console.WriteLine($"Type: SMS, Content: {message}");
    }
}
