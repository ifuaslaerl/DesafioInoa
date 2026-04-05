using DesafioInoa.src;

Config config = Entrada.Config();
config = await Entrada.Terminal(config, args);
config.Debug();

Aplicacao aplicacao = new(config);

Console.WriteLine($"\nIniciando monitorização de {config.Ativo}...");
while(true){
    try{
        await aplicacao.Processar();
        aplicacao.Debug();
    }catch(Exception ex){
        Console.WriteLine($"[AVISO]: {ex.Message}. Tentando novamente no próximo ciclo...");
    }
    
    await Task.Delay(10000); 
}