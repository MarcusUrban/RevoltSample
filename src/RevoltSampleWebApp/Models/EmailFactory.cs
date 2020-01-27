using System.Net.Mail;


namespace RevoltSampleWebApp.Models
{
    public class EmailFactory
    {

        SmtpClient smtpClient;

        public EmailFactory()
        {
            smtpClient = new SmtpClient("smtp.forpsi.com", 465);

            smtpClient.Credentials = new System.Net.NetworkCredential("revolt_test@flex-cast.cz", "Revolt123");
            smtpClient.UseDefaultCredentials = false;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.EnableSsl = true;
        }

        private string CreateHtmlMessage(string ID1, string ID2)
        {
            return "<a href=\"https://localhost/newpage/" + ID1 + "/" + ID2 + "\" >LINK</a>" ;
        }

        public void SendEmail(string recipeint, string ID1, string ID2)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("revolt_test@flex-cast.cz", "RevoltTestWebsiteMailBot");
            mail.To.Add(new MailAddress(recipeint));
            mail.Subject = "RevoltTestEmail";
            mail.Body = CreateHtmlMessage(ID1, ID2);

            smtpClient.Send(mail);
        }

    }
}
