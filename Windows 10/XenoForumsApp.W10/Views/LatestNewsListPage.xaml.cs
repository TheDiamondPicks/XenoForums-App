//---------------------------------------------------------------------------
//
// <copyright file="LatestNewsListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/6/2015 5:43:08 AM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.Rss;
using XenoForumsApp.Sections;
using XenoForumsApp.ViewModels;

namespace XenoForumsApp.Views
{
    public sealed partial class LatestNewsListPage : Page
    {
        public LatestNewsListPage()
        {
            this.ViewModel = new ListViewModel<RssDataConfig, RssSchema>(new LatestNewsConfig());
            this.InitializeComponent();
        }

        public ListViewModel<RssDataConfig, RssSchema> ViewModel { get; set; }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();

            base.OnNavigatedTo(e);
        }

    }
}
