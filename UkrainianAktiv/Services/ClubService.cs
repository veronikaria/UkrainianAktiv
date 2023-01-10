using AutoMapper;
using Microsoft.EntityFrameworkCore;
using UkrainianAktiv.Core.Constant;
using UkrainianAktiv.Core.Models;
using UkrainianAktiv.Interfaces;
using UkrainianAktiv.ViewModels;

namespace UkrainianAktiv.Services
{
    public class ClubService : BaseService<Club, ClubDto>, IClubService
    {
        public ClubService(IMapper mapper, DataContext context) : base(mapper, context)
        {

        }

        public IEnumerable<ClubDto> GetClubs()
        {
            var clubs = Context.Clubs.Where(c => c.Enabled && c.Type == ClubType.Club);
            return MapToViewModel(clubs);
        }

        public async Task<IEnumerable<ClubDto>> GetClubsAsync()
        {
            var clubs = await Context.Clubs.Where(c => c.Enabled && c.Type == ClubType.Club).ToListAsync();
            return MapToViewModel(clubs);
        }

        public IEnumerable<ClubDto> GetMasterClasses()
        {
            var masterClasses = Context.Clubs.Where(c => c.Enabled && c.Type == ClubType.MasterClass);
            return MapToViewModel(masterClasses);
        }

        public async Task<IEnumerable<ClubDto>> GetMasterClassesAsync()
        {
            var masterClasses = await Context.Clubs.Where(c => c.Enabled && c.Type == ClubType.MasterClass).ToListAsync();
            return MapToViewModel(masterClasses);
        }
    }
}
