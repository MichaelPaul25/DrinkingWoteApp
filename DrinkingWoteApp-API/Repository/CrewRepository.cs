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

        public bool AddNewCrewMember(CrewMember member)
        {
            var creMember = _context.Crewers.Where(c => c.FirstName == member.FirstName).FirstOrDefault();
            if(creMember != null)
            {
                return false;
            }
            _context.Add(member);
            return Save();
        }

        public ICollection<CrewMember> GetAllMembers()
        {
            return _context.Crewers.ToList();
        }

        public CrewMember GetMemberDetails(int id)
        {
            return _context.Crewers.Where(c => c.CrewId == id).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
