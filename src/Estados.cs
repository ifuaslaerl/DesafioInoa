namespace DesafioInoa.src{
    public interface IEstado{
        Task AoEntrar(Aplicacao aplicacao);
        Task Processar(Aplicacao aplicacao);
    }    

    public class Compra : IEstado{
        public static Compra Instancia { get; } = new();
        public async Task AoEntrar(Aplicacao aplicacao){
            await aplicacao.notificador.EnviarEmail(
                $"[{aplicacao.UserConfig.Ativo}]: Alerta de Compra",
                $"Prezado, {aplicacao.UserConfig.SmtpInfo.Usuario}\n" +
                "O sistema detectou a seguinte atividade:\n" +
                $"O valor do ativo {aplicacao.UserConfig.Ativo} cruzou " + 
                $"a sua linha de referência de {aplicacao.UserConfig.PrecoCompra}.\n" +
                "Atenciosamente,\n Sistema"
                );
        }
        
        public async Task Processar(Aplicacao aplicacao){
            double value = await aplicacao.Servico.AgoraAsync();
            
            if(aplicacao.UserConfig.SmtpInfo.DebugState) 
                Console.WriteLine($"Estado de Venda: {value}");

            if(value >= aplicacao.UserConfig.PrecoVenda){
                await aplicacao.TrocarEstado(Venda.Instancia);
            }
            else if(value >= aplicacao.UserConfig.PrecoCompra){
                await aplicacao.TrocarEstado(Espera.Instancia);
            }
        }
    }

    public class Venda : IEstado{
        public static Venda Instancia { get; } = new();
        public async Task AoEntrar(Aplicacao aplicacao){
            await aplicacao.notificador.EnviarEmail(
                $"[{aplicacao.UserConfig.Ativo}]: Alerta de Venda",
                $"Prezado, {aplicacao.UserConfig.SmtpInfo.Usuario}\n" +
                "O sistema detectou a seguinte atividade:\n" +
                $"O valor do ativo {aplicacao.UserConfig.Ativo} cruzou " + 
                $"a sua linha de referência de {aplicacao.UserConfig.PrecoVenda}.\n" +
                "Atenciosamente,\n Sistema"
                );
        }
        
        public async Task Processar(Aplicacao aplicacao){
            double value = await aplicacao.Servico.AgoraAsync();
            
            if(aplicacao.UserConfig.SmtpInfo.DebugState)
                Console.WriteLine($"Estado de Venda: {value}");

            if(value <= aplicacao.UserConfig.PrecoCompra){
                await aplicacao.TrocarEstado(Compra.Instancia);
            }
            else if(value <= aplicacao.UserConfig.PrecoVenda){
                await aplicacao.TrocarEstado(Espera.Instancia);
            }
        }
    }

    public class Espera : IEstado
    {
        public static Espera Instancia { get; } = new();
        
        public Task AoEntrar(Aplicacao aplicacao) => Task.CompletedTask;
        
        public async Task Processar(Aplicacao aplicacao){
            double value = await aplicacao.Servico.AgoraAsync();
            
            if(aplicacao.UserConfig.SmtpInfo.DebugState)
                Console.WriteLine($"Estado de Venda: {value}");

            if(value <= aplicacao.UserConfig.PrecoCompra){
                await aplicacao.TrocarEstado(Compra.Instancia);
            }
            else if(value >= aplicacao.UserConfig.PrecoVenda){
                await aplicacao.TrocarEstado(Venda.Instancia);
            }
        }
    }
}