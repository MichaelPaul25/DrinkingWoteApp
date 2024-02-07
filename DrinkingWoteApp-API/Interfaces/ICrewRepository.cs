using DrinkingWoteApp_API.Models;

namespace DrinkingWoteApp_API.Interfaces
{
    public interface ICrewRepository
    {
        public ICollection<CrewMember> GetAllMembers();
        public CrewMember GetMemberDetails(int id);
    }
}
