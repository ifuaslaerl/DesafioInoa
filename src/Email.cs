// A maior parte do arquivo foi escrita pelo Gemini

using System.Net;
using System.Net.Mail;

namespace DesafioInoa.src{
    public class NotificadorEmail(SMTP config){
        private readonly SMTP _config = config;
        public async Task EnviarEmail(
            string assunto,
            string mensagem
        ){
            try{
                using SmtpClient client = new(_config.Servidor, _config.Porta);
                client.Credentials = new NetworkCredential(_config.Usuario, _config.Senha);
                client.EnableSsl = true; // Essencial para a maioria dos servidores de e-mail modernos

                // Construção da mensagem
                using MailMessage email = new(){
                    From = new MailAddress(_config.Usuario),
                    Subject = assunto,
                    Body = mensagem
                };

                email.To.Add(_config.EmailDestino);

                await client.SendMailAsync(email);
            }catch(Exception ex){
                Console.WriteLine($"\n[ERRO] Falha ao enviar o e-mail: {ex.Message}");
            }
        }
    }
}