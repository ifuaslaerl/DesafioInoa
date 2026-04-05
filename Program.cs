DesafioInoa.src.Config config = new();

// Leio o arquivo de configurações
if(!DesafioInoa.src.Entrada.Config(config)){
    return 0;
}

// Leio a entrada
if(!DesafioInoa.src.Entrada.Terminal(config, args)){
    return 0;
}

// config.debug();

// Inicializo as API's
// prepararCotacao();
// prepararEmail();

// Inicio a aplicação
// Principal.iniciar();

return 0;