using Cinema.Interfaces;

namespace Cinema.Libraries
{
    public class Mail : INotificationLibrary
    {
        public void SendMessage(string message) => Console.WriteLine($"Type: Mail, Content: {message}");
    }
}
