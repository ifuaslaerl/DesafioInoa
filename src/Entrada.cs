using System.Text.Json;

namespace DesafioInoa.src{
    public class Entrada{
        public static async Task<Config> Terminal(
            Config config,
            string[] args
        ){
            if(args.Length != 3){
                throw new ArgumentException(
                    "A entrada deve ser no seguinte formato:\n" +
                    "\tdotnet run <Ativo> <PreçoVenda> <PreçoCompra>"
                );
            }

            config.Ativo = args[0];
            
            try{            
                config.PrecoVenda = double.Parse(args[1]);
                config.PrecoCompra = double.Parse(args[2]);
            }
            catch(FormatException ex){
                throw new FormatException(
                    "Os preços de referência devem ser números reais.\n" +
                    "\tEx: dotnet run PETR4 22,67 22,59", 
                    ex
                );
            }

            // Aguardamos a validação da API
            await Validador.Validar(config); 

            return config;
        }
        public static Config Config(
            string path = ".config.json"
        ){  
            if (!File.Exists(path)){
                throw new FileNotFoundException($"O arquivo de configurações \"{path}\" não existe.");
            }

            string arquivo = File.ReadAllText(path);
            
            Config config = new(){
                SmtpInfo = JsonSerializer.Deserialize<SMTP>(arquivo)!
            };
            
            return config;
        }
    }
}