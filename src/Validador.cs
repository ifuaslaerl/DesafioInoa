namespace DesafioInoa.src{
    public class Validador{
        // Reutilizamos um HttpClient para a validação inicial
        private static readonly HttpClient _httpClient = new();
        public static async Task Validar(Config config){
            if(config.PrecoCompra >= config.PrecoVenda){
                throw new ArgumentException(
                    "O preço de venda deve ser estritamente\n" +
                    "maior que o preço de compra para que haja lucro."
                );
            }
            
            if(!await ValidarAtivo(config.Ativo)){
                throw new ArgumentException(
                    $"O ativo '{config.Ativo}' não foi encontrado ou está indisponível na API."
                );
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