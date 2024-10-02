using System.Net.Mail;
using System.Net;
using MarketeersMarketplace.ViewModels;
using MarketeersMarketplace.Interfaces;

namespace MarketeersMarketplace.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly IConfiguration config;

        public EmailRepository(IConfiguration config)
        {
            this.config = config;
        }

        public bool SendMail(ContactUsVM contactUsVM)
        {
            string senderEmail = config["SMTP:Sender_Email"];
            string senderPassword = config["SMTP:Sender_Password"];

            try
            {
                var body = $@"
                    <h2>Contact Form Submission</h2>
                    <p><strong>Name:</strong> {contactUsVM.Name}</p>
                    <p><strong>Email:</strong> {contactUsVM.Email}</p>
                    <p><strong>Message:</strong> {contactUsVM.Message}</p>";

                MailMessage mailMessage = new MailMessage(senderEmail, contactUsVM.Email)
                {
                    Subject = "Contact Us Form Submission",
                    IsBodyHtml = true,
                    Body = body
                };

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(senderEmail, senderPassword),
                    EnableSsl = true
                })
                {
                    smtpClient.Send(mailMessage);
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }
}
