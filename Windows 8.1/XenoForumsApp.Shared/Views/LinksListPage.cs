using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.Menu;
using XenoForumsApp;
using XenoForumsApp.Sections;
using XenoForumsApp.ViewModels;

namespace XenoForumsApp.Views
{
    public sealed partial class LinksListPage : PageBase
    {
        public ListViewModel<LocalStorageDataConfig, MenuSchema> ViewModel { get; set; }

        public LinksListPage()
        {
            this.ViewModel = new ListViewModel<LocalStorageDataConfig, MenuSchema>(new LinksConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
