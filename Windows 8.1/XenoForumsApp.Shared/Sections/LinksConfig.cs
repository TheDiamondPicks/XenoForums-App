using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.Menu;
using XenoForumsApp.Config;
using XenoForumsApp.ViewModels;

namespace XenoForumsApp.Sections
{
    public class LinksConfig : SectionConfigBase<LocalStorageDataConfig, MenuSchema>
    {
        public override DataProviderBase<LocalStorageDataConfig, MenuSchema> DataProvider
        {
            get
            {
                return new LocalStorageDataProvider<MenuSchema>();
            }
        }

        public override LocalStorageDataConfig Config
        {
            get
            {
                return new LocalStorageDataConfig
                {
                    FilePath = "/Assets/Data/Links.json"
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("LinksListPage");
            }
        }


        public override ListPageConfig<MenuSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<MenuSchema>
                {
                    Title = "Links",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title;
                        viewModel.Image = item.Icon;
                    },
                    NavigationInfo = (item) =>
                    {
                        return item.ToNavigationInfo();
                    }
                };
            }
        }

        public override DetailPageConfig<MenuSchema> DetailPage
        {
            get { return null; }
        }

        public override string PageTitle
        {
            get { return "Links"; }
        }

    }
}
