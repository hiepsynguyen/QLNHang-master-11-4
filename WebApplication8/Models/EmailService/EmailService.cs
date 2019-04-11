using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions;

namespace WebApplication8.Models.EmailService
{
    public class EmailService
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public readonly string FromAddress;
        public readonly string Password;
        public EmailService(IHostingEnvironment hostingEnvironment, IHttpContextAccessor httpContextAccessor) {
            _hostingEnvironment = hostingEnvironment;
            _httpContextAccessor = httpContextAccessor;
            FromAddress = "trunglu885@gmail.com";
            Password = "01679162755";
        }
        public  bool SendMailOrderNotifi(string id,string received_email) {
            try
            {
                //From Address 
                string FromAddress_ = FromAddress;
                string FromAdressTitle = "Email from ShopOnline";
                //To Address 
                string ToAddress = received_email;
                string ToAdressTitle = "Email from ShopOnline";
                string Subject = "ShopOnline - Sending email Comfirm Order";
                string BodyContent = "Thank you. " +
                   " Please click link below to confirm a bill : http://"+ _httpContextAccessor.HttpContext.Request.Host.Value.ToString() + "/Order/ConfirmOrder?idorder=" + id;
                //Smtp Server 
                string SmtpServer = "smtp.gmail.com";
                //Smtp Port Number 
                int SmtpPortNumber = 587;
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(FromAdressTitle, FromAddress));
                mimeMessage.To.Add(new MailboxAddress(ToAdressTitle, ToAddress));
                mimeMessage.Subject = Subject;
                mimeMessage.Body = new TextPart("plain")
                {
                    Text = BodyContent

                };
                using (var client = new SmtpClient())
                {
                    client.Connect(SmtpServer, SmtpPortNumber, false);
                    // Note: only needed if the SMTP server requires authentication 
                    // Error 5.5.1 Authentication  
                    client.Authenticate(FromAddress, Password);
                    client.Send(mimeMessage);

                    // Console.WriteLine("The mail has been sent successfully !!");
                    //  Console.ReadLine();
                    client.Disconnect(true);

                }
            }
            catch
            {
                return false;
            }
            

            return true;
        }
    }
}
