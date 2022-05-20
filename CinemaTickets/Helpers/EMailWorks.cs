using System;
using System.Text;

namespace WebApi.Helpers
{
    public class EMailWorks
    {
        public static void SendActivationEMail(string receiver)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(receiver);
            mail.From = new System.Net.Mail.MailAddress("303carrental@gmail.com");
            mail.Subject = "Welcome to Royal Cinema";
            mail.SubjectEncoding = System.Text.Encoding.UTF8;

            string linkk = "https://localhost:44318/Accounts/Activation?kkk=" + EncryptionWorks.EncrWork(receiver);


            var HtmlBody = new StringBuilder();
            HtmlBody.AppendLine(@"Please click the link below to activate your membership.");
            HtmlBody.AppendLine("<a href=\"" + linkk + "\">ACTIVATION</a>");
            mail.Body = HtmlBody.ToString();
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = System.Net.Mail.MailPriority.Normal;
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("303carrental@gmail.com", "Test123!");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);

            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }

            }
        }

        //public static void SendTicketDetailsEMail(string receiver)
        //{
        //    System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
        //    mail.To.Add(receiver);
        //    mail.From = new System.Net.Mail.MailAddress("303carrental@gmail.com");
        //    mail.Subject = "Welcome to Royal Cinema";
        //    mail.SubjectEncoding = System.Text.Encoding.UTF8;

        //    //string linkk = "https://localhost:44318/Accounts/Activation?kkk=" + EncryptionWorks.EncrWork(receiver);
            

        //    var HtmlBody = new StringBuilder();
        //    HtmlBody.AppendLine(@"Please click the link below to activate your membership.");
        //    HtmlBody.AppendLine("<a href=\"" + linkk + "\">ACTIVATION</a>");
        //    mail.Body = HtmlBody.ToString();
        //    mail.BodyEncoding = System.Text.Encoding.UTF8;
        //    mail.IsBodyHtml = true;
        //    mail.Priority = System.Net.Mail.MailPriority.Normal;
        //    System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
        //    client.Credentials = new System.Net.NetworkCredential("303carrental@gmail.com", "Test123!");
        //    client.Port = 587;
        //    client.Host = "smtp.gmail.com";
        //    client.EnableSsl = true;
        //    try
        //    {
        //        client.Send(mail);

        //    }
        //    catch (Exception ex)
        //    {
        //        Exception ex2 = ex;
        //        string errorMessage = string.Empty;
        //        while (ex2 != null)
        //        {
        //            errorMessage += ex2.ToString();
        //            ex2 = ex2.InnerException;
        //        }

        //    }
        //}
    }
}
