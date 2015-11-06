using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Rss;
using XenoForumsApp;
using XenoForumsApp.Sections;
using XenoForumsApp.ViewModels;

namespace XenoForumsApp.Views
{
    public sealed partial class LatestNewsListPage : PageBase
    {
        public ListViewModel<RssDataConfig, RssSchema> ViewModel { get; set; }

        public LatestNewsListPage()
        {
            this.ViewModel = new ListViewModel<RssDataConfig, RssSchema>(new LatestNewsConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
