﻿using ETicaret.Model;
using ETicaret.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ETicaret.ViewModel;

public class BrandDetailViewModel : BaseViewModel
{
    private readonly IServiceProvider serviceProvider;
    public ICommand SelectProductCommand { get; private set; }
    public ICommand SelectMenuCommand { get; private set; }

    public ObservableCollection<TabPageModel> _TabPageList = [];
    public ObservableCollection<TabPageModel> TabPageList
    {
        get
        {
            return _TabPageList;
        }
        set
        {
            _TabPageList = value;
            OnPropertyChanged("TabPageList");
        }
    }

    public ObservableCollection<ProductListModel> _AllProductDataList = [];
    public ObservableCollection<ProductListModel> AllProductDataList
    {
        get
        {
            return _AllProductDataList;
        }
        set
        {
            _AllProductDataList = value;
            OnPropertyChanged("AllProductDataList");
        }
    }

    bool _IsLoaded = false;
    public bool IsLoaded
    {
        get { return _IsLoaded; }
        set
        {
            _IsLoaded = value;
            OnPropertyChanged("IsLoaded");
        }
    }
    public BrandDetailViewModel(IServiceProvider serviceProvider)
    {
        this.serviceProvider = serviceProvider;
        SelectProductCommand = new Command<ProductListModel>(SelectProduct);
        SelectMenuCommand = new Command<TabPageModel>(SelectMenu);
        InitializeAsync();
    }

    private async void InitializeAsync()
    {
        await PopulateData();
    }
    private async void SelectProduct(ProductListModel obj)
    {
         await Application.Current.MainPage.Navigation.PushModalAsync(serviceProvider.GetService<ProductDetailsView>());
    }

    private void SelectMenu(TabPageModel obj)
    {
        foreach (var item in TabPageList)
        {
            if (item.Id == obj.Id)
            {
                item.IsSelected = true;
            }
            else
            {
                item.IsSelected = false;
            }
        }

    }
    async Task PopulateData()
    {
        await Task.Delay(500);
        //TODO: Remove Delay here and call API
        AllProductDataList.Add(new ProductListModel() { Name = "BeoPlay Speaker", BrandName = "Bang and Olufsen", Price = "$755", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
        AllProductDataList.Add(new ProductListModel() { Name = "Leather Wristwatch", BrandName = "Tag Heuer", Price = "$450", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image2.png" });
        AllProductDataList.Add(new ProductListModel() { Name = "Smart Bluetooth Speaker", BrandName = "Google LLC", Price = "$900", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image3.png" });
        AllProductDataList.Add(new ProductListModel() { Name = "Smart Luggage", BrandName = "Smart Inc", Price = "$1200", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image4.png" });
        AllProductDataList.Add(new ProductListModel() { Name = "Smart Bluetooth Speaker", BrandName = "Bang and Olufsen", Price = "$90", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image1.png" });
        AllProductDataList.Add(new ProductListModel() { Name = "B&o Desk Lamp", BrandName = "Bang and Olufsen", Price = "$450", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image7.png" });
        AllProductDataList.Add(new ProductListModel() { Name = "BeoPlay Stand Speaker", BrandName = "Bang and Olufse", Price = "$3000", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image8.png" });
        AllProductDataList.Add(new ProductListModel() { Name = "Airpods", BrandName = "B&o Phone Case", Price = "$30", ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image9.png" });
                  
        TabPageList.Add(new TabPageModel("All", 0, true));
        TabPageList.Add(new TabPageModel("Smart Bluetooth Speaker", 1, false));
        TabPageList.Add(new TabPageModel("Lamp", 2, false));
        TabPageList.Add(new TabPageModel("Airpods", 3, false));
        IsLoaded = true;
    }
}
