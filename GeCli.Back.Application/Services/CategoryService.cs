using AutoMapper;
using GeCli.Back.Application.DTOs;
using GeCli.Back.Application.Interfaces;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;

namespace GeCli.Back.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper) 
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var category = await _categoryRepository.GetCategory();
            return _mapper.Map<IEnumerable<CategoryDTO>>(category);
        }

        public async Task<CategoryDTO> GetCategoryById(int? id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task Create(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Create(category);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var category = _mapper.Map<Category>(categoryDTO);
            await _categoryRepository.Update(category);
        }

        public async Task Delete(int id)
        {
            var category = _categoryRepository.GetCategoryById(id).Result;
            await _categoryRepository.Remove(category);
        }
    }
}
