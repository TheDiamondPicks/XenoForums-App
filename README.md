# XenoForums App
## How this app works
Essential I hooked into the feeds at http://xenoforums.16mb.com/index.php?forums/-/index.rss for new posts and http://xenoforums.16mb.com/index.php?forums/main-forum.2/index.rss for latest news. I also used https://www.youtube.com/user/ItsFrosttyGames for the YouTube section. The staff list is manually updated but the avatars are not.
## Installation
### x64/x86 Based Windows 10
To install clone this repo and run the powershell script in the install folder. This app is currently only compatible with Windows 10.
### ARM/Windows 10 Mobile
<b>Mobile versions are not tested whatsoever use at your own risk!</b>

1. Install the mobile certificate found at this URL: https://appstudio.windows.com/Job/getaet

2. Download and install the app found in the ```Windows 10/install/ARM``` folder.
#### Installation instructions for Window 8.1 are the same as Windows 10 but install the contents of the ```Windows 8.1``` folder.


## Compiling
In order to compile this you must use Visual Studio 2015. Please note that the Youtube API key located in ```Windows 10/XenoForumsApp.W10/Sections/OurYouTubeConfig.cs``` has been censored for priavcy reasons so it will need to be added. To do so find line ```22``` and replace ```PleaseAddAPIKey``` with your one. A guide can be found at https://developers.google.com/youtube/v3/getting-started (read the before you start section!)
## About
This app was made with Microsoft App Studio.
## Imgur Album
<blockquote class="imgur-embed-pub" lang="en" data-id="a/HQHLw"><a href="//imgur.com/a/HQHLw">GitHub
Screenshots</a></blockquote><script async src="//s.imgur.com/min/embed.js" charset="utf-8"></script>
## How our versioning system works
We have a very specific versioning system:
[OS].[Major release].[Minor release].[Bug fixing]
## Known Caveats
Updating creates duplicate apps. You can fix this by uninstalling the old version.
