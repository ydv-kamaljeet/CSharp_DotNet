namespace Notifications
{
    public interface INotifier
    {
        public void Send(string msg);
    }

    public class EmailNotifier : INotifier
    {
        public override void Send(string msg)
        {
            Console.WriteLine($"Email : {msg}");
        }
    }
    public class SMSNotifier : INotifier
    {
        public override void Send(string msg)
        {
            Console.WriteLine($"SMS : {msg}");
        }
    }
    public class WhatsAppNotifier : INotifier
    {
        public override void Send(string msg)
        {
            Console.WriteLine($"WhatsApp : {msg}");
        }
    }
}