using ETicaret.Converters;
using ETicaret.ViewModel;
using Microsoft.Maui.Controls.Shapes;

namespace ETicaret.Views;

public partial class BrandDetailView(BrandDetailViewModel viewModel) : FmgLibContentPage<BrandDetailViewModel>(viewModel)
{
    public override void Build()
    {
        this
        .Title("Brand Detail")
        .BackgroundColor(White)
        .ShellBackgroundColor(Color.FromArgb("#00C569"))
        .ShellForegroundColor(e => e.OnDark(White).OnLight(Black))
        .ShellTitleColor(White)
        .Content(
             new Grid()
            .Children(
                new StackLayout().IsVisible(e => e.Path("IsLoaded")).Spacing(0).Children(
                    new CollectionView().Background(Color.FromArgb("#00C569")).ItemsSource(e => e.Path("AllProductDataList"))
                    .ItemsLayout(
                        new GridItemsLayout(ItemsLayoutOrientation.Horizontal).HorizontalItemSpacing(6)
                    )
                    .ItemTemplate(new DataTemplate(() =>
                        new Grid()
                        .Margin(6, 0, 0, 12)
                        .GestureRecognizers(
                            new TapGestureRecognizer().Command(e => e.Path("SelectMenuCommand")).CommandParameter(e => e.Path("."))
                        )
                        .Children(
                            (IView)new StackLayout()
                            .Children(
                                new Label()
                                .Margin(6)
                                .FontSize(18)
                                .FontAttributes(Bold)
                                .Center()
                                .TextColor(Black)
                                .TextCenterVertical()
                                .Text(e => e.Path("Name")),
                                new Border()
                                .Background(White)
                                .StrokeShape(new RoundRectangle().CornerRadius(new CornerRadius(0)))
                                .Stroke(White)
                                .HeightRequest(4)
                                .IsVisible(e => e.Path("IsSelected"))
                            )
                        )
                    )),
                    new CollectionView()
                    .Margin(12)
                    .ItemsSource(e => e.Path("AllProductDataList"))
                    .FillVertical()
                    .ItemsLayout(
                        new GridItemsLayout(ItemsLayoutOrientation.Vertical)
                        .HorizontalItemSpacing(12)
                        .VerticalItemSpacing(12)
                        .Span(2)
                    )
                    .ItemTemplate(new DataTemplate(() =>
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
                    ))
                ),
                new ActivityIndicator()
                .SizeRequest(45, 45)
                .Color(Color.FromArgb("#00C569"))
                .IsRunning(e => e.Path("IsLoaded").Converter(new InverseBooleanConverter()))
                .Center()
            )
        );
    }
}
