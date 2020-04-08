using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HranaLibrary.Models;
using HranaLibrary.Services;

namespace HranaApi.Controllers
{
    public class RecipesController : ApiController
    {
        private readonly IRecipeService service;

        public RecipesController(IRecipeService service)
        {
            this.service = service;
        }

        // GET: api/books
        public IEnumerable<Recipe> Get()
        {
            return service.GetRecipes();
        }

        // GET: api/books/5
        public IHttpActionResult Get(int id)
        {
            var recipe = service.GetRecipe(id);

            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        // POST: api/books
        public HttpResponseMessage Post(Recipe recipe)
        {
          
            if (service.AddRecipe(recipe))
                return Request.CreateResponse(HttpStatusCode.Created);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
        }


        // PUT: api/books/5
        public IHttpActionResult Put(int id, Recipe recipe)
        {
           
            try
            {
                if (service.UpdateRecipe(id, recipe))
                {
                    return Ok();
                }

                return InternalServerError();
            }
            catch (ApplicationException )
            {
                return NotFound();
            }
        }

    }
    }

