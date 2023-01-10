using AutoMapper;
using UkrainianAktiv.Core.Models;
using UkrainianAktiv.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace UkrainianAktiv.Services
{
    public class BaseService<M, Vm> where M : BaseItem where Vm : BaseDto
    {
        protected readonly IMapper Mapper;
        protected readonly DataContext Context;

        protected BaseService(IMapper mapper, DataContext context)
        {
            Mapper = mapper;
            Context = context;
        }

        protected IEnumerable<Vm> MapToViewModel(IEnumerable<M> model)
        {
            return Mapper.Map<IEnumerable<M>, IEnumerable<Vm>>(model);
        }

        public IEnumerable<Vm> GetAll()
        {
            return MapToViewModel(Context.Set<M>());
        }

        public async Task<IEnumerable<Vm>> GetAllAsync()
        {
            var model = await Context.Set<M>().ToListAsync();
            return MapToViewModel(model);
        }
    }
}
