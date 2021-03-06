﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("From Email Address: " + ConfigurationManager.AppSettings["FromAddress"]);
                Console.WriteLine("Mail Host: " + ConfigurationManager.AppSettings["MailHost"]);
                Console.WriteLine("Mail Port: " + ConfigurationManager.AppSettings["MailPort"]);
                Console.WriteLine("Mail Account Name: " + ConfigurationManager.AppSettings["MailAccountName"]);
                Console.WriteLine("Mail Account Pwd: " + ConfigurationManager.AppSettings["FromAddressPwd"]);

                SendMail(ConfigurationManager.AppSettings["FromAddress"], TestEmailAddress().ToList(), "Test", "Just Test.", null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadKey();
            }
        }


        public static void SendMail(string fromAddress, List<string> toAddress, string subject, string body, Dictionary<string, string> LinkedResourcesDic)
        {
            SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["MailHost"]);

            //SmtpClient client = new SmtpClient();
            //client.Host = "smtp.interactive.com.au";
            client.Timeout = 300000;
            
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

            //client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Port = Int32.Parse(ConfigurationManager.AppSettings["MailPort"]);

            NetworkCredential myCredentials = new NetworkCredential(ConfigurationManager.AppSettings["MailAccountName"], ConfigurationManager.AppSettings["FromAddressPwd"]);
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
    }
}
