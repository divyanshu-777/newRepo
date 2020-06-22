using Nexmo.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace DominosMVC.Controllers
{

    public class PaymentController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PaymentDominos(string Email,string PhoneNo,string Amount)
        {

            Random num = new Random();
            string merchantKey = "5jEhUdo0vJ5R1MO!";
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("MID", "DdPthd28357379131745");
            parameters.Add("CHANNEL_ID", "WEB");
            parameters.Add("INDUSTRY_TYPE_ID", "Retail");
            parameters.Add("WEBSITE", "WEBSTAGING");
            parameters.Add("EMAIL", Email);
            parameters.Add("MOBILE_NO", PhoneNo);
            parameters.Add("CUST_ID", "1");
            parameters.Add("ORDER_ID", "ord_"+num.Next(1000));
            parameters.Add("TXN_AMOUNT", Amount);
            parameters.Add("CALLBACK_URL", "http://localhost:56959/Payment/SendMail?Email=" +Email+"&Amount="+Amount+"&PhoneNo="+PhoneNo);

            string checksum = paytm.CheckSum.generateCheckSum(merchantKey, parameters);
            string paytmURL = "https://securegw-stage.paytm.in/theia/processTransaction";

            string outputHTML = "<html>";
            outputHTML += "<head>";
            outputHTML += "<title>Merchant Check Out Page</title>";
            outputHTML += "</head>";
            outputHTML += "<body>";
            outputHTML += "<center><h1>Please do not refresh this page...</h1></center>";
            outputHTML += "<form method='post' action='" + paytmURL + "' name='f1'>";
            outputHTML += "<table border='1'>";
            outputHTML += "<tbody>";
            foreach (string key in parameters.Keys)
            {
                outputHTML += "<input type='hidden' name='" + key + "' value='" + parameters[key] + "'>";
            }
            outputHTML += "<input type='hidden' name='CHECKSUMHASH' value='" + checksum + "'>";
            outputHTML += "</tbody>";
            outputHTML += "</table>";
            outputHTML += "<script type='text/javascript'>";
            outputHTML += "document.f1.submit();";
            outputHTML += "</script>";
            outputHTML += "</form>";
            outputHTML += "</body>";
            outputHTML += "</html>";

            ViewBag.Data = outputHTML;
            return View("PaymentPage");
        }

        public ActionResult SendMail(string Email,string Amount,string PhoneNo)
        {
           
            MailMessage mm = new MailMessage("divyanshucoolrocks@gmail.com", Email);
            mm.Subject = "Order Confirmation mail";
            mm.Body = "Thanks for choosing Dominos. We will deliver your order hot & fresh within 30 mins| Amount:Rs "+Amount;
            mm.IsBodyHtml = false;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;

            NetworkCredential nc = new NetworkCredential("divyanshucoolrocks@gmail.com", "Divy9968@#");
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = nc;
            smtp.Send(mm);

            SendSms(Amount,PhoneNo);
            return RedirectToAction("SuccessPage","Dominos");
        }

        public void SendSms(string Amount,string PhoneNo)
        {
            var client = new Client(creds: new Nexmo.Api.Request.Credentials
            {
                ApiKey = "78b2ece6",
                ApiSecret = "YkzY0b82EtMekuKl"
            });
            var results = client.SMS.Send(request: new SMS.SMSRequest
            {
                from = "919968243777",
                to = PhoneNo,
                text = "Hello from Vonage SMS API"
            });
            return;
        }

       
    }
}