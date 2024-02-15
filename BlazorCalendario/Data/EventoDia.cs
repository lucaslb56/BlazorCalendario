namespace BlazorCalendario.Data
{
    public class EventoDia
    {
        public int Dia { get; set; }
        public string Nota { get; set; } = "";
        public DateTime DataEvento { get; set; } = new DateTime(1900, 1,1);
        public DateTime DataInicial { get; set; } = new DateTime(1900, 1, 1);
        public DateTime DataFinal { get; set; } = new DateTime(1900, 1, 1);
        public string ValorData { get; set; } = "";
        public string NomeDia { get; set; } = "";
        public string Mensagem { get; set; } = "";
        public string Atendente { get; set; } = "";
        public int CodAtendente { get; set; }
        public string Cliente { get; set; } = "";
        public int CodEmp { get; set; }
    }
}
