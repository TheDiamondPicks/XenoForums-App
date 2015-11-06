using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AppStudio.Uwp.Navigation;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;

namespace XenoForumsApp.Navigation
{
    public class AppNavigation
    {
        private NavigationNode _active;

        static AppNavigation()
        {

        }

        public NavigationNode Active
        {
            get
            {
                return _active;
            }
            set
            {
                if (_active != null)
                {
                    _active.IsSelected = false;
                }
                _active = value;
                if (_active != null)
                {
                    _active.IsSelected = true;
                }
            }
        }


        public ObservableCollection<NavigationNode> Nodes { get; private set; }

        public void LoadNavigation()
        {
            Nodes = new ObservableCollection<NavigationNode>();
		    var resourceLoader = new ResourceLoader();
            Nodes.Add(new ItemNavigationNode
            {
                Title = @"XenoForums App",
                Label = "Home",
                FontIcon = "\ue10f",
                IsSelected = true,
                NavigationInfo = NavigationInfo.FromPage("HomePage")
            });

            Nodes.Add(new ItemNavigationNode
            {
                Label = "Latest News",
                FontIcon = "\ue12a",
                NavigationInfo = NavigationInfo.FromPage("LatestNewsListPage")
            });
            Nodes.Add(new ItemNavigationNode
            {
                Label = "Latest Posts",
                FontIcon = "\ue15f",
                NavigationInfo = NavigationInfo.FromPage("LatestPostsListPage")
            });
            Nodes.Add(new ItemNavigationNode
            {
                Label = "Our YouTube",
                FontIcon = "\ue173",
                NavigationInfo = NavigationInfo.FromPage("OurYouTubeListPage")
            });
            Nodes.Add(new ItemNavigationNode
            {
                Label = "Our Staff Members",
                FontIcon = "\ue13d",
                NavigationInfo = NavigationInfo.FromPage("OurStaffMembersListPage")
            });
            Nodes.Add(new ItemNavigationNode
            {
                Label = resourceLoader.GetString("NavigationPaneAbout"),
                FontIcon = "\ue11b",
                NavigationInfo = NavigationInfo.FromPage("AboutPage")
            });
            Nodes.Add(new ItemNavigationNode
            {
                Label = resourceLoader.GetString("NavigationPanePrivacy"),
                FontIcon = "\ue1f7",
                NavigationInfo = new NavigationInfo()
                {
                    NavigationType = NavigationType.DeepLink,
                    TargetUri = new Uri("http://appstudio.windows.com/home/appprivacyterms", UriKind.Absolute)
                }
            });
        }

        public NavigationNode FindPage(Type pageType)
        {
            return GetAllItemNodes(Nodes).FirstOrDefault(n => n.NavigationInfo.NavigationType == NavigationType.Page && n.NavigationInfo.TargetPage == pageType.Name);
        }

        private IEnumerable<ItemNavigationNode> GetAllItemNodes(IEnumerable<NavigationNode> nodes)
        {
            foreach (var node in nodes)
            {
                if (node is ItemNavigationNode)
                {
                    yield return node as ItemNavigationNode;
                }
                else if(node is GroupNavigationNode)
                {
                    var gNode = node as GroupNavigationNode;

                    foreach (var innerNode in GetAllItemNodes(gNode.Nodes))
                    {
                        yield return innerNode;
                    }
                }
            }
        }
    }
}
