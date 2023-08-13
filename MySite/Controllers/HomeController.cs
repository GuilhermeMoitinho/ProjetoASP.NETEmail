using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Mvc;
using MySite.Models;

namespace MySite.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SendContact(ContactViewModel model)
    {
        if(!ModelState.IsValid){
            ViewData["message"] = "Informacoes invalidas";
            return View("Contact", model);
        }

        var emailMessage = new MailMessage
        {
            Subject = "Contato de " + model.Name,

            From = new MailAddress("--")
        };
        
        emailMessage.To.Add("--");
        emailMessage.IsBodyHtml = true;

        emailMessage.Body = "<p>Nome: "+model.Name + "</p> <br> <p>E-mail: "+ model.Email + "</p>" + 
        "<p>Mensagem: "+ model.Message + "</p>";


        var client = new SmtpClient("smtp.gmail.com", 465)
        {
            Credentials = new NetworkCredential("--", "--"),
            EnableSsl = true
        };

        try
        {
            client.Send(emailMessage);
        }catch(Exception x){
            ViewData["message"] = "Falha ao enviar mensagem" + x.Message;
            return View("Contact", model);
        }

        return View("SendContact");
    }
}
