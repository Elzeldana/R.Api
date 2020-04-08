using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HranaLibrary.Models
{
    



    public class Recipe
    {

        [JsonProperty("chooserecipeid")]
        public int Choose_RecipeID { get; set; }

        [JsonProperty("categoryid")]
        public int CategoryID { get; set; }

        [JsonProperty("recipename")]
        public string RecipeName { get; set; }

        [JsonProperty("text")]
        public string Recipe_text { get; set; }


    }
}
