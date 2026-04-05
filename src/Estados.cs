
namespace DesafioInoa.src{
    public interface IEstado{
        void Processar(Aplicacao aplicacao);
        void Debug(Aplicacao aplicacao);
    }    

    public class Compra : IEstado{
        public Compra(){
            // TODO: Enviar o email
            Console.WriteLine("Email de compra enviado!");
        }
        public void Processar(Aplicacao aplicacao){
            double value = aplicacao.cotacao.Agora();
            if(value >= aplicacao.UserConfig.PrecoVenda){
                aplicacao.Atual = new Venda();
            }else if(value >= aplicacao.UserConfig.PrecoCompra){
                aplicacao.Atual = new Espera();
            }
        }
        public void Debug(Aplicacao aplicacao){
            Console.WriteLine($"Estado de Compra! {aplicacao.cotacao.Agora()}");
        }
    }

    public class Venda : IEstado{
        public Venda(){
            // TODO: Enviar o email
            Console.WriteLine("Email de Venda enviado!");
        }
        public void Processar(Aplicacao aplicacao){
            double value = aplicacao.cotacao.Agora();
            if(value <= aplicacao.UserConfig.PrecoCompra){
                aplicacao.Atual = new Compra();
            }else if(value <= aplicacao.UserConfig.PrecoVenda){
                aplicacao.Atual = new Espera();
            }
        }
        public void Debug(Aplicacao aplicacao){
            Console.WriteLine($"Estado de Venda! {aplicacao.cotacao.Agora()}");
        }
    }

    public class Espera : IEstado{
        public void Processar(Aplicacao aplicacao){
            double value = aplicacao.cotacao.Agora();
            if(value <= aplicacao.UserConfig.PrecoCompra){
                aplicacao.Atual = new Compra();
            }else if(value >= aplicacao.UserConfig.PrecoVenda){
                aplicacao.Atual = new Venda();
            }
        }
        public void Debug(Aplicacao aplicacao){
            Console.WriteLine($"Estado de espera! {aplicacao.cotacao.Agora()}");
        }
    }

}
