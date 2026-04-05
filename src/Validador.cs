using System.Net.Mail;

namespace DesafioInoa.src{
    public class Validador{
        private static readonly HttpClient _httpClient = new();
        public static async Task Validar(Config config){
            if(config.PrecoCompra >= config.PrecoVenda){
                throw new ArgumentException(
                    "O preço de venda deve ser estritamente\n" +
                    "maior que o preço de compra para que haja lucro."
                );
            }
            
            ValidarSmtp(config.SmtpInfo);

            if(!await ValidarAtivo(config.Ativo)){
                throw new ArgumentException(
                    $"O ativo '{config.Ativo}' não foi encontrado ou está indisponível na API."
                );
            }
        }
        private static void ValidarSmtp(SMTP smtp){
            if(string.IsNullOrWhiteSpace(smtp.Servidor)){
                throw new ArgumentException("O servidor SMTP não foi definido no ficheiro de configuração.");
            }

            if(smtp.Porta <= 0 || smtp.Porta > 65535){
                throw new ArgumentException(
                    $"A porta SMTP configurada {smtp.Porta} é inválida" +
                    "e deve estar entre 1 e 65535."
                );
            }

            if(string.IsNullOrWhiteSpace(smtp.Usuario) || string.IsNullOrWhiteSpace(smtp.Senha)){
                throw new ArgumentException(
                    "As credenciais do SMTP (Usuário e Senha)" +
                    "devem ser preenchidas no ficheiro de configuração."
                );
            }

            if(string.IsNullOrWhiteSpace(smtp.EmailDestino)){
                throw new ArgumentException(
                    "O e-mail de destino não pode estar vazio."
                );
            }

            // Validar o formato do e-mail de destino utilizando a classe MailAddress nativa do .NET
            try{
                var enderecoEmail = new MailAddress(smtp.EmailDestino);
            }
            catch(FormatException){
                throw new ArgumentException($"O e-mail de destino '{smtp.EmailDestino}' tem um formato inválido.");
            }
        }

        // Método escrito pelo Gemini
        private static async Task<bool> ValidarAtivo(string ativo){
            try{
                string url = $"https://brapi.dev/api/quote/{ativo}";
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                
                return response.IsSuccessStatusCode;
            }
            catch(HttpRequestException ex){
                throw new Exception($"Erro de rede ao tentar validar o ativo: {ex.Message}");
            }
        }
    

    
    }
}