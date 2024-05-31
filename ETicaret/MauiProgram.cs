using ETicaret.ViewModel;
using ETicaret.Views;

namespace ETicaret;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("icon.ttf", "icon");
            });


        builder.Services
            .AddSingleton<App>()
            .AddSingleton<AppShell>()
            .AddScoped<AllProductView>()
            .AddScoped<BrandDetailView>()
            .AddScoped<CartView>()
            .AddScoped<CategoryDetailView>()
            .AddScoped<HomePageView>()
            .AddScoped<OrderDetailsView>()
            .AddScoped<ProductDetailsView>()
            .AddScoped<ProfileView>()
            .AddScoped<TrackOrderView>()
            .AddScoped<AllProductViewModel>()
            .AddScoped<BrandDetailViewModel>()
            .AddScoped<CartViewModel>()
            .AddScoped<CategoryDetailViewModel>()
            .AddScoped<HomePageViewModel>()
            .AddScoped<OrderDetailsViewModel>()
            .AddScoped<ProductDetailsViewModel>()
            .AddScoped<ProfileViewModel>()
            .AddScoped<TrackOrderViewModel>();

        return builder.Build();
    }
}
