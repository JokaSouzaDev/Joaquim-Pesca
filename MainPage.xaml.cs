using JoaquimPesca.Models;
using JoaquimPesca.Views;
using System.Globalization;

namespace JoaquimPesca;

public partial class MainPage : ContentPage
{
    private readonly Evento evento = new();

    public MainPage()
    {
        InitializeComponent();
        BindingContext = evento;
    }

    private async void OnCadastrarClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(evento.Nome) ||
            string.IsNullOrWhiteSpace(evento.Local))
        {
            await DisplayAlertAsync(
                "Atenção",
                "Preencha o nome e o local do evento.",
                "OK");
            return;
        }

        if (dtInicio.Date is not DateTime inicio ||
            dtTermino.Date is not DateTime termino ||
            termino < inicio)
        {
            await DisplayAlertAsync(
                "Datas inválidas",
                "Confira as datas da pescaria.",
                "OK");
            return;
        }

        if (!int.TryParse(entParticipantes.Text, out int participantes) ||
            participantes <= 0)
        {
            await DisplayAlertAsync(
                "Atenção",
                "Informe uma quantidade válida de participantes.",
                "OK");
            return;
        }

        string custoTexto = entCusto.Text?.Trim().Replace(',', '.') ?? "";

        if (!decimal.TryParse(custoTexto,
            NumberStyles.AllowDecimalPoint,
            CultureInfo.InvariantCulture,
            out decimal custo) || custo < 0)
        {
            await DisplayAlertAsync(
                "Atenção",
                "Informe um custo válido.",
                "OK");
            return;
        }

        evento.DataInicio = inicio;
        evento.DataTermino = termino;
        evento.Participantes = participantes;
        evento.CustoParticipante = custo;

        await Shell.Current.GoToAsync(
            nameof(ResumoPage),
            new Dictionary<string, object>
            {
                ["evento"] = evento
            });
    }
}