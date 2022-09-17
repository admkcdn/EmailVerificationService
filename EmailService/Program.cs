using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add("example@hotmail.com");     //Please enter the e-mail address to be sent.
                mail.Subject = "Subject";


                Random random = new Random();
                mail.Body = "Your password reset code: " + random.Next(100000, 999999);

                mail.Priority = MailPriority.Normal;

                //if you want to add attachment add the path of the file here
                mail.Attachments.Add(new Attachment(""));

                SmtpClient smtp = new SmtpClient();
                smtp.Credentials = new NetworkCredential("senderEmail", "senderPassword");


                smtp.Port = 587;    //this port address is the port served by microsoft services
                smtp.Host = "smtp.office365.com";
                //https://support.microsoft.com/en-us/office/pop-imap-and-smtp-settings-8361e398-8af4-4e97-b147-6c6c4ac95353

                smtp.EnableSsl = true;

                smtp.Send(mail);

                Console.WriteLine("Email sent successfully!");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
