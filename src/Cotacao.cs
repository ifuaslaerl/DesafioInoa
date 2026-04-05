namespace DesafioInoa.src{
    public class Cotacao(string ativo){
        public string Ativo {get; set;} = ativo;
        public double Agora(){
            // TODO: Usar a API de verdade
            double t = DateTime.UtcNow.TimeOfDay.TotalNanoseconds;
            return 10 + 2*Math.Cos(t/1000);
        }
    }

}