namespace ETicaret;

public partial class App : Application
{
    public App(IServiceProvider serviceProvider)
    {
        this
        .Resources(AppStyles.Default)
        .MainPage(serviceProvider.GetService<AppShell>());
    }
}
