using ETicaret.Converters;
using ETicaret.ViewModel;
using Microsoft.Maui.Controls.Shapes;

namespace ETicaret.Views;

public partial class ProductDetailsView(ProductDetailsViewModel viewModel) : FmgLibContentPage<ProductDetailsViewModel>(viewModel)
{
    public override void Build()
    {
        this
        .Title("Order Details")
        .Background(White)
        .Content(
            new Grid()
            .Children(
                new Grid()
                .IsVisible(e => e.Path("IsLoaded"))
                .Children(
                    new ScrollView().OnScrolled(ScrollView_Scrolled).Content(
                        new StackLayout().IsClippedToBounds(true).Children(
                            new Image()
                            .Aspect(Aspect.AspectFill)
                            .HeightRequest(200)
                            .Source(e => e.Path("ProductDetail.ImageUrl")),

                            new StackLayout().Margin(16).Children(
                                new Label()
                                .FontAttributes(Bold)
                                .FontSize(26)
                                .AlignStart()
                                .Text(e => e.Path("ProductDetail.Name"))
                                .TextColor(Black)
                                .TextCenterVertical(),

                                new HorizontalStackLayout().Margin(0,16).FillHorizontal().Children(
                                    new Border()
                                    .Margin(0,16)
                                    .Padding(0)
                                    .Background(Transparent)
                                    .FillHorizontal()
                                    .StrokeShape(new RoundRectangle().CornerRadius(20))
                                    .StrokeThickness(1)
                                    .Content(
                                        new HorizontalStackLayout().AlignCenterVFillH().Children(
                                            new Label()
                                            .Margin(20,15,35,15)
                                            .FontSize(14)
                                            .AlignCenterVStart()
                                            .Text("Size")
                                            .TextColor(Black),

                                            new Label()
                                            .Margin(24,15)
                                            .FontSize(14)
                                            .AlignCenterVStart()
                                            .Text("XL")
                                            .TextColor(Black)
                                        )
                                    ),

                                    new Border()
                                    .Margin(6, 0)
                                    .Padding(0)
                                    .Background(Transparent)
                                    .FillHorizontal()
                                    .StrokeShape(new RoundRectangle().CornerRadius(20))
                                    .StrokeThickness(1)
                                    .Content(
                                        new HorizontalStackLayout().CenterVertical().Children(
                                            new Label()
                                            .Margin(20, 15)
                                            .FontSize(14)
                                            .AlignCenterVStart()
                                            .Text("Color")
                                            .TextColor(Black),

                                            new Border()
                                            .Margin(10)
                                            .Padding(0)
                                            .Background(e => e.Path("ProductDetail.Colors"))
                                            .SizeRequest(26)
                                            .FillHorizontal()
                                            .StrokeShape(new RoundRectangle().CornerRadius(8))
                                            .StrokeThickness(1)
                                        )
                                    )
                                ),

                                new StackLayout().Children(
                                    new Label()
                                    .FontAttributes(Bold)
                                    .FontSize(18)
                                    .AlignCenterVStart()
                                    .Text("Details")
                                    .TextColor(Black),

                                    new Label()
                                    .FontSize(14)
                                    .AlignCenterVStart()
                                    .Text(e => e.Path("ProductDetail.Details"))
                                    .TextColor(Black),

                                    new Label()
                                    .Margin(0,30,0,0)
                                    .FontAttributes(Bold)
                                    .FontSize(18)
                                    .AlignCenterVStart()
                                    .Text("Reviews")
                                    .TextColor(Black),

                                    new Label()
                                    .Margin(0,30,0,0)
                                    .FontAttributes(Bold)
                                    .FontSize(14)
                                    .AlignCenterVStart()
                                    .Text("Write your review")
                                    .TextColor(Color.FromArgb("#00C569"))
                                ),

                                new CollectionView()
                                .Margin(0,16)
                                .ItemsSource(e => e.Path("ProductDetail.Reviews"))
                                .ItemsLayout(
                                    new LinearItemsLayout(ItemsLayoutOrientation.Vertical).ItemSpacing(12)
                                )
                                .ItemTemplate(() =>
                                    new HorizontalStackLayout().Children(
                                        new Border()
                                        .Padding(0)
                                        .SizeRequest(46)
                                        .StrokeShape(new RoundRectangle().CornerRadius(23))
                                        .Content(
                                            new Image()
                                            .Aspect(Aspect.AspectFill)
                                            .SizeRequest(46)
                                            .Source(e => e.Path("ImageUrl"))
                                        ),

                                        new StackLayout()
                                        .Margin(8,0)
                                        .Spacing(2)
                                        .Children(
                                            new Label()
                                            .FontAttributes(Bold)
                                            .FontSize(14)
                                            .Text(e => e.Path("Name"))
                                            .TextColor(Black),

                                            new Label()
                                            .FontSize(14)
                                            .Text(e => e.Path("Name"))
                                            .TextColor(Black)
                                            .TextCenterVertical()
                                        )
                                    )
                                )
                            )
                        )
                    ),

                    new HorizontalStackLayout()
                    .Margin(15)
                    .HeightRequest(42)
                    .AlignTopFillH()
                    .Children(
                        new Border()
                        .Padding(0)
                        .Background(Transparent)
                        .SizeRequest(40)
                        .AlignStart()
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

                        new Border()
                        .Padding(0)
                        .Background(White)
                        .SizeRequest(40)
                        .AlignEnd()
                        .StrokeShape(new RoundRectangle().CornerRadius(20))
                        .StrokeThickness(1)
                        .GestureRecognizers(
                            new TapGestureRecognizer()
                            .Command(e => e.Path("FavCommand"))
                            .CommandParameter(e => e.Path("FavStatusColor"))
                        )
                        .Content(
                            new Label()
                            .FontFamily("icon")
                            .FontSize(26)
                            .Center()
                            .Text("\uf4d2")
                            .TextColor(e => e.Path("FavStatusColor"))
                        )
                    ),

                    new Border()
                    .Padding(0)
                    .Background(White)
                    .HeightRequest(80)
                    .AlignBottomFillH()
                    .IsVisible(e => e.Path("IsFooterVisible"))
                    .StrokeShape(new RoundRectangle().CornerRadius(20)) 
                    .StrokeThickness(1)
                    .Content(
                        new HorizontalStackLayout().Margin(24,0).Children(
                            new StackLayout().Spacing(10).CenterVertical().Children(
                                new Label()
                                .FontSize(12)
                                .CenterHorizontal()
                                .Text("PRICE")
                                .TextColor(Color.FromArgb("#929292")),

                                new Label()
                                .FontSize(12)
                                .CenterHorizontal()
                                .Text(e => e.Path("ProductDetail.Price").StringFormat("'{}{0:c}'"))
                                .TextColor(Color.FromArgb("#00C569"))
                            ),

                            new Button()
                            .Padding(new Thickness(54,12))
                            .BackgroundColor(Color.FromArgb("#00C569"))
                            .AlignCenterVEnd()
                            .Text("ADD")
                            .TextColor(White)
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

    private void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
    {
        BindingContext.ChageFooterVisibility(e.ScrollY);
    }
}