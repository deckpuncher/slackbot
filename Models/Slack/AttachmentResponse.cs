using System.Collections.Generic;
using Newtonsoft.Json;

namespace SlackBot.Models.Slack
{
    public class AttachmentResponse
    {
        public AttachmentResponse()
        {
            this.Attachments = new List<Attachment>();
        }

        public AttachmentResponse(Attachment attachment)
        {
            this.Attachments = new List<Attachment>();
            this.Attachments.Add(attachment);
        }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("attachments")]
        public List<Attachment> Attachments { get; set; }
    }
}