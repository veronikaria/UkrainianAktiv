using UkrainianAktiv.ViewModels;

namespace UkrainianAktiv.Interfaces
{
    public interface IClubService
    {
        IEnumerable<ClubDto> GetClubs();
        Task<IEnumerable<ClubDto>> GetClubsAsync();
        IEnumerable<ClubDto> GetMasterClasses();
        Task<IEnumerable<ClubDto>> GetMasterClassesAsync();
    }
}
