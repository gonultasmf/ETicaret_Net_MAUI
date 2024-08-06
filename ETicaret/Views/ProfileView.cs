using ETicaret.Converters;
using ETicaret.ViewModel;
using Microsoft.Maui.Controls.Shapes;

namespace ETicaret.Views;

public partial class ProfileView(ProfileViewModel viewModel) : FmgLibContentPage<ProfileViewModel>(viewModel)
{
    public override void Build()
    {
        this
        .Title("Profile")
        .BackgroundColor(White)
        .ShellNavBarIsVisible(false)
        .Content(
            new Grid()
            .RowDefinitions(e => e.Auto().Star())
            .Margin(15, 12)
            .CenterVertical()
            .Children(
                new HorizontalStackLayout()
                .Row(0)
                .Margin(0,30)
                .IsVisible(e => e.Path("IsLoaded"))
                .Children(
                    new Border()
                    .Column(0)
                    .Background(Transparent)
                    .StrokeShape(new RoundRectangle().CornerRadius(6))
                    .StrokeThickness(0)
                    .Content(
                        new Image()
                        .Aspect(Aspect.AspectFit)
                        .SizeRequest(120)
                        .Source(e => e.Path("ImageUrl"))
                    ),

                    new StackLayout()
                    .Margin(20)
                    .CenterVertical()
                    .Children(
                        new Label()
                        .FontAttributes(Bold)
                        .FontSize(26)
                        .Center()
                        .Text("David Spade")
                        .TextColor(Black),

                        new Label()
                        .FontSize(14)
                        .Center()
                        .Text("iamdavid@gmail.com")
                        .TextColor(Black)
                    )
                ),

                new CollectionView()
                .Row(1)
                .IsVisible(e => e.Path("IsLoaded"))
                .ItemsSource(e => e.Path("MenuItems"))
                .ItemsLayout(
                    new GridItemsLayout(ItemsLayoutOrientation.Vertical)
                    .HorizontalItemSpacing(12)
                    .VerticalItemSpacing(12)
                    .Span(1)
                )
                .ItemTemplate(() =>
                    new Grid()
                    .ColumnDefinitions(e => e.Absolute(40).Star().Absolute(40))
                    .GestureRecognizers(
                        new TapGestureRecognizer()
                        .Command(e => e.Path("SelectMenuCommand"))
                        .CommandParameter(e => e.Path("."))
                    )
                    .Children(
                        new Border()
                        .Column(0)
                        .SizeRequest(36,40)
                        .StrokeShape(new RoundRectangle().CornerRadius(6))
                        .StrokeThickness(0)
                        .Background(
                            new LinearGradientBrush()
                            .EndPoint(new Point(0,1))
                            .GradientStops(
                                new GradientStop().Offset(0.1f).Color(LightGreen),
                                new GradientStop().Offset(1).Color(LightGray)
                            )
                        )
                        .Content(
                            new Label()
                            .FontFamily("icon")
                            .FontSize(22)
                            .Center()
                            .Text(e => e.Path("Body"))
                            .TextColor(Black)
                        ),

                        new Label()
                        .Column(1)
                        .Margin(18,0)
                        .FontAttributes(Bold)
                        .FontSize(16)
                        .AlignCenterLeft()
                        .Text(e => e.Path("Title"))
                        .TextColor(Black)
                        .TextCenterVertical(),

                        new Label()
                        .Column(2)
                        .FontAttributes(Bold)
                        .FontFamily("icon")
                        .FontSize(16)
                        .AlignCenterRight()
                        .Text("\uf142")
                        .TextColor(Black)
                        .TextCenterVertical()
                    )
                ),

                new ActivityIndicator()
                .SizeRequest(45, 45)
                .Center()
                .Color(Color.FromArgb("#00C569"))
                .IsRunning(e => e.Path("IsLoaded").Converter(new InverseBooleanConverter()))
            )
        );
    }
}
