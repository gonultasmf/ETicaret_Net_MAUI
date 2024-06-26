﻿using ETicaret.Model;
using ETicaret.Views;
using System.Windows.Input;

namespace ETicaret.ViewModel
{
    public class ProfileViewModel : BaseViewModel
    {
        public ICommand SelectMenuCommand { get; private set; }
        public string Name { get; set; } = "David Spade";
        public string Email { get; set; } = "iamdavid@gmail.com";
        public string ImageUrl { get; set; } = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Avatar.png";

        public List<MenuItems> _MenuItems = [];
        public List<MenuItems> MenuItems
        {
            get { return _MenuItems; }
            set { _MenuItems = value; }
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
        public ProfileViewModel()
        {
            SelectMenuCommand = new Command<MenuItems>(SelectMenu);
            InitializeAsync();
        }
        private async void InitializeAsync()
        {
            await PopulateData();
        }
        async Task PopulateData()
        {
            await Task.Delay(500);
            //TODO: Remove Delay here and call API if needed
            MenuItems.Clear();
            MenuItems.Add(new MenuItems() { Title = "Edit Profile", Body = "\uf3eb", TargetType = typeof(HomePageView) });
            MenuItems.Add(new MenuItems() { Title = "Shipping Address", Body = "\uf34e", TargetType = typeof(HomePageView) });
            MenuItems.Add(new MenuItems() { Title = "Wishlist", Body = "\uf2d5", TargetType = typeof(HomePageView) });
            MenuItems.Add(new MenuItems() { Title = "Order History", Body = "\uf150", TargetType = typeof(HomePageView) });
            MenuItems.Add(new MenuItems() { Title = "Track Order", Body = "\uf787", TargetType = typeof(OrderDetailsView) });
            MenuItems.Add(new MenuItems() { Title = "Cards", Body = "\uf19b", TargetType = typeof(HomePageView) });
            MenuItems.Add(new MenuItems() { Title = "Notifications", Body = "\uf09c", TargetType = typeof(HomePageView) });
            IsLoaded = true;
        }

        private void SelectMenu(MenuItems item)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(((Page)Activator.CreateInstance(item.TargetType)));
        }       
    }
}
