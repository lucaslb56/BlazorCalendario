using BlazorCalendario.Data;

namespace BlazorCalendario.IService
{
    public interface IEventoDiaervice
    {
        EventoDia SalvarOuAtualizar(EventoDia eventoDia);
        EventoDia GetEvento(DateTime dataEvento);
        List<EventoDia> GetEvents(DateTime dataInicial, DateTime dataFinal);
        string Delete(int id);
    }
}
