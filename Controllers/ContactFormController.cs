using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Chouanard.Models;
using System.Net.Mail;
using System.Net.Http.Headers;

namespace Chouanard.Controllers
{
    public class ContactFormController : ApiController
    {
        // GET api/contactform
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/contactform/5
        public string Get(int id)
        {
            return "value";
        }

        // POST /api/contactform
        [HttpPost]
        public HttpResponseMessage Post(Contact contact)
        {
            //string callingDomain = System.Web.HttpContext.Current.Request.UserHostName.ToString();
            //string callingDomain = System.Web.HttpContext.Current.Request.Headers["Referer"];
            string callingDomain = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_REFERER"];
            //string sMessageResponse = "<h3>Thank You!</h3>" + contact.Name + " --- from --- " + callingDomain;
            string sMessageResponse = "<h3>Thank You!</h3>A MakkyMedia representative will be in contact with you to shortly.";

            // Do stuff with:  contact.Name, contact.Email and contact.Message
            SmtpClient mailer = new SmtpClient();
            mailer.Host = "smtp.makkymedia.com";
            mailer.Credentials = new System.Net.NetworkCredential("webmaster@makkymedia.com", "media1makky");

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(contact.Name + "<" + contact.Email + ">");
            mail.To.Add("webmaster@makkymedia.com");
            mail.Subject = "Website Inquiry";
            mail.Body = contact.Message;

            try
            {
                mailer.Send(mail);
            }
            catch (Exception ex)
            {
                sMessageResponse = "<h3>Oops!</h3>Something went wrong with the submission. Please try again or contact us via email at: info@makkymedia.com";
            }

            HttpResponseMessage responseMessage = new HttpResponseMessage();
            responseMessage.Content = new StringContent(sMessageResponse);
            responseMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
            return responseMessage;
        }

        // PUT api/contactform/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/contactform/5
        public void Delete(int id)
        {
        }
    }
}
