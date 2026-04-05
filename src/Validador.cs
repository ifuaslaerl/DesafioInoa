namespace DesafioInoa.src{
    public class Validador{
        public static void Validar(Config config){
            if(config.PrecoCompra >= config.PrecoVenda){
                throw new ArgumentException(
                    "O preço de venda deve ser estritamente\n" +
                    "maior que o preço de compra para que haja lucro."
                );
            }

            if (!ValidarAtivo(config.Ativo)){
                throw new ArgumentException(
                    $"O ativo {config.Ativo} não foi encontrado ou está indisponível na API"
                );
            }
        }
        private static bool ValidarAtivo(string ativo){
            // TODO: Verificar se o ativo existe pela API
            return true;
        }
    }
}