using System.Globalization;

namespace JoaquimPesca.Models;

public class Evento
{
    public string Nome { get; set; } = "";
    public DateTime DataInicio { get; set; } = DateTime.Today;
    public DateTime DataTermino { get; set; } = DateTime.Today.AddDays(1);
    public int Participantes { get; set; } = 1;
    public string Local { get; set; } = "";
    public decimal CustoParticipante { get; set; }

    public TimeSpan Duracao => DataTermino.Date - DataInicio.Date;

    public int Dias => Duracao.Days;

    public decimal CustoTotal => Participantes * CustoParticipante;

    public string DuracaoTexto => $"{Dias} dia(s)";

    public string PeriodoTexto =>
        $"{DataInicio:dd/MM/yyyy} até {DataTermino:dd/MM/yyyy}";

    public string CustoIndividualTexto =>
        CustoParticipante.ToString("C", new CultureInfo("pt-BR"));

    public string CustoTotalTexto =>
        CustoTotal.ToString("C", new CultureInfo("pt-BR"));
}