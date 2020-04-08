using HranaLibrary.Models;
using HranaLibrary.Repository;
using System;
using System.Collections.Generic;
namespace HranaLibrary.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IDataRepo repo;
        public RecipeService(IDataRepo repo)
        {
            this.repo = repo;
        }

        public bool AddRecipe(Recipe recipe)
        {
            if (recipe == null) return false;

            return repo.AddRecipes(recipe);

        }

        public Recipe GetRecipe(int id)
        {
            return repo.GetRecipe(id);
        }

        public IEnumerable<Recipe> GetRecipes()
        {
            return repo.GetRecipes();
        }

        public bool UpdateRecipe(int id, Recipe recipe)
        {
            Recipe foundRecipe = repo.GetRecipe(id);

            if (foundRecipe == null)
                throw new ApplicationException("Book does not exist!");

            return repo.UpdateRecipe(id, recipe);




        }
    }
}


