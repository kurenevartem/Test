using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace EmailService

{
    [ServiceContract]
    public interface IEmailService
    {
        [OperationContract]
        bool SendEmail(string emailTo, string subject, string body, bool isBodyHtml);
    }

}