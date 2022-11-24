using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using Aspose.Email.Clients;
using Aspose.Email.Clients.Google;
using TestApp1;
using EmailService;

public class Send
{
    EmailService.EmailService emailClient;
    TestApp1.ApplicationContext DB = new TestApp1.ApplicationContext();
    public Send()
    {
        emailClient = new EmailService.EmailService();

        List<DataDBs> dataDB = DB.DataDBs.ToList();
        string email = DB.Email.ToString();
        int count = dataDB.Count;
        int c = 50;

        try
        {
            if (count >= c)
            {
                bool send = emailClient.SendEmail("kurenevartem@yandex.ru", "WCF Mail Test", "Сделано 50 записей", true);
                c += 50;
            }
        }

        catch (FaultException exception)

        {

            MessageBox.Show(exception.Message);

        }
    }
}

           