//---------------------------------------------------------------------------
//
// <copyright file="HomePage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/6/2015 5:43:08 AM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using XenoForumsApp.ViewModels;

namespace XenoForumsApp.Views
{
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            ViewModel = new MainViewModel(8);            
            InitializeComponent();

            NavigationCacheMode = NavigationCacheMode.Required;
        }

        public MainViewModel ViewModel { get; set; }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();
        }
    }
}
