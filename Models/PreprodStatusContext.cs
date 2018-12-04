using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;

namespace SlackBot.Models
{
    public class PreprodStatusContext : DbContext
    {
        public PreprodStatusContext(DbContextOptions<PreprodStatusContext> options)
            : base(options) { }

        public DbSet<Release> Releases { get; set; }
    }

public class Release
    {
        public Release() { }

        public Release(string user, string text)
        {
            this.Started = DateTime.Now;
            this.User = user;
            
            var matches = Regex.Matches(text, "[a-zA-Z]{3}-[0-9]{4}");
            string ticketNums = "No ticket numbers provided.";
            if (matches.Count > 0)
            {
                ticketNums = string.Join(", ", matches.Cast<Match>().Select(match => match.Value).ToArray());
            }
            this.Tickets = ticketNums;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReleaseId { get; set; }

        public string User { get; set; }

        public DateTime Started { get; set; }

        public DateTime Ended { get; set; }

        public string Tickets { get; set; }

        public override string ToString()
        {
            return string.Format($"Preprod is currently taken by `{User}` with the ticket(s): `{Tickets}` since `{Started}`");
        }
    }
}