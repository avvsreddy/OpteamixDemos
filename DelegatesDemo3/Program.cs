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
            acc1.Deposit(1000);
            Console.WriteLine(acc1.Balance);
            acc1.Withdraw(500);
            Console.WriteLine(acc1.Balance);

        }
    }


    public class Account
    {
        public int Balance { get; private set; }

        private NotificationService notificationService = new NotificationService();

        public void Deposit(int amount)
        {
            Balance += amount;
            // write a logic to send notification to the customer about the deposit
            notificationService.SendMail($"A deposit of {amount} has been made to your account.");
            notificationService.SendSMS($"A deposit of {amount} has been made to your account.");
        }



        

        public void Withdraw(int amount)
        {
            Balance -= amount;
            notificationService.SendMail($"A withdrawal of {amount} has been made from your account.");
            notificationService.SendSMS($"A withdrawal of {amount} has been made from your account.");
        }


    }


    class NotificationService
    {
        public void SendMail(string msg)
        {
            Console.WriteLine($"Mail: {msg} ");
        }

        public void SendSMS(string msg)
        {
            Console.WriteLine($"SMS: {msg} ");
        }
    }
}
