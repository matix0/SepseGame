using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.ComponentModel;
using System.Net.Mail;
using System.Linq;
using TMPro;
using UnityEngine.UI;
using System.Net.Mime;

public class EmailSend : MonoBehaviour
{
    public static int nVezes0;
    public static int nVezes1;
    public static int nVezes2;
    public static int nVezes3;
    public static int nVezes4;
    public static int nVezes5;
    public static int nVezes6;
    public static int nVezes7;
    public static int nVezes8;
    public static int nVezes9;
    public static int nVezes10;
    public static int nVezes11;
    public static int nVezes12;

    public static string titleName;
    public static string legendaEmail;
    public static string resultado0R;
    public static string resultado1R;
    public static string resultado2R;
    public static string resultado3R;
    public static string resultado4R;
    public static string resultado5R;
    public static string resultado6R;
    public static string resultado7R;
    public static string resultado8R;
    public static string resultado9R;
    public static string resultado10R;
    public static string resultado11R;
    public static string resultado12R;
    public Estetica pack;

    // Update is called once per frame
    public void SendEmail()
    {
        titleName = "Relatorio de desempenho - " + Login.nome;
        float final_time = GameObject.Find("Timer").GetComponent<TimerObj>().time_elapsed;
        float minutes = Mathf.FloorToInt(final_time / 60);
        float seconds = Mathf.FloorToInt(final_time % 60);

        // Linhas referentes a "conexao" com o smtp de envio
        SmtpClient client = new SmtpClient("smtp-mail.outlook.com", 587);

        //credenciamento para permitir o envio
        client.Credentials = new System.Net.NetworkCredential(
            "sepsegamerelatorio@outlook.com",
            "sepserelatorio1");
        client.EnableSsl = true;

        // Definir quem envia o email e o nome do email que sera enviado
        MailAddress from = new MailAddress(
            "sepsegamerelatorio@outlook.com",
            titleName,
            System.Text.Encoding.UTF8);

        // Definir quem vai receber o email
        MailAddress to = new MailAddress("sepsegamerelatorio@outlook.com");
        MailMessage message = new MailMessage(from, to);
        message.Body = $"\nNome: {Login.nome}" +
            $"\nCPF: {Login.cpf}" +
            $"\nTEMPO DE JOGO: {minutes} minutos e {seconds} segundos.\n\n" +
            //$"Legenda para leitura dos casos:\n {legendaEmail}" +
            $"\r\nCaso 1 (jogou {nVezes0} vez(es)): \n{resultado0R}\n\n" +
            $"\r\nCaso 2 (jogou {nVezes1} vez(es)): \n{resultado1R}\n\n" +
            $"\r\nCaso 3 (jogou {nVezes2} vez(es)): \n{resultado2R}\n\n" +
            $"\r\nCaso 4 (jogou {nVezes3} vez(es)): \n{resultado3R}\n\n" +
            $"\r\nCaso 5 (jogou {nVezes4} vez(es)): \n{resultado4R}\n\n" +
            $"\r\nCaso 6 (jogou {nVezes5} vez(es)): \n{resultado5R}\n\n" +
            $"\r\nCaso 7 (jogou {nVezes6} vez(es)): \n{resultado6R}\n\n" +
            $"\r\nCaso 8 (jogou {nVezes7} vez(es)): \n{resultado7R}\n\n" +
            $"\r\nCaso 9 (jogou {nVezes8} vez(es)): \n{resultado8R}\n\n" +
            $"\r\nCaso 10 (jogou {nVezes9} vez(es)): \n{resultado9R}\n\n" +
            $"\r\nCaso 11 (jogou {nVezes10} vez(es)): \n{resultado10R}\n\n" +
            $"\r\nCaso 12 (jogou {nVezes11} vez(es)): \n{resultado11R}\n\n" +
            $"\r\nCaso 13 (jogou {nVezes12} vez(es)): \n{resultado12R}\n\n";

        message.BodyEncoding = System.Text.Encoding.UTF8;
        message.Subject = titleName;
        message.SubjectEncoding = System.Text.Encoding.UTF8;


        // Metodos para envio e callback.
        client.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
        string userState = titleName;
        client.SendAsync(message, userState);
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
