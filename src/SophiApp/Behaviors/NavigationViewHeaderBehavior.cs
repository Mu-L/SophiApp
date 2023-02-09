namespace SophiApp.Behaviors;

using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.Xaml.Interactivity;
using SophiApp.Contracts.Services;

/// <inheritdoc/>
public class NavigationViewHeaderBehavior : Behavior<NavigationView>
{
    /// <summary>
    /// Default header property.
    /// </summary>
    public static readonly DependencyProperty DefaultHeaderProperty =
        DependencyProperty.Register("DefaultHeader", typeof(object), typeof(NavigationViewHeaderBehavior), new PropertyMetadata(null, (d, e) => current!.UpdateHeader()));

    /// <summary>
    /// Header context property.
    /// </summary>
    public static readonly DependencyProperty HeaderContextProperty =
        DependencyProperty.RegisterAttached("HeaderContext", typeof(object), typeof(NavigationViewHeaderBehavior), new PropertyMetadata(null, (d, e) => current!.UpdateHeader()));

    /// <summary>
    /// Sets header mode.
    /// </summary>
    public static readonly DependencyProperty HeaderModeProperty =
        DependencyProperty.RegisterAttached("HeaderMode", typeof(bool), typeof(NavigationViewHeaderBehavior), new PropertyMetadata(NavigationViewHeaderMode.Always, (d, e) => current!.UpdateHeader()));

    /// <summary>
    /// Header template property.
    /// </summary>
    public static readonly DependencyProperty HeaderTemplateProperty =
        DependencyProperty.RegisterAttached("HeaderTemplate", typeof(DataTemplate), typeof(NavigationViewHeaderBehavior), new PropertyMetadata(null, (d, e) => current!.UpdateHeaderTemplate()));

    private static NavigationViewHeaderBehavior? current;
    private Page? currentPage;

    /// <summary>
    /// Gets or sets default header.
    /// </summary>
    public object DefaultHeader
    {
        get => GetValue(DefaultHeaderProperty);
        set => SetValue(DefaultHeaderProperty, value);
    }

    /// <summary>
    /// Gets or sets <see cref="DataTemplate"/>.
    /// </summary>
    public DataTemplate? DefaultHeaderTemplate
    {
        get; set;
    }

    /// <summary>
    /// Gets header context.
    /// </summary>
    /// <param name="item"><see cref="Page"/>.</param>
    public static object GetHeaderContext(Page item) => item.GetValue(HeaderContextProperty);

    /// <summary>
    /// Gets header mode.
    /// </summary>
    /// <param name="item"><see cref="Page"/>.</param>
    public static NavigationViewHeaderMode GetHeaderMode(Page item) => (NavigationViewHeaderMode)item.GetValue(HeaderModeProperty);

    /// <summary>
    /// Gets header template.
    /// </summary>
    /// <param name="item"><see cref="Page"/>.</param>
    public static DataTemplate GetHeaderTemplate(Page item) => (DataTemplate)item.GetValue(HeaderTemplateProperty);

    /// <summary>
    /// Sets header context.
    /// </summary>
    /// <param name="item"><see cref="Page"/>.</param>
    /// <param name="value">context value.</param>
    public static void SetHeaderContext(Page item, object value) => item.SetValue(HeaderContextProperty, value);

    /// <summary>
    /// Sets header mode.
    /// </summary>
    /// <param name="item"><see cref="Page"/>.</param>
    /// <param name="value">header value.</param>
    public static void SetHeaderMode(Page item, NavigationViewHeaderMode value) => item.SetValue(HeaderModeProperty, value);

    /// <summary>
    /// Sets header template.
    /// </summary>
    /// <param name="item"><see cref="Page"/>.</param>
    /// <param name="value">header template value.</param>
    public static void SetHeaderTemplate(Page item, DataTemplate value) => item.SetValue(HeaderTemplateProperty, value);

    /// <inheritdoc/>
    protected override void OnAttached()
    {
        base.OnAttached();

        var navigationService = App.GetService<INavigationService>();
        navigationService.Navigated += OnNavigated;

        current = this;
    }

    /// <inheritdoc/>
    protected override void OnDetaching()
    {
        base.OnDetaching();

        var navigationService = App.GetService<INavigationService>();
        navigationService.Navigated -= OnNavigated;
    }

    private void OnNavigated(object sender, NavigationEventArgs e)
    {
        if (sender is Frame frame && frame.Content is Page page)
        {
            currentPage = page;

            UpdateHeader();
            UpdateHeaderTemplate();
        }
    }

    private void UpdateHeader()
    {
        if (currentPage != null)
        {
            var headerMode = GetHeaderMode(currentPage);
            if (headerMode == NavigationViewHeaderMode.Never)
            {
                AssociatedObject.Header = null;
                AssociatedObject.AlwaysShowHeader = false;
            }
            else
            {
                var headerFromPage = GetHeaderContext(currentPage);
                if (headerFromPage != null)
                {
                    AssociatedObject.Header = headerFromPage;
                }
                else
                {
                    AssociatedObject.Header = DefaultHeader;
                }

                if (headerMode == NavigationViewHeaderMode.Always)
                {
                    AssociatedObject.AlwaysShowHeader = true;
                }
                else
                {
                    AssociatedObject.AlwaysShowHeader = false;
                }
            }
        }
    }

    private void UpdateHeaderTemplate()
    {
        if (currentPage != null)
        {
            var headerTemplate = GetHeaderTemplate(currentPage);
            AssociatedObject.HeaderTemplate = headerTemplate ?? DefaultHeaderTemplate;
        }
    }
}