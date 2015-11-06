//---------------------------------------------------------------------------
//
// <copyright file="ServerStatusListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/6/2015 5:43:08 AM</createdOn>
//
//---------------------------------------------------------------------------

using System.ComponentModel;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.Html;
using XenoForumsApp.Sections;
using XenoForumsApp.ViewModels;

namespace XenoForumsApp.Views
{
    public sealed partial class ServerStatusListPage : Page
    {
        private DataTransferManager _dataTransferManager;
        public ServerStatusListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new ServerStatusConfig());
            this.InitializeComponent();
        }

        public ListViewModel<LocalStorageDataConfig, HtmlSchema> ViewModel { get; set; }

        public string HtmlContent
        {
            get
            {
                if (ViewModel.Items != null && ViewModel.Items.Count > 0)
                {
                    return ViewModel.Items[0].Content;
                }
                return string.Empty;
            }
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();

            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            base.OnNavigatedTo(e);
        }

#region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            var eventHandler = PropertyChanged;
            if (eventHandler != null)
            {
                eventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
#endregion

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _dataTransferManager.DataRequested -= OnDataRequested;

            base.OnNavigatedFrom(e);
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            ViewModel.ShareContent(args.Request);
        }
    }
}
