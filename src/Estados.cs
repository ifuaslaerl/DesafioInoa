namespace DesafioInoa.src{
    public interface IEstado{
        Task AoEntrar(Aplicacao aplicacao);
        Task Processar(Aplicacao aplicacao);
        void Debug(Aplicacao aplicacao);
    }    

    public class Compra : IEstado{
        public static Compra Instancia { get; } = new();
        public Task AoEntrar(Aplicacao aplicacao){
            // TODO: fazer isso de verdade
            Console.WriteLine("Email de COMPRA enviado!");
            return Task.CompletedTask;
        }
        
        public async Task Processar(Aplicacao aplicacao){
            double value = await aplicacao.Servico.AgoraAsync();
            
            if(value >= aplicacao.UserConfig.PrecoVenda){
                await aplicacao.TrocarEstado(Venda.Instancia);
            }
            else if(value >= aplicacao.UserConfig.PrecoCompra){
                await aplicacao.TrocarEstado(Espera.Instancia);
            }
        }
        
        public void Debug(Aplicacao aplicacao) => Console.WriteLine($"Estado de Compra Ativo.");
    }

    public class Venda : IEstado{
        public static Venda Instancia { get; } = new();
        public Task AoEntrar(Aplicacao aplicacao){
            // TODO: Fazer isso de verdade 
            Console.WriteLine("Email de VENDA enviado!");
            return Task.CompletedTask;
        }
        
        public async Task Processar(Aplicacao aplicacao){
            double value = await aplicacao.Servico.AgoraAsync();
            
            if(value <= aplicacao.UserConfig.PrecoCompra){
                await aplicacao.TrocarEstado(Compra.Instancia);
            }
            else if(value <= aplicacao.UserConfig.PrecoVenda){
                await aplicacao.TrocarEstado(Espera.Instancia);
            }
        }
        
        public void Debug(Aplicacao aplicacao) => Console.WriteLine($"Estado de Venda Ativo.");
    }

    public class Espera : IEstado
    {
        public static Espera Instancia { get; } = new();
        
        public Task AoEntrar(Aplicacao aplicacao) => Task.CompletedTask;
        
        public async Task Processar(Aplicacao aplicacao){
            double value = await aplicacao.Servico.AgoraAsync();
            
            if(value <= aplicacao.UserConfig.PrecoCompra){
                await aplicacao.TrocarEstado(Compra.Instancia);
            }
            else if(value >= aplicacao.UserConfig.PrecoVenda){
                await aplicacao.TrocarEstado(Venda.Instancia);
            }
        }

        public void Debug(Aplicacao aplicacao) => Console.WriteLine($"Estado de Espera Ativo.");
    }
}