using Microsoft.AspNetCore.Mvc;
using SlackBot.Models.Slack;

namespace SlackBot.Controllers
{
    public abstract class SlackSlashCommandController : ControllerBase
    {

        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        [Produces("application/json")]
        public virtual ActionResult<object> HandleCommand([FromForm]SlashCommandPayload payload)
        {
            return "Slash command received!";
        }
    }
}