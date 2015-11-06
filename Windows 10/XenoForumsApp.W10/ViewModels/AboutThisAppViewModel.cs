using AppStudio.Uwp;
using Windows.ApplicationModel;

namespace XenoForumsApp.ViewModels
{
    public class AboutThisAppViewModel : PageViewModel
    {
        public string Publisher
        {
            get
            {
                return "AppStudio";
            }
        }

        public string AppVersion
        {
            get
            {
                return string.Format("{0}.{1}.{2}.{3}", Package.Current.Id.Version.Major, Package.Current.Id.Version.Minor, Package.Current.Id.Version.Build, Package.Current.Id.Version.Revision);
            }
        }

        public string AboutText
        {
            get
            {
                return "The official XenoForums App for Windows 10. View the latest news and threads on t" +
    "he go wherever you are. Website: http://xenoforums.16mb.com Please report any bu" +
    "gs or make suggestions here.";
            }
        }
    }
}

