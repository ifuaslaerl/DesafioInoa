namespace DesafioInoa.src{
    public class Validador{
        public static bool Validar(Config config){
            if(config.PrecoCompra >= config.PrecoVenda){
                Console.WriteLine(
                    "O preço de venda deve ser estritamente\n" +
                    "maior que o preço de compra para que haja lucro."
                );
                return false;
            }

            if (!ValidarAtivo(config.Ativo)){
                Console.WriteLine(
                    $"O ativo {config.Ativo} não foi encontrado ou está indisponível na API"
                );
                return false;
            }

            return true;
        }
        private static bool ValidarAtivo(string ativo){
            // TODO: Verificar se o ativo existe pela API
            return true;
        }
    }
}