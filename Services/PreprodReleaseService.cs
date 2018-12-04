using System;
using System.Collections.Generic;
using System.Linq;
using SlackBot.Models;

namespace SlackBot.Services
{
    public class PreprodReleaseService : IPreprodReleaseService
    {
        private readonly PreprodStatusContext _context;

        public PreprodReleaseService(PreprodStatusContext context)
        {
            _context = context;
        }
        public Release CreateRelease(Release release)
        {
            _context.Releases.Add(release);
            _context.SaveChanges();

            return release;
        }

        public void DeleteRelease(int releaseId)
        {
            throw new System.NotImplementedException();
        }

        public List<Release> GetActiveReleases()
        {
            return _context.Releases.Where(m => m.Ended == DateTime.MinValue).ToList();
        }

        public Release GetReleaseByUser(string user)
        {
            return _context.Releases.Where(m => m.User == user).FirstOrDefault();
        }

        public List<Release> GetReleases()
        {
            return _context.Releases.ToList();
        }

        public Release UpdateRelease(Release release)
        {
            _context.Releases.Update(release);
            _context.SaveChanges();

            return release;
        }
    }
}