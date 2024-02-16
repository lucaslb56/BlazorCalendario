namespace BlazorCalendario.Data
{ 
    public class Calendar
    {
        public List<Semana> calendar = new List<Semana>();

        public List<string> diasSemana;
        public void setCalendar(DateTime dataInicial, DateTime dataFinal)
        {
            diasSemana = new List<string>(){
            "domingo", 
            "segunda-feira",
            "terça-feira",
            "quarta-feira",
            "quinta-feira",
            "sexta-feira",
            "sábado"};
            Semana semana = new Semana();
            string diaSemana;
            List<EventoDia> eventos = new List<EventoDia>();

        for (DateTime data = dataInicial; data <= dataFinal; data = data.AddDays(1))
        {
            diaSemana = data.ToString("dddd");
            semana.Dates.Add(new EventoDia()
                {
                    ValorData = data.ToString("dd"),
                    NomeDia = diaSemana
                });

            if ((diaSemana == diasSemana[0]) || (data == dataFinal)){
                calendar.Add(semana);
                semana = new Semana();
            }

        }

        }


    }

}