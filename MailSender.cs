using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Net;
using System.Net.Mail;
namespace NoExit
{
    public class MailSender
    {

/// <summary>
/// Отправка письма на почтовый ящик C# mail send
/// </summary>
/// <param name="smtpServer">Имя SMTP-сервера</param>
/// <param name="from">Адрес отправителя</param>
/// <param name="password">пароль к почтовому ящику отправителя</param>
/// <param name="mailto">Адрес получателя</param>
/// <param name="caption">Тема письма</param>
/// <param name="message">Сообщение</param>
/// <param name="attachFile">Присоединенный файл</param>
public static void SendMail(string message, string caption = "Новая заявка от Выхода Нет!")
    {
            var smtpServer = "smtp.mail.com";
            var from = "genna9393@mail.ru";
            var password = "mail333";
            var mailto = "gennadiy9331@gmail.com";
            

            try
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(mailto));
            mail.Subject = caption;
            mail.Body = message;
            
            SmtpClient client = new SmtpClient();
            client.Host = smtpServer;
            client.Port = 465;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(from.Split('@')[0], password);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.SendMailAsync(mail);
            mail.Dispose();
        }
        catch (Exception e)
        {
            throw new Exception("Mail.Send: " + e.Message);
        }
    }
}
}