using ETicaret.Converters;
using ETicaret.ViewModel;
using Microsoft.Maui.Controls.Shapes;

namespace ETicaret.Views;

public partial class TrackOrderView(TrackOrderViewModel viewModel) : FmgLibContentPage<TrackOrderViewModel>(viewModel)
{
    public override void Build()
    {
        this
        .Title(e => e.Path("PageTitle"))
        .BackgroundColor(White)
        .ShellBackgroundColor(Color.FromArgb("#00C569"))
        .ShellForegroundColor(Black)
        .ShellTitleColor(White)
        .Content(
            new Grid()
            .Children(
                new StackLayout()
                .IsVisible(e => e.Path("IsLoaded"))
                .Children(
                    new HorizontalStackLayout()
                    .Margin(6, 12)
                    .HeightRequest(42)
                    .Children(
                        new Border()
                        .Padding(0)
                        .SizeRequest(40)
                        .Background(Transparent)
                        .StrokeShape(new RoundRectangle().CornerRadius(20))
                        .StrokeThickness(0)
                        .GestureRecognizers(
                            new TapGestureRecognizer().Command(e => e.Path("BackCommand"))
                        )
                        .Content(
                            new Label()
                            .FontFamily("icon")
                            .FontSize(26)
                            .Center()
                            .Text("\uf141")
                            .TextColor(Black)
                        ),

                        new Label()
                        .FontAttributes(Bold)
                        .FontSize(18)
                        .Center()
                        .Text(e => e.Path("PageTitle"))
                        .TextColor(Black)
                        .TextCenterHorizontal()
                    ),

                    new CollectionView()
                    .Margin(20)
                    .ItemsSource(e => e.Path("TrackStatusData"))
                    .ItemTemplate(() =>
                        new HorizontalStackLayout()
                        .CenterHorizontal()
                        .Spacing(0)
                        .Children(
                            new StackLayout().Children(
                                new Label()
                                .FontAttributes(Bold)
                                .FontSize(18)
                                .Text(e => e.Path("DateMonth"))
                                .TextColor(Gray),

                                new Label()
                                .FontAttributes(Bold)
                                .FontSize(14)
                                .Text(e => e.Path("Time"))
                                .TextColor(Gray)
                            ),

                            new StackLayout()
                            .Margin(30, 0, 20, 0)
                            .Spacing(0)
                            .Children(
                                new Border()
                                .Padding(4)
                                .Background(Transparent)
                                .Stroke(Black)
                                .StrokeShape(new RoundRectangle().CornerRadius(16))
                                .StrokeThickness(1)
                                .Content(
                                    new Border()
                                    .Padding(4)
                                    .Background(e => e.Path("StatusColor"))
                                    .Stroke(e => e.Path("StatusColor"))
                                    .StrokeShape(new RoundRectangle().CornerRadius(16))
                                    .StrokeThickness(1)
                                    .SizeRequest(16)
                                ),

                                new Border()
                                .Background(e => e.Path("StatusColor"))
                                .Stroke(e => e.Path("StatusColor"))
                                .StrokeShape(new RoundRectangle().CornerRadius(16))
                                .StrokeThickness(1)
                                .IsVisible(e => e.Path("IsLineVisible"))
                                .AlignFillCenter()
                                .SizeRequest(2, 80)
                            ),

                            new StackLayout().Margin(20, 0).Children(
                                new Label()
                                .FontAttributes(Bold)
                                .FontSize(16)
                                .Text(e => e.Path("Name"))
                                .TextColor(Black),

                                new Label()
                                .FontAttributes(None)
                                .FontSize(12)
                                .Text(e => e.Path("Location"))
                                .TextColor(Black)
                            )
                        )
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
