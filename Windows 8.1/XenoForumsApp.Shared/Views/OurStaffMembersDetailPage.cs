using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml.Navigation;
using AppStudio.DataProviders.DynamicStorage;
using XenoForumsApp;
using XenoForumsApp.Sections;
using XenoForumsApp.ViewModels;

namespace XenoForumsApp.Views

{
    public sealed partial class OurStaffMembersDetailPage : PageBase
    {
        private DataTransferManager _dataTransferManager;
        public DetailViewModel<DynamicStorageDataConfig, OurStaffMembers1Schema> ViewModel { get; set; }

        public OurStaffMembersDetailPage()
        {
            this.ViewModel = new DetailViewModel<DynamicStorageDataConfig, OurStaffMembers1Schema>(new OurStaffMembersConfig());
            this.InitializeComponent();            
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync(navParameter as ItemViewModel);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _dataTransferManager = DataTransferManager.GetForCurrentView();
            _dataTransferManager.DataRequested += OnDataRequested;

            base.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            _dataTransferManager.DataRequested -= OnDataRequested;

            base.OnNavigatedFrom(e);
        }

        private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
        {
            bool supportsHtml = true;
#if WINDOWS_PHONE_APP
            supportsHtml = false;
#endif
            ViewModel.ShareContent(args.Request, supportsHtml);
        }
    }
}
