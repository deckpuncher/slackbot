using System.Collections.Generic;
using SlackBot.Models;
using SlackBot.Models.Slack;

namespace SlackBot.Services
{
    public interface IPreprodStatusResponseService
    {
        AttachmentResponse PreprodStatus(List<Release> currentReleases);
        Attachment PreprodTaken();
        Attachment PreprodReleased();
    }
}