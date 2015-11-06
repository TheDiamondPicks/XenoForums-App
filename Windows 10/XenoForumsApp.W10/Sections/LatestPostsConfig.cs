using System;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.Rss;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp.Navigation;
using XenoForumsApp.Config;
using XenoForumsApp.ViewModels;

namespace XenoForumsApp.Sections
{
    public class LatestPostsConfig : SectionConfigBase<RssDataConfig, RssSchema>
    {
        public override DataProviderBase<RssDataConfig, RssSchema> DataProvider
        {
            get
            {
                return new RssDataProvider();
            }
        }

        public override RssDataConfig Config
        {
            get
            {
                return new RssDataConfig
                {
                    Url = new Uri("http://xenoforums.16mb.com/index.php?forums/-/index.rss")
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("LatestPostsListPage");
            }
        }

        public override ListPageConfig<RssSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<RssSchema>
                {
                    Title = "Latest Posts",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = item.Summary.ToSafeString();
                        viewModel.Description = null;
                        viewModel.Image = item.ImageUrl.ToSafeString();
                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("LatestPostsDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<RssSchema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, RssSchema>>();
                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Title.ToSafeString();
                    viewModel.Title = item.Author.ToSafeString();
                    viewModel.Description = item.Content.ToSafeString();
                    viewModel.Image = item.ImageUrl.ToSafeString();
                    viewModel.Content = null;
                });

                var actions = new List<ActionConfig<RssSchema>>
                {
                    ActionConfig<RssSchema>.Link("View on Web", (item) => item.FeedUrl.ToSafeString()),
                };

                return new DetailPageConfig<RssSchema>
                {
                    Title = "Latest Posts",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Latest Posts"; }
        }
    }
}
