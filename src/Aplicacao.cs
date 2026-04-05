namespace DesafioInoa.src
{
    public class Aplicacao(Config config)
    {
        public IEstado Atual { get; private set; } = Espera.Instancia;
        public Cotacao Servico { get; private set; } = new Cotacao(config.Ativo);
        public Config UserConfig { get; private set; } = config;
        public async Task TrocarEstado(IEstado estado)
        {
            Atual = estado;
            await Atual.AoEntrar(this);
        }

        public async Task Processar() => await Atual.Processar(this);
        public void Debug() => Atual.Debug(this);
    }
}