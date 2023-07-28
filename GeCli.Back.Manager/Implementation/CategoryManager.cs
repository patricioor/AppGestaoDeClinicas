using AutoMapper;
using GeCli.Back.Domain.Entities;
using GeCli.Back.Domain.Interfaces;
using GeCli.Back.Manager.Interfaces;
using GeCli.Back.Shared.ModelView.Category;

namespace GeCli.Back.Manager.Implementation
{
    public class CategoryManager : ICategoryManager
    {
        readonly ICategoryRepository _categoryRepository;
        readonly IMapper _mapper;
        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<CategoryView>> GetCategoriesAsync()
        {
            return _mapper.Map<ICollection<CategoryView>>(await _categoryRepository.GetCategoriesAsync());
        }

        public async Task<CategoryView> GetCategoryByIdAsync(int id)
        {
            return _mapper.Map<CategoryView>(await _categoryRepository.GetCategoryByIdAsync(id));
        }

        public async Task<CategoryView> InsertCategoryAsync(NewCategory newCategory)
        {
            var category = _mapper.Map<Category>(newCategory);
            return _mapper.Map<CategoryView>(await _categoryRepository.InsertCategoryAsync(category));
        }

        public async Task<CategoryView> DeleteCategoryAsync(int id)
        {
            var categoryDeleted = await _categoryRepository.DeleteCategoryAsync(id);
            return _mapper.Map<CategoryView>(categoryDeleted);
        }

        public async Task<CategoryView> UpdateCategoryAsync(UpdateCategory updateCategory)
        {
            var category = _mapper.Map<Category>(updateCategory);
            return _mapper.Map<CategoryView>(await _categoryRepository.UpdateCategoryAsync(category));
        }
    }
}
