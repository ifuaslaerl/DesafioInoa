public class Validador{
    public static bool validar(Config config){
        if(config.PrecoCompra >= config.PrecoVenda){
            Console.WriteLine(
                "O preço de venda deve ser estritamente\n" +
                "maior que o preço de compra para que haja lucro."
            );
            return false;
        }

        if (!validarAtivo(config.Ativo)){
            Console.WriteLine(
                "O ativo a ser monitorado deve ser válido."
            );
            return false;
        }

        return true;
    }
    private static bool validarAtivo(string ativo){
        // TODO: Verificar se o ativo existe pela API
        return true;
    }
}