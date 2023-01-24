namespace SophiApp
{
    using System;
    using System.IO;
    using WinUIEx;

    /// <inheritdoc/>
    public sealed partial class MainWindow : WindowEx
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            AppWindow.SetIcon(Path.Combine(AppContext.BaseDirectory, "Assets/SophiApp.ico"));
            Content = null;
        }
    }
}