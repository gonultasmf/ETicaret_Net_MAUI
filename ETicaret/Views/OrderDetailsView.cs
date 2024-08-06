using ETicaret.ViewModel;
using ETicaret.Converters;
using Microsoft.Maui.Controls.Shapes;

namespace ETicaret.Views;

public partial class OrderDetailsView(OrderDetailsViewModel viewModel) : FmgLibContentPage<OrderDetailsViewModel>(viewModel)
{
    public override void Build()
    {
        this
        .Title("Order Details")
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
                    .HeightRequest(42)
                    .Margin(6,12)
                    .Children(
                        new Border()
                        .Padding(0)
                        .Background(Transparent)
                        .SizeRequest(40)
                        .StrokeThickness(0)
                        .StrokeShape(new RoundRectangle().CornerRadius(new CornerRadius(20,20,20,20)))
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
                        .TextCenterHorizontal()
                        .Text("Track Order")
                        .TextColor(Black)
                    ),
                    
                    new CollectionView()
                    .Margin(18,0)
                    .IsGrouped(true)
                    .ItemsSource(e => e.Path("TrackData"))
                    .FillVertical()
                    .ItemsLayout(
                        new GridItemsLayout(ItemsLayoutOrientation.Vertical).VerticalItemSpacing(12)
                    )
                    .GroupHeaderTemplate(() =>
                        new Label()
                        .FontSize(14)
                        .AlignLeft()
                        .Text(e => e.Path("Date"))
                        .TextColor(Black)
                    )
                    .ItemTemplate(() =>
                        new StackLayout()
                        .Children(
                            (IView)new HorizontalStackLayout()
                            .Children(
                                new StackLayout()
                                .AlignLeft()
                                .Children(
                                    new Label()
                                    .FontSize(16)
                                    .AlignLeft()
                                    .Text(e => e.Path("OrderId"))
                                    .TextColor(Black),

                                    new Label()
                                    .Margin(0,5)
                                    .FontSize(14)
                                    .AlignLeft()
                                    .Text(e => e.Path("Price"))
                                    .TextColor(Color.FromArgb("#00C569")),

                                    new Frame()
                                    .Margin(0,16)
                                    .Padding(0)
                                    .BackgroundColor(Color.FromArgb("#00C569"))
                                    .BorderColor(Transparent)
                                    .CornerRadius(2)
                                    .HasShadow(false)
                                    .IsClippedToBounds(true)
                                    .GestureRecognizers(
                                        new TapGestureRecognizer().Command(e => e.Path("SelectOrderCommand")).CommandParameter(e => e.Path("."))
                                    )
                                    .Content(
                                         new Label()
                                        .Margin(12,10,12,10)
                                        .FontSize(14)
                                        .Center()
                                        .Text(e => e.Path("Status"))
                                        .TextColor(White)
                                        .TextCenterVertical()
                                    )
                                ),

                                new Grid()
                            )
                        )
                    )
                ),

                new ActivityIndicator()
                .SizeRequest(45,45)
                .Center()
                .Color(Color.FromArgb("#00C569"))
                .IsRunning(e => e.Path("IsLoaded").Converter(new InverseBooleanConverter()))
            )
        );
    }
}