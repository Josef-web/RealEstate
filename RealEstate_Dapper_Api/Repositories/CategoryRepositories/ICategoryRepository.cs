using RealEstate_Dapper_Api.Dtos.CategoryDtos;

namespace RealEstate_Dapper_Api.Repositories.CategoryRepositories;

public interface ICategoryRepository
{
    Task<List<ResultCategoryDto>> GetAllCategory();
    Task CreateCategory(CreateCategoryDto categoryDto);
    Task DeleteCategory(int id);
    Task UpdateCategory(UpdateCategoryDto categoryDto);
    Task<GetByIdCategoryDto> GetCategory(int id);

}