using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;

namespace DelegatesDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // open an account
            Account acc1 = new Account();
            acc1.notify += NotificationService.SendMail; // subscribe to the notification
            //acc1.Subscribe(NotificationService.SendSMS); // subscribe to the notification
            acc1.notify += NotificationService.SendSMS; // subscribe to the notification
            //acc1.notify -= NotificationService.SendSMS; // unsubscribe to the notification
            acc1.notify += NotificationService.SendWhatsApp; // subscribe to the notification
            //acc1.Deposit(1000);
            acc1.notify("A deposit of $1000000000000 has been made to your account.");
            Console.WriteLine(acc1.Balance);
            //acc1.Withdraw(500);
            Console.WriteLine(acc1.Balance);

        }
    }


    public class Account
    {
        public int Balance { get; private set; }

        //private NotificationService notificationService = new NotificationService();

        public event Notify notify = null; // new Notify(new NotificationService().SendMail);

        //public void Subscribe(Notify notifyMethod)
        //{
        //    notify += notifyMethod;
        //}

        //public void Unsubscribe(Notify notifyMethod)
        //{
        //    notify -= notifyMethod;
        //}

        public void Deposit(int amount)
        {
            Balance += amount;
            // write a logic to send notification to the customer about the deposit
            //notificationService.SendMail($"A deposit of {amount} has been made to your account.");
            //notificationService.SendSMS($"A deposit of {amount} has been made to your account.");
            notify?.Invoke($"A deposit of {amount} has been made to your account.");
        }



        

        public void Withdraw(int amount)
        {
            Balance -= amount;
            //notificationService.SendMail($"A withdrawal of {amount} has been made from your account.");
            //notificationService.SendSMS($"A withdrawal of {amount} has been made from your account.");
            notify?.Invoke($"A withdrawal of {amount} has been made from your account.");
        }


    }


    public delegate void Notify(string msg);


    class NotificationService
    {
        public static void SendMail(string msg)
        {
            Console.WriteLine($"Mail: {msg} ");
        }

        public static void SendSMS(string msg)
        {
            Console.WriteLine($"SMS: {msg} ");
        }

        public static void SendWhatsApp(string msg)
        {
            Console.WriteLine($"WhatsApp: {msg} ");
        }
    }
}
