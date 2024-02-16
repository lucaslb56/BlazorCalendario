using BlazorCalendario.Data;
using BlazorCalendario.IService;

namespace BlazorCalendario.Service
{
    public class EventoDiaervice : IEventoDiaervice
    {
        public string Delete(int id)
        {
            throw new NotImplementedException();
        }

        public EventoDia GetEvento(DateTime dataEvento)
        {
            throw new NotImplementedException();
        }

        public List<EventoDia> GetEvents(DateTime dataInicial, DateTime dataFinal)
        {
            throw new NotImplementedException();
        }

        public EventoDia SalvarOuAtualizar(EventoDia eventoDia)
        {
            throw new NotImplementedException();
        }
    }
}
