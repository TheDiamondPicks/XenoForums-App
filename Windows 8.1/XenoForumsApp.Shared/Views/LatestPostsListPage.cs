using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.Rss;
using XenoForumsApp;
using XenoForumsApp.Sections;
using XenoForumsApp.ViewModels;

namespace XenoForumsApp.Views
{
    public sealed partial class LatestPostsListPage : PageBase
    {
        public ListViewModel<RssDataConfig, RssSchema> ViewModel { get; set; }

        public LatestPostsListPage()
        {
            this.ViewModel = new ListViewModel<RssDataConfig, RssSchema>(new LatestPostsConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
