using ETicaret.Converters;
using ETicaret.ViewModel;
using Microsoft.Maui.Controls.Shapes;

namespace ETicaret.Views;

public partial class CategoryDetailView(CategoryDetailViewModel viewModel) : FmgLibContentPage<CategoryDetailViewModel>(viewModel)
{
    public override void Build()
    {
        this
        .Background(White)
        .Title("Category Detail")
        .Content(() =>
        {
            return new Grid()
            .Children(() =>
            {
                return [
                    new StackLayout()
                    .IsVisible(e => e.Path("IsLoaded"))
                    .Spacing(0)
                    .Children(() => {
                        return [
                            new HorizontalStackLayout()
                            .Margin(6, 12)
                            .HeightRequest(42)
                            .FillHorizontal()
                            .Children(() => {
                                return [
                                    new Border()
                                    .Padding(0)
                                    .Background(Transparent)
                                    .SizeRequest(40, 40)
                                    .AlignStart()
                                    .StrokeThickness(0)
                                    .StrokeShape(new RoundRectangle().CornerRadius(new CornerRadius(20, 20, 20, 20)))
                                    .GestureRecognizers(new TapGestureRecognizer().Command(e => e.Path("BackCommand")))
                                    .Content(
                                        new Label()
                                        .FontFamily("icon")
                                        .FontSize(26)
                                        .TextColor(Black)
                                        .Text("&#xf141;")
                                        .Center()
                                    ),
                                    new Label()
                                    .FontAttributes(Bold)
                                    .FontSize(18)
                                    .FillHorizontal()
                                    .CenterVertical()
                                    .TextCenterHorizontal()
                                    .Text(e => e.Path("PageTitle"))
                                    .TextColor(Black),
                                    new Border()
                                    .Margin(6, 0)
                                    .Padding(0)
                                    .Background(Color.FromArgb("#00C569"))
                                    .SizeRequest(40, 40)
                                    .AlignEnd()
                                    .StrokeThickness(0)
                                    .StrokeShape(new RoundRectangle().CornerRadius(new CornerRadius(20)))
                                    .Content(
                                        new Label()
                                        .FontFamily("icon")
                                        .FontSize(22)
                                        .TextColor(White)
                                        .Text("&#xf100;")
                                        .TextCenterHorizontal()
                                        .Center()
                                    )
                                ];
                            }),
                            new ScrollView().FillVertical().Content(
                                new StackLayout()
                                .Margin(12, 0)
                                .Spacing(0)
                                .Children(() =>{
                                    return [
                                        new Label()
                                        .Margin(0,12)
                                        .FontAttributes(Bold)
                                        .TextColor(Black)
                                        .Text("Top Brands")
                                        .FontSize(16)
                                        .AlignStart()
                                        .AlignBottom()
                                        .TextStart(),
                                        new CollectionView().Margin(0, 2).ItemsSource(e => e.Path("FeaturedBrandsDataList"))
                                        .ItemsLayout(
                                            new LinearItemsLayout(ItemsLayoutOrientation.Horizontal).ItemSpacing(12)
                                        )
                                        .ItemTemplate(() =>
                                        {
                                            return new StackLayout().Children(
                                                new Border()
                                                .Padding(16, 8)
                                                .Background(White)
                                                .Center()
                                                .Stroke(Wheat)
                                                .StrokeShape(new RoundRectangle().CornerRadius(6))
                                                .GestureRecognizers(
                                                    new TapGestureRecognizer().Command(e => e.Path("FeaturedTapCommand")).CommandParameter(e => e.Path("."))
                                                )
                                                .Content(
                                                    new HorizontalStackLayout().Children(
                                                        new Frame()
                                                        .Padding(0)
                                                        .CornerRadius(20)
                                                        .HasShadow(false)
                                                        .SizeRequest(40, 40)
                                                        .Opacity(10)
                                                        .Content(
                                                            new Image()
                                                            .Aspect(Aspect.AspectFit)
                                                            .SizeRequest(40, 40)
                                                            .Source(e => e.Path("ImageUrl"))
                                                            .Center()
                                                        ),
                                                        new StackLayout().Margin(6, 0).Children(
                                                            new Label()
                                                            .FontAttributes(Bold)
                                                            .FontSize(16)
                                                            .CenterHorizontal()
                                                            .Text(e => e.Path("BrandName"))
                                                            .TextColor(Black),
                                                            new Label()
                                                            .FontSize(12)
                                                            .CenterHorizontal()
                                                            .Text(e => e.Path("Details"))
                                                            .TextColor(Color.FromArgb("#929292"))
                                                        )
                                                    )
                                                )
                                            );
                                        }),
                                        new CollectionView()
                                        .Margin(12)
                                        .ItemsSource(e => e.Path("AllProductDataList"))
                                        .ItemsLayout(
                                            new GridItemsLayout(ItemsLayoutOrientation.Vertical)
                                            .HorizontalItemSpacing(12)
                                            .VerticalItemSpacing(12)
                                            .Span(2)
                                        )
                                        .ItemTemplate(() =>
                                        {
                                            return new StackLayout()
                                            .Margin(0)
                                            .Background(White)
                                            .FillHorizontal()
                                            .GestureRecognizers(
                                                new TapGestureRecognizer().Command(e => e.Path("SelectProductCommand")).CommandParameter(e => e.Path("."))
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
                                            );
                                        })
                                    ];
                                })
                            )
                        ];
                    }
                ),
                new ActivityIndicator()
                .SizeRequest(45, 45)
                .Color(Color.FromArgb("#00C569"))
                .IsRunning(e => e.Path("IsLoaded").Converter(new InverseBooleanConverter()))
                .Center()
                ];
            });
        });
    }
}