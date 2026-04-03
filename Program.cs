using System;

Config config = new();

// Leio o arquivo de configurações
if(!Entrada.Config(config)){
    return 0;
}

// Leio a entrada
if(!Entrada.Terminal(config, args)){
    return 0;
}

config.debug();

// Inicializo as API's
// prepararCotacao();
// prepararEmail();

// Inicio a aplicação
// iniciar();

return 0;