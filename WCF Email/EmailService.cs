using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Net.Mail;
using System.Net;


namespace EmailService

{
    public class EmailService : IEmailService

    {
        public bool SendEmail(string emailTo, string subject, string body, bool isBodyHtml)

        {
            if (string.IsNullOrEmpty(emailTo))
            {
                return false;
            }
            using (SmtpClient smtpClient = new SmtpClient())
            {
                using (MailMessage message = new MailMessage())
                {
                    message.Subject = subject == null ? "" : subject;

                    message.Body = body == null ? "" : body;

                    message.IsBodyHtml = isBodyHtml;

                    message.To.Add(new MailAddress(emailTo));

                    try
                    {
                        smtpClient.Send(message);
                        return true;
                    }
                    catch (Exception exception)
                    {
                        throw new FaultException(exception.Message);
                    }
                }
            }
        }
    }
}