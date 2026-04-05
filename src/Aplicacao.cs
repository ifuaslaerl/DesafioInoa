
namespace DesafioInoa.src{
    public class Aplicacao(Config config){
        public IEstado Atual{get; set;} = new Espera();
        public Cotacao Servico{get; set;} = new Cotacao(config.Ativo);
        public Config UserConfig{get; set;} = config;
        public void TrocarEstado(IEstado estado){
            Atual = estado;
            Atual.AoEntrar(this);
        }
        public void Processar() => Atual.Processar(this);
        public void Debug() => Atual.Debug(this);
    }
}