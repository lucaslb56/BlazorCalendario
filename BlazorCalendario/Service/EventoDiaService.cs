using BlazorCalendario.Data;
using BlazorCalendario.IService;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;

namespace BlazorCalendario.Service
{
    public class EventoDiaService : IEventoDiaService
    {
        EventoDia eventos = new EventoDia();
        List<EventoDia> eventoLista = new List<EventoDia>();

        public IConfiguration Configuration { get; }

        public EventoDiaService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public string Delete(int id)
        {
            string mensagem = "";
            eventos = new EventoDia()
            {
                USU_CodAgenda = id
            };

            using (IDbConnection con = new SqlConnection(Configuration.GetConnectionString("ERP")))
            {
                if (con.State == ConnectionState.Closed) con.Open();

                var evento = con.Query<EventoDia>("USU_TAGENDAS",
                    this.SetParametros(eventos, (int)OperationType.Delete),
                    commandType: CommandType.StoredProcedure);

                mensagem = "Deletado";
            }

            return mensagem;
        }

        public EventoDia GetEvento(DateTime dataEvento)
        {
            eventos = new EventoDia();
            using (IDbConnection con = new SqlConnection(Configuration.GetConnectionString("ERP")))
            {
                if (con.State == ConnectionState.Closed) con.Open();

                string sql = string.Format(@"SELECT * FROM USU_TAGENDAS WHERE USU_DataEvento = '{0}", dataEvento.ToString("dd-MMM-yyyy"));

                var evento = con.Query<EventoDia>(sql).ToList();

                if (evento != null && evento.Count() > 0)
                {
                    eventos = evento.SingleOrDefault();
                }
                else
                {
                    eventos.USU_DataEvento = dataEvento;
                    eventos.USU_DataIni = dataEvento;
                    eventos.USU_DataFini = dataEvento;
                }
            }
            return eventos;
        }

        public List<EventoDia> GetEvents(DateTime dataInicial, DateTime dataFinal)
        {
            eventoLista = new List<EventoDia>();

            using (IDbConnection con = new SqlConnection(Configuration.GetConnectionString("ERP")))
            {
                if (con.State == ConnectionState.Closed) con.Open();

                string sql = string.Format(@"SELECT * FROM USU_TAGENDAS WHERE USU_DataEvento BETWEEN '{0}' AND {1}", dataInicial.ToString("dd-MMM-yyyy"), dataFinal.ToString("dd-MMM-yyyy"));

                var evento = con.Query<EventoDia>(sql).ToList();

                if (evento != null && evento.Count() > 0)
                {
                    eventoLista = evento;
                }
            }
            return eventoLista;
        }

        public EventoDia SalvarOuAtualizar(EventoDia eventoDia)
        {
            eventos = new EventoDia();

            int tipoOperacao = Convert.ToInt32(eventoDia.USU_CodAgendar == 0 ? OperationType.Insert : OperationType.Update);

            using (IDbConnection con = new SqlConnection(Configuration.GetConnectionString("ERP")))
            {
                if (con.State == ConnectionState.Closed) con.Open();

                var evento = con.Query<EventoDia>("USU_TAGENDAS",
                    this.SetParametros(eventoDia, tipoOperacao),
                    commandType: CommandType.StoredProcedure);

                if (evento != null && evento.Count() > 0)
                {
                    eventos = evento.FirstOrDefault();
                }
            }
            return eventos;
        }

        private DynamicParameters SetParametros(EventoDia eventoDia, int tipoOperacao)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@USU_CodAgenda", eventos.USU_CodAgenda);
            parameters.Add("@USU_CodRep", eventos.USU_CodRep);
            parameters.Add("@USU_Assunto", eventos.USU_Assunto);
            parameters.Add("@USU_Local", eventos.USU_Local);
            parameters.Add("@USU_DataIni", eventos.USU_DataIni);
            parameters.Add("@USU_DataFini", eventos.USU_Local);
            parameters.Add("@USU_CodCli", eventos.USU_CodCli);
            parameters.Add("@OperationType", tipoOperacao);

            return parameters;
        }
    }
}
