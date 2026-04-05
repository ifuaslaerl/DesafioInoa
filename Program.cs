using DesafioInoa.src;

DesafioInoa.src.Config config = DesafioInoa.src.Entrada.Config();
config = DesafioInoa.src.Entrada.Terminal(config, args);

config.Debug();

Aplicacao aplicacao = new(config);

while (true){
    aplicacao.Processar();
    aplicacao.Debug();
    Thread.Sleep(1000);
}