using System;
using System.Collections.Generic;
using HranaLibrary.Models;

namespace HranaLibrary.Repository
{
    public interface IDataRepo
    {
        //  bool DeleteRecipe(int recipesID);
        bool AddRecipes(Recipe recipes);
        bool UpdateRecipe(int id, Recipe recipes);
        List<Recipe> GetRecipes();
        Recipe GetRecipe(int recipeid);
    }
}

