using System;
using System.Collections.Generic;
using AppStudio.Common;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.DynamicStorage;
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
                    Url = new Uri("http://ds.winappstudio.com/api/data/collection?dataRowListId=6ad63784-43e0-46e8-9fbf-92404eae4688&appId=1e09cc71-211c-4517-aac3-7d746487b21b"),
                    AppId = "1e09cc71-211c-4517-aac3-7d746487b21b",
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
