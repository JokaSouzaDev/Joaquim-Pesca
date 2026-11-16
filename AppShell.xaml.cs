using JoaquimPesca.Views;

namespace JoaquimPesca;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(ResumoPage), typeof(ResumoPage));
    }
}