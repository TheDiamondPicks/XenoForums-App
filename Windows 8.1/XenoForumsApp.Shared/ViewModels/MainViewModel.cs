using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppStudio.Common;
using AppStudio.Common.Actions;
using AppStudio.Common.Commands;
using AppStudio.Common.Navigation;
using AppStudio.DataProviders;
using AppStudio.DataProviders.Rss;
using AppStudio.DataProviders.YouTube;
using AppStudio.DataProviders.Menu;
using AppStudio.DataProviders.Html;
using AppStudio.DataProviders.LocalStorage;
using AppStudio.DataProviders.DynamicStorage;
using XenoForumsApp.Sections;


namespace XenoForumsApp.ViewModels
{
    public class MainViewModel : ObservableBase
    {
        public MainViewModel(int visibleItems)
        {
            PageTitle = "XenoForums App";
            LatestNews = new ListViewModel<RssDataConfig, RssSchema>(new LatestNewsConfig(), visibleItems);
            LatestPosts = new ListViewModel<RssDataConfig, RssSchema>(new LatestPostsConfig(), visibleItems);
            OurYouTube = new ListViewModel<YouTubeDataConfig, YouTubeSchema>(new OurYouTubeConfig(), visibleItems);
            OurStaffMembers = new ListViewModel<DynamicStorageDataConfig, OurStaffMembers1Schema>(new OurStaffMembersConfig(), visibleItems);
            Links = new ListViewModel<LocalStorageDataConfig, MenuSchema>(new LinksConfig());
            ServerStatus = new ListViewModel<LocalStorageDataConfig, HtmlSchema>(new ServerStatusConfig(), visibleItems);
            Actions = new List<ActionInfo>();

            if (GetViewModels().Any(vm => !vm.HasLocalData))
            {
                Actions.Add(new ActionInfo
                {
                    Command = new RelayCommand(Refresh),
                    Style = ActionKnownStyles.Refresh,
                    Name = "RefreshButton",
                    ActionType = ActionType.Primary
                });
            }
        }

        public string PageTitle { get; set; }
        public ListViewModel<RssDataConfig, RssSchema> LatestNews { get; private set; }
        public ListViewModel<RssDataConfig, RssSchema> LatestPosts { get; private set; }
        public ListViewModel<YouTubeDataConfig, YouTubeSchema> OurYouTube { get; private set; }
        public ListViewModel<DynamicStorageDataConfig, OurStaffMembers1Schema> OurStaffMembers { get; private set; }
        public ListViewModel<LocalStorageDataConfig, MenuSchema> Links { get; private set; }
        public ListViewModel<LocalStorageDataConfig, HtmlSchema> ServerStatus { get; private set; }

        public RelayCommand<INavigable> SectionHeaderClickCommand
        {
            get
            {
                return new RelayCommand<INavigable>(item =>
                    {
                        NavigationService.NavigateTo(item);
                    });
            }
        }

        public DateTime? LastUpdated
        {
            get
            {
                return GetViewModels().Select(vm => vm.LastUpdated)
                            .OrderByDescending(d => d).FirstOrDefault();
            }
        }

        public List<ActionInfo> Actions { get; private set; }

        public bool HasActions
        {
            get
            {
                return Actions != null && Actions.Count > 0;
            }
        }

        public async Task LoadDataAsync()
        {
            var loadDataTasks = GetViewModels().Select(vm => vm.LoadDataAsync());

            await Task.WhenAll(loadDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private async void Refresh()
        {
            var refreshDataTasks = GetViewModels()
                                        .Where(vm => !vm.HasLocalData)
                                        .Select(vm => vm.LoadDataAsync(true));

            await Task.WhenAll(refreshDataTasks);

            OnPropertyChanged("LastUpdated");
        }

        private IEnumerable<DataViewModelBase> GetViewModels()
        {
            yield return LatestNews;
            yield return LatestPosts;
            yield return OurYouTube;
            yield return OurStaffMembers;
            yield return Links;
            yield return ServerStatus;
        }
    }
}
