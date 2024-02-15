using DrinkingWoteApp_API.Models;

namespace DrinkingWoteApp_API.Interfaces
{
    public interface ICrewRepository
    {
        ICollection<CrewMember> GetAllMembers();
        CrewMember GetMemberDetails(int id);
        bool AddNewCrewMember(CrewMember member);
        bool Save();
    }
}
