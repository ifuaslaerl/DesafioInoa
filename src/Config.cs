namespace DesafioInoa.src{
    public class Config{
        public string Ativo{get; set;} = "";
        public double PrecoVenda{get; set;}
        public double PrecoCompra{get; set;}   
        public required SMTP SmtpInfo {get; set;}

        public void Debug(){
            Console.WriteLine(
                "Configuração:\n" +
                $"\tAtivo: {Ativo}\n" +
                $"\tPreço de venda: {PrecoVenda}\n" +
                $"\tPreço de compra: {PrecoCompra}"
            );
            SmtpInfo.Debug();
        }
    }

    public class SMTP{
        public required string Servidor {get; set;}
        public required int Porta {get; set;}
        public required string Usuario {get; set;}
        public required string Senha {get; set;}
        public required string EmailDestino {get; set;}
        public void Debug(){
            Console.WriteLine(
                "SMTP:\n" +
                $"\tServidor: {Servidor}\n" +
                $"\tPorta: {Porta}\n" +
                $"\tUsuário: {Usuario}\n" +
                $"\tSenha: {Senha}\n" +
                $"\tEmail de destino: {EmailDestino}"
            );
        }
    }
}