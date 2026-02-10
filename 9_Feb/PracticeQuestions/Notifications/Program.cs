namespace Notifications
{
    public class Program
    {
        public static void Main(string[] args)
        {
            INotifier[] notify = {new EmailNotifier() , new SMSNotifier(), new WhatsAppNotifier()};

            foreach(var ways in notify)
            {
                ways.Send("Heelo");
            }
            
        }
    }
}