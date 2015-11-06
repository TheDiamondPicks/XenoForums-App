using System;
using System.Collections.Generic;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Core;
using AppStudio.DataProviders.YouTube;
using AppStudio.Uwp.Actions;
using AppStudio.Uwp.Commands;
using AppStudio.Uwp.Navigation;
using XenoForumsApp.Config;
using XenoForumsApp.ViewModels;

namespace XenoForumsApp.Sections
{
    public class OurYouTubeConfig : SectionConfigBase<YouTubeDataConfig, YouTubeSchema>
    {
        public override DataProviderBase<YouTubeDataConfig, YouTubeSchema> DataProvider
        {
            get
            {
                return new YouTubeDataProvider(new YouTubeOAuthTokens
                {
                    ApiKey = "AIzaSyDoPVOrxM_aTjAEWZqjYK7gMhiDANcet7s"
                });
            }
        }

        public override YouTubeDataConfig Config
        {
            get
            {
                return new YouTubeDataConfig
                {
                    QueryType = YouTubeQueryType.Channels,
                    Query = @"ItsFrosttyGames"
                };
            }
        }

        public override NavigationInfo ListNavigationInfo
        {
            get 
            {
                return NavigationInfo.FromPage("OurYouTubeListPage");
            }
        }

        public override ListPageConfig<YouTubeSchema> ListPage
        {
            get 
            {
                return new ListPageConfig<YouTubeSchema>
                {
                    Title = "Our YouTube",

                    LayoutBindings = (viewModel, item) =>
                    {
                        viewModel.Title = item.Title.ToSafeString();
                        viewModel.SubTitle = item.Summary.ToSafeString();
                        viewModel.Description = null;
                        viewModel.Image = item.ImageUrl.ToSafeString();
                    },
                    NavigationInfo = (item) =>
                    {
                        return NavigationInfo.FromPage("OurYouTubeDetailPage", true);
                    }
                };
            }
        }

        public override DetailPageConfig<YouTubeSchema> DetailPage
        {
            get
            {
                var bindings = new List<Action<ItemViewModel, YouTubeSchema>>();
                bindings.Add((viewModel, item) =>
                {
                    viewModel.PageTitle = item.Title.ToSafeString();
                    viewModel.Title = null;
                    viewModel.Description = item.Summary.ToSafeString();
                    viewModel.Image = null;
                    viewModel.Content = item.EmbedHtmlFragment;
                });

                var actions = new List<ActionConfig<YouTubeSchema>>
                {
                    ActionConfig<YouTubeSchema>.Link("Go To Source", (item) => item.ExternalUrl.ToSafeString()),
                };

                return new DetailPageConfig<YouTubeSchema>
                {
                    Title = "Our YouTube",
                    LayoutBindings = bindings,
                    Actions = actions
                };
            }
        }

        public override string PageTitle
        {
            get { return "Our YouTube"; }
        }
    }
}
