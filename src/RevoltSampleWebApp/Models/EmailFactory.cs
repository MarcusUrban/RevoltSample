using System;
using System.Net.Mail;


namespace RevoltSampleWebApp.Models
{
    public class EmailFactory
    {
        SmtpClient mySmtpClient;

        public EmailFactory()
        {
            mySmtpClient = new SmtpClient("smtp.seznam.cz", 25);
            mySmtpClient.EnableSsl = false;

            // set smtp-client with basicAuthentication
            mySmtpClient.UseDefaultCredentials = false;
            System.Net.NetworkCredential basicAuthenticationInfo = new
               System.Net.NetworkCredential("revolttest@seznam.cz", "testrevolt123");
            mySmtpClient.Credentials = basicAuthenticationInfo;
        }

        private string CreateHtmlMessage(string ID1, string ID2)
        {
            return "<a href=\"https://localhost:44369/newpage/" + ID1 + "/" + ID2 + "\" >LINK</a>" ;
        }

        public void SendEmail(string recipeint, string ID1, string ID2)
        {
            try
            {
                // add from,to mailaddresses
                MailAddress from = new MailAddress("revolttest@seznam.cz", "RevoltTest");
                MailAddress to = new MailAddress(recipeint, "Revolt account name");
                MailMessage myMail = new System.Net.Mail.MailMessage(from, to);

                // add ReplyTo
                MailAddress replyTo = new MailAddress("revolttest@seznam.cz");
                myMail.ReplyToList.Add(replyTo);

                // set subject and encoding
                myMail.Subject = "RevoltTest - Link message";
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;

                // set body-message and encoding
                myMail.Body = CreateHtmlMessage(ID1, ID2);
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                // text or html
                myMail.IsBodyHtml = true;

                mySmtpClient.Send(myMail);
            }

            catch (SmtpException ex)
            {
                throw new ApplicationException("SmtpException has occured: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
