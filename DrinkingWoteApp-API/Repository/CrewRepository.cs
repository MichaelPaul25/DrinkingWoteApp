using DrinkingWoteApp_API.Data;
using DrinkingWoteApp_API.Interfaces;
using DrinkingWoteApp_API.Models;

namespace DrinkingWoteApp_API.Repository
{
    public class CrewRepository : ICrewRepository
    {
        private readonly AppDbContext _context;

        public CrewRepository(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<CrewMember> GetAllMembers()
        {
            return _context.Crewers.ToList();
        }

        public CrewMember GetMemberDetails(int id)
        {
            return _context.Crewers.Where(c => c.CrewId == id).FirstOrDefault();
        }
    }
}
