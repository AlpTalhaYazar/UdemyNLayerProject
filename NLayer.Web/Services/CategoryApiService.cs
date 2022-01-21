using NLayer.Core.DTOs;

namespace NLayer.Web.Services
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CategoryDto>> GetCategoriesAsync()
        {
            var response =
                await _httpClient.GetFromJsonAsync<CustomResponseDto<IEnumerable<CategoryDto>>>(
                    "products/GetCategoriesAsync");

            return response.Data;
        }

        public async Task<CategoryDto> GetCategoryByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<CategoryDto>>($"products/{id}");
            return response.Data;
        }

        public async Task<CategoryDto> SaveAsync(CategoryDto categoryDto)
        {
            var response = await _httpClient.PostAsJsonAsync("products", categoryDto);

            if (!response.IsSuccessStatusCode) return null;

            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<CategoryDto>>();

            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(CategoryDto categoryDto)
        {
            var response = await _httpClient.PutAsJsonAsync("products", categoryDto);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"products{id}");

            return response.IsSuccessStatusCode;
        }
    }
}
