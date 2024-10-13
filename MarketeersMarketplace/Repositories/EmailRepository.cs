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

        public bool SendVerificationMail(string email, string confirmationUrl)
        {
            var body = $@"
                    <h2>Click this link to confirm your email address</h2>
                    <p>{confirmationUrl}</p>";

            return Send(email, "Verify Your Email", body);
        }

        public bool SendContactMail(ContactUsVM contactUsVM)
        {
            var body = $@"
                    <h2>Contact Form Submission</h2>
                    <p><strong>Name:</strong> {contactUsVM.Name}</p>
                    <p><strong>Email:</strong> {contactUsVM.Email}</p>
                    <p><strong>Message:</strong> {contactUsVM.Message}</p>";
           
            return Send(contactUsVM.Email, "Contact Us Form Submission", body);
        }

        private bool Send(string email, string subject, string body)
        {
            string senderEmail = config["SMTP:Sender_Email"];
            string senderPassword = config["SMTP:Sender_Password"];

            try
            {
                MailMessage mailMessage = new MailMessage(senderEmail, email)
                {
                    Subject = subject,
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
