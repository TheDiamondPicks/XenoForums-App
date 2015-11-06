//---------------------------------------------------------------------------
//
// <copyright file="AboutPage.xaml.cs" company="Microsoft">
//    Copyright (C) 2015 by Microsoft Corporation.  All rights reserved.
// </copyright>
//
// <createdOn>11/4/2015 5:56:42 AM</createdOn>
//
//---------------------------------------------------------------------------

using Windows.UI.Xaml.Controls;
using XenoForumsApp.ViewModels;

namespace XenoForumsApp.Views
{
    public sealed partial class AboutPage : Page
    {
        public AboutPage()
        {
            AboutThisAppModel = new AboutThisAppViewModel();

            this.InitializeComponent();
        }

        public AboutThisAppViewModel AboutThisAppModel { get; private set; }
    }
}
