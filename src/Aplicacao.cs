
namespace DesafioInoa.src{
    public class Aplicacao(Config config){
        public IEstado Atual{get; set;} = new Espera();
        public Cotacao cotacao{get; set;} = new Cotacao(config.Ativo);
        public Config UserConfig{get; set;} = config;
        public void Processar() => Atual.Processar(this);
        public void Debug() => Atual.Debug(this);
    }
}