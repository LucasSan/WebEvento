namespace Utilidade
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Linq;
    using System.Net.Mail;
    using System.Net.Mime;
    using System.Text;

    public class Email
    {        
        /*public string EnviarEmail(string arrayDest, string Assunto, string Corpo)
        {
            try
            {
                //// Tratando os e-mails recebidos
                Array Email = arrayDest.Split(new char[] { ';' });

                string Servidor_SMTP = ConfigurationManager.AppSettings["ServidorSMTP"];
                string Usuario_Email = ConfigurationManager.AppSettings["UsuarioEmail"];
                string Senha_Email = ConfigurationManager.AppSettings["SenhaEmail"];
                string UsuarioFrom = ConfigurationManager.AppSettings["MailFrom"];

                System.Net.Mail.SmtpClient smtpClient = new System.Net.Mail.SmtpClient(Servidor_SMTP);
                smtpClient.Credentials = new System.Net.NetworkCredential(Usuario_Email, Senha_Email);

                //// Define o tempo para a conexao com o servidor SMTP expirar
                smtpClient.Timeout = 600000;

                MailMessage Mensagem = new MailMessage();
                Mensagem.From = new MailAddress(UsuarioFrom);
                Mensagem.Subject = Assunto;
                Mensagem.Body = Corpo;
                Mensagem.IsBodyHtml = true;

                for (int i = 0; i < Email.Length; i++)
                {
                    Mensagem.To.Add(Email.GetValue(i).ToString());
                }

                smtpClient.Send(Mensagem);
                Mensagem.Dispose();
                return "E-mail Enviado com sucesso!";
            }
            catch
            {
                return "Ocorreu um erro no Enavio do E-mail!";
            }
        }*/
    }
}