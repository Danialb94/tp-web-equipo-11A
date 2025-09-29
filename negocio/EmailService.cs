using System;
using System.Net;
using System.Net.Mail;

namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        //
        public EmailService(string usuario, string pass)
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential(usuario, pass);
            server.EnableSsl = true;
            server.Port = 587;
            server.Host = "smtp.gmail.com";
        }

        
        public void ArmarCorreo(string emailDestino, string nombre, string apellido)
        {
            email = new MailMessage();
            email.From = new MailAddress("programacionpruebamail@gmail.com");
            email.To.Add(emailDestino);
            email.Subject = "Registro exitoso! Promo web";
            email.Body = "<h1>Tu registro fue exitoso!</h1>" +
                         "<br> Hola, " + nombre + " " + apellido +
                         "! Gracias por participar en la Promo Web!";
            email.IsBodyHtml = true;
        }

        public void EnviarCorreo()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
