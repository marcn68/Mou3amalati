using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;

namespace Mou3amalati.BLL
{
    public class HomeManager
    {
        public void EmailSender(string id, string email, string password)
        {
            MimeMessage message = new MimeMessage();
            MailboxAddress from = new MailboxAddress("admin", "mou3amalati@gmail.com");
            message.From.Add(from);

            MailboxAddress to = new MailboxAddress("User",email);
            message.To.Add(to);

            message.Subject = "Request Account";

            BodyBuilder bodyBuilder = new BodyBuilder();
            bodyBuilder.HtmlBody = "<h1>Welcome to Mou3amalati</h1>" +
                "<p> You will find here your credentials for Mou3amalati</p>" +
                "<p> Username: " + id + "</p><br/>" +
                "<p> Password: " + password + "</p><br/>";
            bodyBuilder.TextBody = "Welcome to Mou3amalati";

            message.Body = bodyBuilder.ToMessageBody();

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 465, true);
            client.Authenticate("mou3amalati", "Mou3amalati@123");

            client.Send(message);
            client.Disconnect(true);
            client.Dispose();
        }

        public string CreateRandomPassword(int length = 15)
        {
            // Create a string of characters, numbers, special characters that allowed in the password  
            string validChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-";
            Random random = new Random();

            // Select one random character at a time from the string  
            // and create an array of chars  
            char[] chars = new char[length];
            for (int i = 0; i < length; i++)
            {
                chars[i] = validChars[random.Next(0, validChars.Length)];
            }
            return new string(chars);
        }
    }
}
