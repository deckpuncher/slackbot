using System.Collections.Generic;
using SlackBot.Models;
using SlackBot.Models.Slack;

namespace SlackBot.Services
{
    public interface IPreprodReleaseService
    {
        Release CreateRelease(Release release);
        List<Release> GetReleases();
        List<Release> GetActiveReleases();
        Release GetReleaseByUser(string user);        
        Release UpdateRelease(Release release);
        void DeleteRelease(int releaseId);
    }
}