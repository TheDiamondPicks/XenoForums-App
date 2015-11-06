//---------------------------------------------------------------------------
//
// <copyright file="OurYouTubeListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/6/2015 5:43:08 AM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.YouTube;
using XenoForumsApp.Sections;
using XenoForumsApp.ViewModels;

namespace XenoForumsApp.Views
{
    public sealed partial class OurYouTubeListPage : Page
    {
        public OurYouTubeListPage()
        {
            this.ViewModel = new ListViewModel<YouTubeDataConfig, YouTubeSchema>(new OurYouTubeConfig());
            this.InitializeComponent();
        }

        public ListViewModel<YouTubeDataConfig, YouTubeSchema> ViewModel { get; set; }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();

            base.OnNavigatedTo(e);
        }

    }
}
