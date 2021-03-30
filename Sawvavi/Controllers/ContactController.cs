using FuelProject.Models;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using MailKit.Net.Smtp;
using System.Threading.Tasks;

namespace FuelProject.Controllers
{
    public class ContactController:Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(contact.Mail, "infopcmarketgeo@gmail.com"));
            message.To.Add(new MailboxAddress(contact.Subject, "infopcmarketgeo@gmail.com"));
            message.Subject = contact.Subject;
            message.Body = new TextPart("plain")
            {
                Text = contact.Subject + "\n" + "\n" + "ადრესატის სახელი : " + contact.Name + "\n"+"\n" +"ადრესატის ელ-ფოსტა" + contact.Mail
            };
            using(var client=new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("infopcmarketgeo@gmail.com", "87*z7>YMH~>aPuR>");
                client.Send(message);
                client.Disconnect(true);
            }
            return RedirectToAction("index");
        }
    }
}
