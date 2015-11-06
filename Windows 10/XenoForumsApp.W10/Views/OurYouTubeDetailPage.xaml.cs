//---------------------------------------------------------------------------
//
// <copyright file="OurYouTubeDetailPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/6/2015 5:43:08 AM</createdOn>
//
//---------------------------------------------------------------------------

using System;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.YouTube;
using XenoForumsApp.Sections;
using XenoForumsApp.Services;
using XenoForumsApp.ViewModels;

namespace XenoForumsApp.Views
{
    public sealed partial class OurYouTubeDetailPage : Page
    {
        private DataTransferManager _dataTransferManager;

        public OurYouTubeDetailPage()
        {
            this.ViewModel = new DetailViewModel<YouTubeDataConfig, YouTubeSchema>(new OurYouTubeConfig());
            this.ViewModel.SupportFullScreen = true;

            this.InitializeComponent();
        }

        public DetailViewModel<YouTubeDataConfig, YouTubeSchema> ViewModel { get; set; }        

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync(e.Parameter as ItemViewModel);

            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;
            FullScreenService.CurrentPageSupportFullScreen = true;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _dataTransferManager.DataRequested -= OnDataRequested;
            FullScreenService.CurrentPageSupportFullScreen = false;

            base.OnNavigatedFrom(e);
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            ViewModel.ShareContent(args.Request);
        }

        private void AppBarButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            AppBarButton button = sender as AppBarButton;
            int newFontSize = Int32.Parse(button.Tag.ToString());
            mainPanel.BodyFontSize = newFontSize;
            mainPanel.UpdateFontSize();
        }
    }
}
