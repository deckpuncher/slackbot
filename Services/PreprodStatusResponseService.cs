using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SlackBot.Models;
using SlackBot.Models.Slack;

namespace SlackBot.Services
{
    public class PreprodStatusResponseService : IPreprodStatusResponseService
    {
        public static string COLOR_INFO = "#b4d8ee";

        public AttachmentResponse PreprodStatus(List<Release> activeReleases)
        {
            AttachmentResponse response = new AttachmentResponse();
            Attachment attachment = PreprodFreeStatus();
            if (activeReleases != null && activeReleases.Count > 0)
            {
                attachment.Text = "Preprod is taken";
                attachment.Color = "warning";

                foreach (var release in activeReleases)
                {
                    attachment.Fields.Add(new Field("User", release.User, true));
                    attachment.Fields.Add(new Field("Ticket(s)", release.Tickets, true));
                    //attachment.Fields.Add(new Field("Date", release.Started.ToShortDateString(), false));
                }
            }

            response.Attachments.Add(attachment);

            return response;
        }

        public Attachment PreprodTaken()
        {
            Attachment attachment = new Attachment();
            attachment.Color = "good";
            attachment.Text = "Success! You now have preprod, keep your ticket(s) updated and remember to run the units tests.";

            return attachment;
        }

        public Attachment PreprodReleased()
        {
            Attachment attachment = new Attachment();
            attachment.Color = "good";
            attachment.Text = "Preprod has been released, update your ticket.";

            return attachment;
        }

        private Attachment PreprodFreeStatus()
        {
            Attachment attachment = new Attachment();
            attachment.Color = COLOR_INFO;
            attachment.Text = PreprodIsFree();

            return attachment;
        }

        private string PreprodIsFree()
        {
            List<string> PreprodFreeMessages = new List<string>();
            PreprodFreeMessages.Add("No one is preprod, go head and break something.");
            PreprodFreeMessages.Add("Preprod is free because no one does anything around here.");

            return PreprodFreeMessages[new Random().Next(0, PreprodFreeMessages.Count)];
        }
    }
}