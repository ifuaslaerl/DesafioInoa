using DesafioInoa.src;

Config config = Entrada.Config();
config = Entrada.Terminal(config, args);

config.Debug();

Aplicacao aplicacao = new(config);

while (true){
    aplicacao.Processar();
    aplicacao.Debug();
    await Task.Delay(1000);
}