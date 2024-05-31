using ETicaret.Views;

namespace ETicaret;

public partial class AppShell : Shell
{
    public AppShell(IServiceProvider service)
    {
        this
        .FlyoutBehavior(FlyoutBehavior.Disabled)
        .ShellTabBarBackgroundColor(White)
        .ShellTabBarTitleColor(Green)
        .ShellTabBarUnselectedColor(Black)
        .Items(
            new TabBar()
            .Items(
                new Tab()
                .Title("Explore")
                .Icon(new FontImageSource().FontFamily("icon").Glyph("\uf56e"))
                .Items(new ShellContent().ContentTemplate(new DataTemplate(() => service.GetService<HomePageView>()))),
                new Tab()
                .Title("Cart")
                .Icon(new FontImageSource().FontFamily("icon").Glyph("\uf110"))
                .Items(new ShellContent().ContentTemplate(new DataTemplate(() => service.GetService<CartView>()))),
                new Tab()
                .Title("Account")
                .Icon(new FontImageSource().FontFamily("icon").Glyph("\uf004"))
                .Items(new ShellContent().ContentTemplate(new DataTemplate(() => service.GetService<ProfileView>())))
            )
        );
    }
}
