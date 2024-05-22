﻿using ETicaret.Model;
using System.Windows.Input;

namespace ETicaret.ViewModel
{
    public class ProductDetailsViewModel : BaseViewModel
    {
        double lastScrollIndex;
        double currentScrollIndex;
        public ICommand BackCommand { get; set; }
        public ICommand FavCommand { get; set; }

        public bool _IsFooterVisible = false;
        public bool IsFooterVisible
        {
            get
            {
                return _IsFooterVisible;
            }
            set
            {
                _IsFooterVisible = value;
                OnPropertyChanged("IsFooterVisible");

            }
        }

        public bool _IsFavorite = false;
        public bool IsFavorite
        {
            get
            {
                return _IsFavorite;
            }
            set
            {
                _IsFavorite = value;
                OnPropertyChanged("IsFavorite");
                OnPropertyChanged("FavStatusColor");
            }
        }
        public Color FavStatusColor
        {
            get
            {
                if (IsFavorite)
                {
                    return Color.FromArgb("#00C569");
                }
                return Color.FromArgb("#000000");
            }
        }

        public ProductDetail _ProductDetail = new();
        public ProductDetail ProductDetail
        {
            get
            {
                return _ProductDetail;
            }
            set
            {
                _ProductDetail = value;
                OnPropertyChanged("ProductDetail");
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
        public ProductDetailsViewModel()
        {
            BackCommand = new Command<object>(GoBack);
            FavCommand = new Command<Color>(FavItem);
            InitializeAsync();
        }

        private async void InitializeAsync()
        {
            await PopulateData();
        }
        private async void GoBack(object obj)
        {
            await Application.Current.MainPage.Navigation.PopModalAsync();
        }

        private void FavItem(Color obj)
        {
            IsFavorite = true ? !IsFavorite : IsFavorite;
        }
        public void ChageFooterVisibility(double currentY)
        {
            currentScrollIndex = currentY;
            if (currentScrollIndex > lastScrollIndex)
            {
                IsFooterVisible = false;
            }
            else
            {
                IsFooterVisible = true;
            }
            lastScrollIndex = currentScrollIndex;
        }
        async Task PopulateData()
        {
            await Task.Delay(500);
            //TODO: Remove Delay here and call API
            ProductDetail.Price = 1500;
            ProductDetail.Name = "Nike Dri-FIT Long Sleeve";
            ProductDetail.ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/Image10.png";
            ProductDetail.Colors = Color.FromArgb("#33427D");
            ProductDetail.Details = "Nike Dri-FIT is a polyester fabric designed to help you keep dry so you can more comfortably work harder, longer.";

            List<ReviewModel> reviewData =
            [
                new ReviewModel() { ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/user1.png", Name = "Samuel Smith", Review = "Wonderful jean, perfect gift for my girl for our anniversary!", Rating = 4 },
                new ReviewModel() { ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/user2.png", Name = "Beth Aida", Review = "I love this, paired it with a nice blouse and all eyes on me.", Rating = 3 },
                new ReviewModel() { ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/user1.png", Name = "Samuel Smith", Review = "Wonderful jean, perfect gift for my girl for our anniversary!", Rating = 4 },
                new ReviewModel() { ImageUrl = "https://raw.githubusercontent.com/exendahal/ecommerceXF/master/eCommerce/eCommerce.Android/Resources/drawable/user2.png", Name = "Beth Aida", Review = "I love this, paired it with a nice blouse and all eyes on me.", Rating = 3 },
            ];
            ProductDetail.Reviews = reviewData;
            IsLoaded = true;
        }
    }
}
