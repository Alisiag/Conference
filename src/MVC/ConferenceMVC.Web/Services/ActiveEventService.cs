using ConferenceMVC.Domain.Entities; 
using ConferenceMVC.Infrastucture;
using Microsoft.EntityFrameworkCore;

namespace ConferenceMVC.Web.Services
{
    public class ActiveEventService : IActiveEventService
    {
        private readonly ConferenceContext _context;

        public ActiveEventService(ConferenceContext context)
        {
            _context = context;
        }

        public async Task<int?> GetActiveConferenceIdAsync()
        {
            var today = DateTime.Today;

            var activeConference = await _context.Conferences
                .Where(c => c.EndDate >= today)
                .OrderBy(c => c.StartDate)
                .FirstOrDefaultAsync();

            return activeConference?.Id;
        }
    }
}