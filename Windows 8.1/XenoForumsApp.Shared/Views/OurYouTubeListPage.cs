using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.YouTube;
using XenoForumsApp;
using XenoForumsApp.Sections;
using XenoForumsApp.ViewModels;

namespace XenoForumsApp.Views
{
    public sealed partial class OurYouTubeListPage : PageBase
    {
        public ListViewModel<YouTubeDataConfig, YouTubeSchema> ViewModel { get; set; }

        public OurYouTubeListPage()
        {
            this.ViewModel = new ListViewModel<YouTubeDataConfig, YouTubeSchema>(new OurYouTubeConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
