using Microsoft.UI.Xaml.Controls;

using SophiApp.ViewModels;

namespace SophiApp.Views;

public sealed partial class PersonalizationPage : Page
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PersonalizationPage"/> class.
    /// </summary>
    public PersonalizationPage()
    {
        ViewModel = App.GetService<PersonalizationViewModel>();
        InitializeComponent();
    }

    public PersonalizationViewModel ViewModel
    {
        get;
    }
}
