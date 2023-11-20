using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.ComponentModel;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

public class EmailSender : MonoBehaviour
{
    public void sendEmail()
    {
        SmtpClient SmtpServer = new SmtpClient("smtp-mail.outlook.com", 587);
        SmtpServer.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
        SmtpServer.EnableSsl = true;

        MailMessage mail = new MailMessage();
        mail.From = new MailAddress("sepsegamerelatorio@outlook.com");
        mail.To.Add(new MailAddress("sepsegamerelatorio@outlook.com"));

        mail.Subject = "TESTE";
        mail.Body = "teste.";

        SmtpServer.Credentials = new System.Net.NetworkCredential("sepsegamerelatorio@outlook.com", "sepserelatorio1");
        SmtpServer.SendAsync(mail, "Primeiro Teste");
    }

    private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
    {
        // Get the unique identifier for this asynchronous operation.
        string token = (string)e.UserState;

        if (e.Cancelled)
        {
            Debug.Log("Send canceled " + token);
        }
        if (e.Error != null)
        {
            Debug.Log("[ " + token + " ] " + " " + e.Error.ToString());
        }
        else
        {
            Debug.Log("Message sent.");
        }
    }
}
