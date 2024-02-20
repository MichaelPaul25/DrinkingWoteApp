using DrinkingWoteApp_API.Models;
using System.ComponentModel;

namespace DrinkingWoteApp_API.Interfaces
{
    public interface ICrewRepository
    {
        ICollection<CrewMember> GetAllMembers();
        CrewMember GetMemberDetails(int id);
        bool CrewExist(int CrewId);
        bool AddNewCrewMember(CrewMember member);
        bool UpdateCrewMember(CrewMember member);
        bool DeleteCrewMember(CrewMember member);
        bool Save();
    }
}
