
using Dapper;
using log4net;
using System;
using System.Data;
using System.Data.SqlClient;
using HranaLibrary.Models;
using HranaLibrary.DbHelper;
using System.Collections.Generic;
using System.Linq;

namespace HranaLibrary.Repository
{
    public class DataRepo : IDataRepo
    {
        readonly ILog logger;

        public DataRepo(ILog logger)
        {
            this.logger = logger;
        }


        public bool AddRecipes(Recipe recipe)
        {
            try
            {
                using (SqlConnection conn = DbAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@categoryid", recipe.CategoryID);


                    int result = conn.Execute("spInsertNewRecipe", parameter, commandType: CommandType.StoredProcedure);

                    return result > 0;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while adding the recipe! " + e.Message, e);
                return false;
            }
        }


        public bool UpdateRecipe(int recipeid, Recipe recipes)
        {
            try
            {
                using (SqlConnection conn = DbAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@recipeid", recipeid);
                    parameter.Add("@categoryid", recipes.CategoryID);
                    parameter.Add("@name", recipes.RecipeName);
                    parameter.Add("@rectext", recipes.Recipe_text);

                    int result = conn.Execute("spUpdateRecipe", parameter, commandType: CommandType.StoredProcedure);

                    return result > 0;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while updating the recipe! " + e.Message, e);
                return false;
            }
        }

        public List<Recipe> GetRecipes()
        {
            try
            {
                using (SqlConnection conn = DbAccess.GetOpenConnection())
                {
                    List<Recipe> result = conn.Query<Recipe>("spGetALlProducts", commandType: CommandType.StoredProcedure).ToList();

                    return result;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while getting the recipes! " + e.Message, e);
                return null;
            }
        }

        public Recipe GetRecipe(int recipeid)
        {
            try
            {
                using (SqlConnection conn = DbAccess.GetOpenConnection())
                {
                    DynamicParameters parameter = new DynamicParameters();
                    parameter.Add("@id", recipeid);

                    Recipe result = conn.Query<Recipe>("spGetRecipeById", parameter, commandType: CommandType.StoredProcedure).FirstOrDefault();

                    return result;
                }
            }
            catch (Exception e)
            {
                logger.Error("Error happened while getting the book! " + e.Message, e);
                return null;
            }
        }






    }
}


