using AppStudio.DataProviders.TouchDevelop;

namespace XenoForumsApp.Config
{
    public abstract class TouchDevelopConfigBase : ConfigBase<TouchDevelopDataConfig, TouchDevelopSchema>
    {
        public abstract string Title { get; }
    }
}
