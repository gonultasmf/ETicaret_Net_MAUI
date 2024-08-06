using ETicaret.Converters;
using ETicaret.ViewModel;
using Microsoft.Maui.Controls.Shapes;

namespace ETicaret.Views;

public partial class CartView(CartViewModel viewModel) : FmgLibContentPage<CartViewModel>(viewModel)
{
    public override void Build()
    {
        this
        .Title("Cart Page")
        .BackgroundColor(White)
        .ShellBackgroundColor(White)
        .ShellForegroundColor(Black)
        .ShellTitleColor(Black)
        .ShellNavBarIsVisible(false)
        .Content(
            new Grid()
            .Children(
                new CollectionView()
                .Margin(12)
                .IsVisible(e => e.Path("IsLoaded"))
                .ItemsSource(e => e.Path("AllProductDataList"))
                .ItemsLayout(
                    new GridItemsLayout(ItemsLayoutOrientation.Vertical)
                    .VerticalItemSpacing(12)
                    .Span(1)
                )
                .ItemTemplate(new DataTemplate(() =>
                    new SwipeView()
                    .LeftItems(
                        new SwipeItem()
                        .BackgroundColor(Color.FromArgb("#FFC107"))
                        .OnInvoked(SwipeItem_Invoked)
                        .Text("Favorite")
                        .Command( e => e.Path("FavoriteCommand"))
                        .CommandParameter( e => e.Path("."))
                    )
                    .RightItems(
                        new SwipeItem()
                        .BackgroundColor(Color.FromArgb("#FF3D00"))
                        .OnInvoked(SwipeItem_Invoked)
                        .Text("Delete")
                        .Command(e => e.Path("DeleteCommand"))
                        .CommandParameter(e => e.Path("."))
                    )
                    .Content(
                        new HorizontalStackLayout()
                        .Spacing(16)
                        .Background(White)
                        .FillHorizontal()
                        .GestureRecognizers(
                            new TapGestureRecognizer().Command(e => e.Path("SelectProductCommand")).CommandParameter(e => e.Path("."))
                        )
                        .Children(
                            new Image()
                            .Source(e => e.Path("ImageUrl"))
                            .SizeRequest(120, 120)
                            .Aspect(Aspect.AspectFit),
                            new StackLayout().Spacing(6).Children(
                                new Label()
                                .FontSize(16)
                                .AlignTop()
                                .CenterHorizontal()
                                .TextColor(Black)
                                .Text(e => e.Path("Name")),
                                new HorizontalStackLayout().Children(
                                    new Label()
                                    .FontSize(16)
                                    .AlignLeft()
                                    .FontAttributes(Bold)
                                    .TextColor(Black)
                                    .Text(e => e.Path("Value").Source("_stepper").StringFormat("'QTY: {0}'")),
                                    new Label()
                                    .FontSize(16)
                                    .AlignLeft()
                                    .TextColor(Color.FromArgb("#00C569"))
                                    .Text(e => e.Path("Price"))
                                ),
                                new Stepper()
                                .Assign(out var _stepper)
                                .CenterHorizontal()
                                .Increment(1)
                                .Maximum(10)
                                .Minimum(e => e.Path("Qty"))
                                .OnValueChanged(Stepper_ValueChanged)
                            )
                        )   
                    )
                )),
                new ActivityIndicator()
                .SizeRequest(45, 45)
                .Color(Color.FromArgb("#00C569"))
                .IsRunning(e => e.Path("IsLoaded").Converter(new InverseBooleanConverter()))
                .Center()
            )
        );
    }

    private void SwipeItem_Invoked(object sender, EventArgs e)
    {

    }

    private void Stepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double value = e.NewValue;
    }
}
