using ETicaret.ViewModel;
using ETicaret.Converters;
using Microsoft.Maui.Controls.Shapes;

namespace ETicaret.Views;

public partial class HomePageView(HomePageViewModel viewModel) : FmgLibContentPage<HomePageViewModel>(viewModel)
{
    public override void Build()
    {
        this
        .BackgroundColor(White)
        .ShellNavBarIsVisible(false)
        .Content(() =>
        {
            return new Grid()
            .Margin(8, 12)
            .RowDefinitions(e => e.Auto().Star())
            .Children(() =>
            {
                return [
                    new HorizontalStackLayout()
                    .Row(0)
                    .Margin(0)
                    .FillHorizontal()
                    .IsVisible(e => e.Path("IsLoaded"))
                    .Children(() =>
                    {
                        return [
                            new Border()
                            .Margin(0)
                            .Padding(0)
                            .Background(Transparent)
                            .FillHorizontal()
                            .StrokeShape(new RoundRectangle().CornerRadius(22))
                            .StrokeThickness(0)
                            .Content(() =>{
                                return new HorizontalStackLayout()
                                .Margin(12,2)
                                .CenterVertical()
                                .Children(() => {
                                    return [
                                        new Label()
                                        .FontFamily("icon")
                                        .FontSize(20)
                                        .Center()
                                        .TextCenterHorizontal()
                                        .TextColor(Black)
                                        .Text("&#xf349;"),

                                        new Entry()
                                        .Margin(8,0)
                                        .FontSize(12)
                                        .FillHorizontal()
                                        .Placeholder("Search Here")
                                    ];
                                });
                            }),

                            new Border()
                            .Margin(6,0)
                            .Padding(0)
                            .Background(Color.FromArgb("#00C569"))
                            .AlignEnd()
                            .StrokeShape(new RoundRectangle().CornerRadius(22))
                            .StrokeThickness(0)
                            .Content(() => {
                                return new Label()
                                .FontFamily("icon")
                                .FontSize(22)
                                .Center()
                                .TextCenterHorizontal()
                                .TextColor(White)
                                .Text("&#xf100;");
                            })
                        ];
                    }),

                    new Grid()
                    .Row(1)
                    .CenterVertical()
                    .Children(() => {
                        return [
                            new Grid()
                            .IsVisible(e => e.Path("IsLoaded"))
                            .Children(
                                new ScrollView().FillVertical().Content(
                                                new StackLayout()
                                                .Spacing(0)
                                                .Children(
                                                    new Label()
                                                        .Margin(0,12)
                                                        .FontAttributes(Bold)
                                                        .TextColor(Black)
                                                        .Text("Categories")
                                                        .FontSize(16)
                                                        .AlignStart()
                                                        .AlignBottom()
                                                        .TextStart(),
                                                    new CollectionView().Margin(0, 6).ItemsSource(e => e.Path("CategoriesDataList"))
                                                        .SelectionMode(SelectionMode.Single)
                                                        .VerticalScrollBarVisibility(ScrollBarVisibility.Never)
                                                        .ItemsLayout(
                                                            new GridItemsLayout(ItemsLayoutOrientation.Vertical)
                                                            .HorizontalItemSpacing(12)
                                                            .VerticalItemSpacing(0)
                                                            .Span(5)
                                                        )
                                                        .ItemTemplate(() =>
                                                            new StackLayout()
                                                            .Spacing(0)
                                                            .GestureRecognizers(
                                                                new TapGestureRecognizer().Command(e => e.Path("CategoryTapCommand")).CommandParameter(e => e.Path("."))
                                                            )
                                                            .Children(
                                                                new Border()
                                                                .Margin(0,4)
                                                                .Padding(12)
                                                                .Background(White)
                                                                .Center()
                                                                .Stroke(Gray)
                                                                .SizeRequest(60,60)
                                                                .StrokeShape(new RoundRectangle().CornerRadius(30))
                                                                .Content(
                                                                    new Label()
                                                                    .FontAttributes(Bold)
                                                                    .FontSize(24)
                                                                    .FontFamily("icon")
                                                                    .Center()
                                                                    .TextCenter()
                                                                    .Text(e => e.Path("Icon"))
                                                                    .TextColor(Black)
                                                                ),
                                                                new Label()
                                                                .FontSize(14)
                                                                .CenterHorizontal()
                                                                .AlignBottom()
                                                                .TextCenterHorizontal()
                                                                .Text(e => e.Path("CategoryName"))
                                                                .TextColor(Black)
                                                            )
                                                        ),
                                                    new HorizontalStackLayout()
                                                        .Margin(0,12)
                                                        .Spacing(0)
                                                        .Children(
                                                            new Label()
                                                            .FontAttributes(Bold)
                                                            .FontSize(16)
                                                            .CenterVertical()
                                                            .AlignStart()
                                                            .TextStart()
                                                            .Text("Best Selling")
                                                            .TextColor(Black),
                                                            new Button()
                                                            .BackgroundColor(Transparent)
                                                            .Command(e => e.Path("RecommendedTapCommand"))
                                                            .FontSize(16)
                                                            .Text("View All")
                                                            .TextColor(Black)
                                                            .CenterVertical()
                                                            .AlignEnd()
                                                        ),
                                                    new CollectionView()
                                                        .Margin(0,12)
                                                        .ItemsSource(e => e.Path("BestSellingDataList"))
                                                        .ItemsLayout(
                                                            new LinearItemsLayout(ItemsLayoutOrientation.Horizontal).ItemSpacing(12)
                                                        )
                                                        .ItemTemplate(() =>
                                                            new StackLayout()
                                                            .Margin(0)
                                                            .Background(White)
                                                            .FillHorizontal()
                                                            .GestureRecognizers(
                                                                new TapGestureRecognizer().Command(e => e.Path("SelectProductCommand")).CommandParameter(e => e.Path("."))
                                                            )
                                                            .Children(
                                                                new Border()
                                                                .Background(Transparent)
                                                                .Padding(0)
                                                                .StrokeShape(new RoundRectangle().CornerRadius(new CornerRadius(6, 0, 0, 6)))
                                                                .StrokeThickness(1)
                                                                .Content(
                                                                    new Image()
                                                                    .Source(e => e.Path("ImageUrl"))
                                                                    .SizeRequest(165, 240)
                                                                    .Aspect(Aspect.AspectFit)
                                                                ),
                                                                new StackLayout().Margin(0, 8, 0, 0)
                                                                .Children(
                                                                    new Label()
                                                                    .FontSize(16)
                                                                    .AlignTop()
                                                                    .CenterHorizontal()
                                                                    .TextColor(Black)
                                                                    .Text(e => e.Path("Name")),
                                                                    new Label()
                                                                    .FontSize(12)
                                                                    .AlignTop()
                                                                    .CenterHorizontal()
                                                                    .TextColor(Color.FromArgb("#929292"))
                                                                    .Text(e => e.Path("BrandName")),
                                                                    new Label()
                                                                    .FontSize(16)
                                                                    .AlignTop()
                                                                    .CenterHorizontal()
                                                                    .TextColor(Color.FromArgb("#00C569"))
                                                                    .Text(e => e.Path("Price"))
                                                                )
                                                            )
                                                        ),
                                                    new Label()
                                                        .Margin(0,12)
                                                        .FontAttributes(Bold)
                                                        .TextColor(Black)
                                                        .Text("Featured Brands")
                                                        .FontSize(16)
                                                        .AlignStart()
                                                        .AlignBottom()
                                                        .TextStart(),
                                                    new CollectionView()
                                                        .Margin(0,10)
                                                        .ItemsSource(e => e.Path("FeaturedBrandsDataList"))
                                                        .ItemsLayout(
                                                            new LinearItemsLayout(ItemsLayoutOrientation.Horizontal).ItemSpacing(12)
                                                        )
                                                        .ItemTemplate(() =>
                                                            new StackLayout()
                                                            .Children(
                                                                new Border()
                                                                .Background(White)
                                                                .Padding(16,8)
                                                                .StrokeShape(new RoundRectangle().CornerRadius(6))
                                                                .Stroke(Wheat)
                                                                .FillVertical()
                                                                .CenterHorizontal()
                                                                .GestureRecognizers(
                                                                    new TapGestureRecognizer().Command(e => e.Path  ("BrandTapCommand")).CommandParameter(e => e.Path("."))
                                                                )
                                                                .Content(
                                                                    new HorizontalStackLayout()
                                                                    .Children(
                                                                        new Frame()
                                                                        .Padding(0)
                                                                        .CornerRadius(20)
                                                                        .HasShadow(false)
                                                                        .SizeRequest(40,40)
                                                                        .Opacity(10)
                                                                        .Content(
                                                                            new Image()
                                                                            .Source(e => e.Path("ImageUrl"))
                                                                            .SizeRequest(40,40)
                                                                            .Aspect(Aspect.AspectFit)
                                                                            .Center()
                                                                        ),
                                                                        new StackLayout()
                                                                        .Margin(6,0)
                                                                        .Children(
                                                                             new Label()
                                                                            .FontSize(16)
                                                                            .CenterHorizontal()
                                                                            .TextColor(Black)
                                                                            .FontAttributes(Bold)
                                                                            .Text(e => e.Path("BrandName")),
                                                                            new Label()
                                                                            .FontSize(12)
                                                                            .CenterHorizontal()
                                                                            .TextColor(Color.FromArgb("#929292"))
                                                                            .Text(e => e.Path("Details"))
                                                                        )
                                                                    )
                                                                )
                                                            )
                                                        ),
                                                    new HorizontalStackLayout()
                                                    .Margin(0,12)
                                                    .Spacing(0)
                                                    .Children(
                                                        new Label()
                                                            .FontAttributes(Bold)
                                                            .FontSize(16)
                                                            .CenterVertical()
                                                            .AlignStart()
                                                            .TextStart()
                                                            .Text("Recommended")
                                                            .TextColor(Black),
                                                            new Button()
                                                            .BackgroundColor(Transparent)
                                                            .Command(e => e.Path("RecommendedTapCommand"))
                                                            .FontSize(16)
                                                            .Text("View All")
                                                            .TextColor(Black)
                                                            .CenterVertical()
                                                            .AlignEnd()
                                                    ),
                                                    new CollectionView().Margin(12).ItemsSource(e => e.Path("BestSellingDataList"))
                                                        .ItemsLayout(
                                                            new GridItemsLayout(ItemsLayoutOrientation.Vertical)
                                                            .HorizontalItemSpacing(12)
                                                            .VerticalItemSpacing(12)
                                                            .Span(2)
                                                        )
                                                        .ItemTemplate(() =>
                                                            new StackLayout()
                                                            .Spacing(0)
                                                            .Background(White)
                                                            .FillHorizontal()
                                                            .GestureRecognizers(
                                                                new TapGestureRecognizer().Command(e => e.Path("TapCommand")).CommandParameter(e => e.Path("."))
                                                            )
                                                            .Children(
                                                                new Border()
                                                                .Background(Transparent)
                                                                .StrokeShape(new RoundRectangle().CornerRadius(new CornerRadius(6, 0, 0, 6)))
                                                                .StrokeThickness(1)
                                                                .Content(
                                                                    new Image()
                                                                    .Source(e => e.Path("ImageUrl"))
                                                                    .SizeRequest(165, 240)
                                                                    .Aspect(Aspect.AspectFit)
                                                                ),
                                                                new StackLayout().Margin(0, 8, 0, 0)
                                                                .Children(
                                                                    new Label()
                                                                    .FontSize(16)
                                                                    .AlignTop()
                                                                    .CenterHorizontal()
                                                                    .TextColor(Black)
                                                                    .Text(e => e.Path("Name")),
                                                                    new Label()
                                                                    .FontSize(12)
                                                                    .AlignTop()
                                                                    .CenterHorizontal()
                                                                    .TextColor(Color.FromArgb("#929292"))
                                                                    .Text(e => e.Path("BrandName")),
                                                                    new Label()
                                                                    .FontSize(16)
                                                                    .AlignTop()
                                                                    .CenterHorizontal()
                                                                    .TextColor(Color.FromArgb("#00C569"))
                                                                    .Text(e => e.Path("Price"))
                                                                )
                                                            )
                                                        )
                                                )
                                            )
                            ),

                            new ActivityIndicator()
                            .SizeRequest(45, 45)
                            .Color(Color.FromArgb("#00C569"))
                            .IsRunning(e => e.Path("IsLoaded").Converter(new InverseBooleanConverter()))
                            .Center()
                        ];
                    })
                ];
            });
        });
    }
}
