﻿using System.Collections.Generic;
using TabloidMVC.Models;

namespace TabloidMVC.Repositories
{
    public interface ICategoryRepository
    {
        void DeleteCategory(int categoryId);
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
        void UpdateCategory(Category category);
        void AddCategory(Category category);
    }
}