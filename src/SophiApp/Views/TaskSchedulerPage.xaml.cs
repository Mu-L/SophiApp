using Microsoft.UI.Xaml.Controls;

using SophiApp.ViewModels;

namespace SophiApp.Views;

public sealed partial class TaskSchedulerPage : Page
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TaskSchedulerPage"/> class.
    /// </summary>
    public TaskSchedulerPage()
    {
        ViewModel = App.GetService<TaskSchedulerViewModel>();
        InitializeComponent();
    }

    public TaskSchedulerViewModel ViewModel
    {
        get;
    }
}
