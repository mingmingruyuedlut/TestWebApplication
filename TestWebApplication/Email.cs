﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace TestWebApplication
{
    public class Email
        {
            #region Send email

            public void SendMail(string fromAddress, List<string> toAddress, string subject, string body, Dictionary<string, string> LinkedResourcesDic)
            {
                SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["MailHost"]);

                MailMessage message = new MailMessage();
                message.From = new MailAddress(fromAddress);
                foreach (string s in toAddress)
                {
                    message.To.Add(s);
                }

                message.Subject = subject;
                message.SubjectEncoding = Encoding.UTF8;

                message.Body += body;
                message.BodyEncoding = Encoding.UTF8;

                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;

                client.EnableSsl = true;
                client.UseDefaultCredentials = false;

                NetworkCredential myCredentials = new NetworkCredential(fromAddress, ConfigurationManager.AppSettings["FromAddressPwd"]);
                client.Credentials = myCredentials;

                client.Send(message);
            }


            public static string[] TestEmailAddress()
            {
                //string[] mailAddress = { "patrick.zhong@fabricgroup.com.au", "cass.fan@fabricgroup.com.au", "eric.sun@fabricgroup.com.au", "water.li@fabricgroup.com.au", "ken.cliche@fabricgroup.com.au", "lachlan.greed@fabricgroup.com.au" };
                //string[] mailAddress = { "eric.sun@fabricgroup.com.au" };
                string[] mailAddress = { "patrick.zhong@fabricgroup.com.au", "cass.fan@fabricgroup.com.au", "eric.sun@fabricgroup.com.au" };
                return mailAddress;
            }

            #endregion
        }
}