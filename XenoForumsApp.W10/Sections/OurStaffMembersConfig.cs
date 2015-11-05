using System;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.DynamicStorage;
using AppStudio.Uwp;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp.Navigation;
using Windows.Storage;
using XenoForumsApp.Config;
using XenoForumsApp.ViewModels;

namespace XenoForumsApp.Sections
{
    public class OurStaffMembersConfig : SectionConfigBase<DynamicStorageDataConfig, OurStaffMembers1Schema>
    {
        public override DataProviderBase<DynamicStorageDataConfig, OurStaffMembers1Schema> DataProvider
        {
            get
            {
                return new DynamicStorageDataProvider<OurStaffMembers1Schema>();
            }
        }

        public override DynamicStorageDataConfig Config
        {
            get
            {
                return new DynamicStorageDataConfig
                {
                    Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=935f654e-0dc8-4e8e-bf05-ce924cad5036&appId=46b6cb3f-e010-423d-8ef6-f6bf3a8661fb"),
                    AppId = "46b6cb3f-e010-423d-8ef6-f6bf3a8661fb",
                    StoreId = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.StoreId] as string,
                    DeviceType = ApplicationData.Current.LocalSettings.Values[LocalSettingNames.DeviceType] as string
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("OurStaffMembersListPage");
            }
        }

        public override ListPageConfig<OurStaffMembers1Schema> ListPage
        {
            get 
            {
                return new ListPageConfig<OurStaffMembers1Schema>
                {
                    Title = "Our Staff Members",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = item.Subtitle.ToSafeString();
                        viewModel.Description = "";
                        viewModel.Image = item.ImageUrl.ToSafeString();
                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("OurStaffMembersDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<OurStaffMembers1Schema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, OurStaffMembers1Schema>>();
                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Title.ToSafeString();
                    viewModel.Title = item.Subtitle.ToSafeString();
                    viewModel.Description = item.Description.ToSafeString();
                    viewModel.Image = item.ImageUrl.ToSafeString();
                    viewModel.Content = null;
                });

                var actions = new List<ActionConfig<OurStaffMembers1Schema>>
                {
                };

                return new DetailPageConfig<OurStaffMembers1Schema>
                {
                    Title = "Our Staff Members",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Our Staff Members"; }
        }
    }
}
