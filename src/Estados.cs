
namespace DesafioInoa.src{
    public interface IEstado{
        void AoEntrar(Aplicacao aplicacao);
        void Processar(Aplicacao aplicacao);
        void Debug(Aplicacao aplicacao);
    }    

    public class Compra : IEstado{
        public static Compra Instancia {get;} = new();
        public void AoEntrar(Aplicacao aplicacao){
            // TODO: Enviar o email
            Console.WriteLine("Email de compra enviado!");
        }
        public void Processar(Aplicacao aplicacao){
            double value = aplicacao.Servico.Agora();
            if(value >= aplicacao.UserConfig.PrecoVenda){
                aplicacao.TrocarEstado(Venda.Instancia);
            }else if(value >= aplicacao.UserConfig.PrecoCompra){
                aplicacao.TrocarEstado(Espera.Instancia);
            }
        }
        public void Debug(Aplicacao aplicacao){
            Console.WriteLine($"Estado de Compra! {aplicacao.Servico.Agora()}");
        }
    }

    public class Venda : IEstado{
        public static Venda Instancia {get;} = new();
        public void AoEntrar(Aplicacao aplicacao){
            // TODO: Enviar o email
            Console.WriteLine("Email de Venda enviado!");
        }
        public void Processar(Aplicacao aplicacao){
            double value = aplicacao.Servico.Agora();
            if(value <= aplicacao.UserConfig.PrecoCompra){
                aplicacao.TrocarEstado(Compra.Instancia);
            }else if(value <= aplicacao.UserConfig.PrecoVenda){
                aplicacao.TrocarEstado(Espera.Instancia);
            }
        }
        public void Debug(Aplicacao aplicacao){
            Console.WriteLine($"Estado de Venda! {aplicacao.Servico.Agora()}");
        }
    }

    public class Espera : IEstado{
        public static Espera Instancia {get;} = new();
        public void AoEntrar(Aplicacao aplicacao){
            
        }
        public void Processar(Aplicacao aplicacao){
            double value = aplicacao.Servico.Agora();
            if(value <= aplicacao.UserConfig.PrecoCompra){
                aplicacao.TrocarEstado(Compra.Instancia);
            }else if(value >= aplicacao.UserConfig.PrecoVenda){
                aplicacao.TrocarEstado(Venda.Instancia);
            }
        }
        public void Debug(Aplicacao aplicacao){
            Console.WriteLine($"Estado de espera! {aplicacao.Servico.Agora()}");
        }
    }

}
