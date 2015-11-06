//---------------------------------------------------------------------------
//
// <copyright file="OurStaffMembersListPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/6/2015 7:57:54 PM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.DynamicStorage;
using XenoForumsApp.Sections;
using XenoForumsApp.ViewModels;

namespace XenoForumsApp.Views
{
    public sealed partial class OurStaffMembersListPage : Page
    {
        public OurStaffMembersListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, OurStaffMembers1Schema>(new OurStaffMembersConfig());
            this.InitializeComponent();
        }

        public ListViewModel<DynamicStorageDataConfig, OurStaffMembers1Schema> ViewModel { get; set; }


        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            await this.ViewModel.LoadDataAsync();

            base.OnNavigatedTo(e);
        }

    }
}
