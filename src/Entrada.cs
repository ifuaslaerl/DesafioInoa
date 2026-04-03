using System;
using System.IO;
using System.Text.Json;

public class Entrada{
    public static bool Terminal(
        Config config,
        string[] args
    ){
        if(args.Length != 3){
            Console.WriteLine(
                "A entrada deve ser no seguinte formato:\n" +
                "\tdotnet run <Ativo> <PreçoVenda> <PreçoCompra>"
                );
            return false;
        }

        config.Ativo = args[0];
        
        try{            
            config.PrecoVenda = double.Parse(args[1]);
            config.PrecoCompra = double.Parse(args[2]);
        }
        catch(FormatException){
            Console.WriteLine(
                "Os preços de referência devem ser números reais.\n" +
                "\tEx: dotnet run PETR4 22.67 22.59"
                );
            return false;
        }

        return Validador.validar(config);
    }

    public static bool Config(
        Config config,
        string path = ".config.json"
    ){  
        if (!File.Exists(path)){
            Console.WriteLine($"O arquivo de configurações \"{path}\" não existe.");
            return false;
        }

        string arquivo = File.ReadAllText(path);
        config.SmtpInfo = JsonSerializer.Deserialize<SMTP>(arquivo);
        
        return true;
    }

}