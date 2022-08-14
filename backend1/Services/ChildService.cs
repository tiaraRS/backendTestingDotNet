using AutoMapper;
using backend1.Data.Entity;
using backend1.Data.Repository;
using backend1.Models;

namespace backend1.Services
{
    public class ChildService : IChildService
    {
        private IChildrenWithCourageAppRepository _childRepository;
        private IMapper _mapper;
        public ChildService(IChildrenWithCourageAppRepository childRepository, IMapper mapper)
        {
            _childRepository = childRepository;
            _mapper = mapper;            
        }
        public async Task<IEnumerable<ChildModel>> GetChildrenAsync()
        {
            var disciplineEntityList = await _childRepository.GetChildrenAsync();
            var disciplines = _mapper.Map<IList<ChildModel>>(disciplineEntityList);
            return disciplines;
        }
     
        public async Task<ChildModel> CreateChildAsync(ChildModel child)
        {
            var childEntity = _mapper.Map<ChildEntity>(child);
            _childRepository.CreateChild(childEntity);
            var result = await _childRepository.SaveChangesAsync();
            if (result)
            {
                return _mapper.Map<ChildModel>(childEntity);
            }
            throw new Exception("Database Error");
        }

    }

    
}
