// O Gemini fez a maior parte desse arquivo

using System.Text.Json;

namespace DesafioInoa.src{
    public class Cotacao{
        private static readonly HttpClient _httpClient = new();
        private static readonly JsonSerializerOptions _jsonOptions = new(){ 
            PropertyNameCaseInsensitive = true 
        };
        
        public string Ativo { get; private set; }
        private readonly string _apiUrl;
        public Cotacao(string ativo){
            Ativo = ativo;
            // A API da Brapi retorna dados da B3 de forma simples. 
            // Nota: Atualmente a Brapi pode exigir um token gratuito na URL em formato ?token=SEU_TOKEN
            _apiUrl = $"https://brapi.dev/api/quote/{Ativo}";
        }

        public async Task<double> AgoraAsync(){
            try{
                HttpResponseMessage response = await _httpClient.GetAsync(_apiUrl);
                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                var dadosApi = JsonSerializer.Deserialize<BrapiResponse>(json, _jsonOptions);
                if(dadosApi?.Results != null && dadosApi.Results.Count > 0){
                    return dadosApi.Results[0].RegularMarketPrice;
                }

                throw new Exception($"A API não retornou dados válidos para o ativo {Ativo}.");
            }
            catch(HttpRequestException ex){
                throw new Exception($"Falha na comunicação com a API de cotação: {ex.Message}");
            }
        }
    }
    public class BrapiResponse{
        public List<BrapiResult>? Results { get; set; }
    }

    public class BrapiResult{
        public double RegularMarketPrice { get; set; }
    }
}