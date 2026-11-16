using JoaquimPesca.Models;

namespace JoaquimPesca.Views;

public partial class ResumoPage : ContentPage, IQueryAttributable
{
    public ResumoPage()
    {
        InitializeComponent();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query["evento"] is Evento evento)
        {
            BindingContext = evento;
        }
    }

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}