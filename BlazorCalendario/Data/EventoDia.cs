namespace BlazorCalendario.Data
{
    public class EventoDia
    {
        public int USU_CodAgenda {  get; set; }
        public int USU_CodRep {  get; set; }
        public int USU_CodAgendar {  get; set; }
        public string USU_Assunto { get; set; } = "";
        public string USU_Local {  get; set; } = "";
        public DateTime USU_DataEvento { get; set; } = new DateTime(1900, 1, 1);
        public DateTime USU_DataIni { get; set; } = new DateTime(1900, 1, 1);
        public DateTime USU_DataFini { get; set; } = new DateTime(1900, 1, 1);
        public int USU_CodCli { get; set; }


        public int Dia { get; set; }
        public string Nota { get; set; } = "";
        public string ValorData { get; set; } = "";
        public string NomeDia { get; set; } = "";
 
    }
}
