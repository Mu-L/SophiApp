using SophiApp.Helpers;

namespace SophiApp;

public sealed partial class MainWindow : WindowEx
{
    public MainWindow()
    {
        InitializeComponent();

        AppWindow.SetIcon(Path.Combine(AppContext.BaseDirectory, "Assets/AppIcon.ico"));
        Content = null;
        Title = "AppDisplayName".GetLocalized();
    }
}
