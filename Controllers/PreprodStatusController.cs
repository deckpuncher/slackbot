using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using SlackBot.Models;
using System;
using System.Text.RegularExpressions;
using SlackBot.Models.Slack;
using SlackBot.Services;
using Newtonsoft.Json;

namespace SlackBot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreprodStatusController : SlackSlashCommandController
    {
        protected IPreprodStatusResponseService ResponseService;
        protected IPreprodReleaseService ReleaseService;
        
        public PreprodStatusController(IPreprodStatusResponseService responseService, IPreprodReleaseService releaseService)
        {
            ResponseService = responseService;
            ReleaseService = releaseService;
        }

        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        [Produces("application/json")]
        public override ActionResult<object> HandleCommand([FromForm]SlashCommandPayload payload)
        {            
            List<Release> activeReleases = ReleaseService.GetActiveReleases();
            Release activeRelease = activeReleases.FirstOrDefault();

            // Status
            if (string.IsNullOrWhiteSpace(payload.text) || payload.text.ToLower().Contains("status"))
            {
                return ResponseService.PreprodStatus(activeReleases);
            }

            // Take
            if (payload.text.ToLower().Contains("take"))
            {
                if (activeRelease != null)
                {
                    return ResponseService.PreprodStatus(activeReleases);
                }
                else
                {
                    ReleaseService.CreateRelease(new Release(payload.user_name, payload.text));
                    return ResponseService.PreprodTaken();
                }
            }

            // Done
            if (payload.text.ToLower().Contains("done"))
            {
                List<Release> currentUserReleases = activeReleases.Where(m => m.User == payload.user_name).ToList();
                if (currentUserReleases == null)
                {
                    return "There is no active release in your name, idiot";
                }
                else
                {
                    foreach (var release in currentUserReleases)
                    {
                        release.Ended = DateTime.Now;
                        ReleaseService.UpdateRelease(release);
                    }

                    return ResponseService.PreprodReleased();
                }
            }

            return string.Format($"'{payload.text}' is not a recognised command, supported commands are 'status', 'take' or 'done'");
        }

        [HttpGet]
        [Produces("application/json")]
        public ActionResult<AttachmentResponse> GetAll()
        {
            List<Release> activeReleases = ReleaseService.GetActiveReleases();

            return ResponseService.PreprodStatus(activeReleases);
        }     
    }
}