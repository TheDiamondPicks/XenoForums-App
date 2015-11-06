using Windows.UI.Xaml.Navigation;
using AppStudio.Common;
using AppStudio.DataProviders.DynamicStorage;
using XenoForumsApp;
using XenoForumsApp.Sections;
using XenoForumsApp.ViewModels;

namespace XenoForumsApp.Views
{
    public sealed partial class OurStaffMembersListPage : PageBase
    {
        public ListViewModel<DynamicStorageDataConfig, OurStaffMembers1Schema> ViewModel { get; set; }

        public OurStaffMembersListPage()
        {
            this.ViewModel = new ListViewModel<DynamicStorageDataConfig, OurStaffMembers1Schema>(new OurStaffMembersConfig());
            this.InitializeComponent();
        }

        protected async override void LoadState(object navParameter)
        {
            await this.ViewModel.LoadDataAsync();
        }

    }
}
