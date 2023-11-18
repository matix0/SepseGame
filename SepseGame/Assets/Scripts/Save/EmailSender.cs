using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class EmailSender : MonoBehaviour
{
    public void sendEmail()
    {
        MailMessage mail = new MailMessage();
        SmtpClient SmtpServer = new SmtpClient(); //smtp-mail.outlook.com, 587
        SmtpServer.Timeout = 5000;
        SmtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
        SmtpServer.UseDefaultCredentials = false;
        SmtpServer.Port = 587;

        mail.From = new MailAddress("sepsegamerelatorio@outlook.com");
        mail.To.Add(new MailAddress("sepsegamerelatorio@outlook.com"));

        mail.Subject = "TESTE";
        mail.Body = "teste.";

        SmtpServer.Credentials = new System.Net.NetworkCredential();
    }
}
