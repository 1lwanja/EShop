using BlazingShop.Shared;

namespace BlazingShop.Client.Services.CategoryService
{
    interface ICategoryService
    {
        List<Category> Categories { get; set;  }
        Task LoadCategories();
    }
}
